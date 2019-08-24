using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAttack : MonoBehaviour
{

    public float speed;
    public float animationWaitTime;

    private bool _hasFinishedAttack;
    private bool _startAttack;

    private bool _hasMovedToAttackPos;
    private bool _hasPlayedAttackAnim;

    private float _animationTimer;

    private Vector3 _originalPos;

    // Start is called before the first frame update
    void Start()
    {
        _hasFinishedAttack = false;
        _hasMovedToAttackPos = false;
        _hasPlayedAttackAnim = false;

        _originalPos = this.transform.position;
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

                    //Keenan's sicc damage calculation

                    Character currChar = DiceManager.GetCurrCharacter();

                    foreach (Character c in targets)
                    {

                        //float damage = currChar.atk * (1 - ((0.052f * c.def) / (0.9f + c.def * 0.048f)));

                        //damage = Mathf.Round(damage);
                        //GameObject healthCanvas = Utilities.SearchChild("HealthCanvas", c.gameObject);
                        //GameObject healthBar = Utilities.SearchChild("HealthBar", healthCanvas);

                        //healthBar.GetComponent<HealthBar>().ChangeHealth(-damage);
                    }

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

            //_attackTimer += Time.deltaTime;

            //if (_attackTimer >= 3)
            //{
            //    _startAttackTimer = false;
            //    _hasFinishedAttack = true;
            //    _attackTimer = 0.0f;

            //    //VERY IMPORTANT MAKE SURE THIS LINE IS IN EVERY ABILITY!!!
            //    TurnManager.FinishAttack();
            //}
        }
    }

    public void Attack()
    {
        Character currCharacter = DiceManager.GetCurrCharacter();
        _startAttack = true;
    }
}
