using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmAttackButton : MonoBehaviour
{
    public float speed;
    public float animationWaitTime;

    private bool _startAttack;

    private bool _hasMovedToAttackPos;
    private bool _hasPlayedAttackAnim;

    private float _animationTimer;

    private Vector3 _originalPos;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_startAttack)
        {
            List<Character> targets = DiceManager.GetCurrTargets();
            float step = speed * Time.deltaTime; // calculate distance to move

            if (!_hasMovedToAttackPos)
            {
                Vector3 targetPos = GameObject.Find("AttackTarget").transform.position;
                targetPos.y = DiceManager.GetCurrCharacter().gameObject.transform.position.y;
                targetPos.z = DiceManager.GetCurrCharacter().gameObject.transform.position.z;

                if (Vector3.Distance(DiceManager.GetCurrCharacter().gameObject.transform.position, targetPos) > 0.1f)
                {
                    DiceManager.GetCurrCharacter().gameObject.transform.position = Vector3.MoveTowards(DiceManager.GetCurrCharacter().gameObject.transform.position, targetPos, step);
                }
                else
                {
                    foreach (Character c in targets)
                    {
                        GameObject effectsAnimator = Utilities.SearchChild("EffectsAnimator", c.gameObject);
                        effectsAnimator.GetComponent<SpriteRenderer>().enabled = true;
                        effectsAnimator.GetComponent<Animator>().enabled = true;
                    }

                    _hasMovedToAttackPos = true;
                }
            }
            else if (!_hasPlayedAttackAnim)
            {
                _animationTimer += Time.deltaTime;

                if (_animationTimer >= animationWaitTime)
                {
                    _animationTimer = 0.0f;


                    Character currChar = DiceManager.GetCurrCharacter();
                    DiceManager.ExecuteAttack();
                    _hasPlayedAttackAnim = true;
                }
            }
            else
            {
                DiceManager.GetCurrCharacter().gameObject.transform.position = Vector3.MoveTowards(DiceManager.GetCurrCharacter().gameObject.transform.position, _originalPos, step);

                if (Vector3.Distance(DiceManager.GetCurrCharacter().gameObject.transform.position, _originalPos) > 0.1f)
                {
                    DiceManager.GetCurrCharacter().gameObject.transform.position = Vector3.MoveTowards(DiceManager.GetCurrCharacter().gameObject.transform.position, _originalPos, step);
                }
                else
                {

                    _startAttack = false;
                    _hasMovedToAttackPos = false;
                    _hasPlayedAttackAnim = false;

                    //VERY IMPORTANT MAKE SURE THIS LINE IS IN EVERY ABILITY!!!
                    TurnManager.FinishAttack();
                }
            }
        }
    }

    public void ConfirmAttack()
    {
        if (DiceManager.GetCurrTargets().Count > 0)
        {
            _originalPos = TurnManager.GetCurrTurnCharacter().gameObject.transform.position;

            _startAttack = true;

            DiceManager.CurrCombatStage = DiceManager.CombatStage.ExecutingAttack;

            GameObject diceCanvas = GameObject.Find("DiceCanvas");

            diceCanvas.transform.GetChild(0).GetComponent<Dice>().InvokeOnAttackEvent();
            diceCanvas.transform.GetChild(1).GetComponent<Dice>().InvokeOnAttackEvent();
            diceCanvas.transform.GetChild(2).GetComponent<Dice>().InvokeOnAttackEvent();
        }
    }
}
