using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public string myName;
    public Sprite characterImage;

    public float initiative;

    public float hp;

    private float _currHP;
    private float _currAtk;

    public string dice1Type;
    public string dice2Type;
    public string dice3Type;

    private bool _hadTurn;

    private bool _isSelected;

    // Start is called before the first frame update
    void Start()
    {
        _hadTurn = false;

        _currHP = hp;

        _isSelected = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetMyTurn()
    {
        GameObject characterInfoCanvas = GameObject.Find("CharacterInfoCanvas");
        GameObject statsCanvas = GameObject.Find("StatsCanvas");
        GameObject diceCanvas = GameObject.Find("DiceCanvas");

        Utilities.SearchChild("Name", characterInfoCanvas).GetComponent<Text>().text = myName;
        Utilities.SearchChild("Image", characterInfoCanvas).GetComponent<Image>().sprite = characterImage;

        Utilities.SearchChild("Health", statsCanvas).GetComponent<Text>().text = _currHP+"/"+hp.ToString();

        diceCanvas.transform.GetChild(0).GetComponent<Dice>().ChangeDice(dice1Type);
        diceCanvas.transform.GetChild(1).GetComponent<Dice>().ChangeDice(dice2Type);
        diceCanvas.transform.GetChild(2).GetComponent<Dice>().ChangeDice(dice3Type);

        DiceManager.ClearAllDiceTotals();

        DiceManager.SetCurrCharacter(this);
        DiceManager.CurrCombatStage = DiceManager.CombatStage.DiceAndTargets;
        DiceManager.ClearTargets();

        for (int i = 0; i < GameObject.Find("DiceCanvas").transform.childCount; i++)
        {
            if (!TurnManager.GetCurrTurnCharacter().tag.Contains("Enemy"))
            {
                GameObject.Find("DiceCanvas").transform.GetChild(i).GetComponent<Dice>().EnableAllButtons();
            }
            else
            {
                GameObject.Find("ClickTheDice").GetComponent<Text>().text = "";
            }
        }
    }

    public float GetInitiative()
    {
        return initiative;
    }

    private void OnMouseOver()
    {
        if (DiceManager.CurrCombatStage == DiceManager.CombatStage.DiceAndTargets)
        {
            if (TurnManager.GetCurrTurnCharacter() != this.gameObject)
            {
                this.GetComponent<SpriteRenderer>().color = Color.red;
            }
        }
    }

    private void OnMouseExit()
    {
        if (DiceManager.CurrCombatStage == DiceManager.CombatStage.DiceAndTargets)
        {
            if (TurnManager.GetCurrTurnCharacter() != this.gameObject)
            {
                if (_isSelected == false)
                {
                    this.GetComponent<SpriteRenderer>().color = Color.white;
                }
            }
        }
    }

    private void OnMouseDown()
    {
        if (DiceManager.CurrCombatStage == DiceManager.CombatStage.DiceAndTargets)
        {
            if (TurnManager.GetCurrTurnCharacter() != this.gameObject)
            {
                this.GetComponent<SpriteRenderer>().color = Color.red;
                _isSelected = true;
                DiceManager.ClearTargets();
                DiceManager.AddTarget(this);
            }
        }
    }

    public void SetTurnFinished()
    {
        _hadTurn = true;
    }

    public void SetTurnUnfinished()
    {
        _hadTurn = false;
    }

    public bool HasFinishedTurn()
    {
        return _hadTurn;
    }

    public void ChangeCurrHPPoints(float changeNum)
    {
        if (_currHP + changeNum > hp)
        {
            _currHP = hp;
        } else
        {
            _currHP += changeNum;
        }
    }

    public float GetCurrHP()
    {
        return _currHP;
    }
}
