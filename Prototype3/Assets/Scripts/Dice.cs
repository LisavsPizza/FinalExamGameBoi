using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Dice : MonoBehaviour
{

    private static bool _hasEnabledButtons;
    private static GameObject _lastDiceClicked;

    private UnityEvent m_OnDiceStopped;
    private UnityEvent m_OnAttack;
    private UnityEvent m_OnStatusEffect; //*FIND A PLACE TO INVOKE STATUS EFFECTS!

    private bool _stopped;
    
    // Start is called before the first frame update
    void Start()
    {
        _stopped = false;
        this.GetComponent<Button>().enabled = false;
        _lastDiceClicked = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (_hasEnabledButtons == false)
        {

            if (DiceManager.CurrCombatStage == DiceManager.CombatStage.DiceAndTargets)
            {
                if (!DiceManager.GetCurrCharacter().tag.Equals("Enemy"))
                {
                    EnableAllButtons();
                    _hasEnabledButtons = true;
                }
            }
        }
    }

    public void ChangeDice(string diceType)
    {
        DiceType myDiceType = DiceManager.SearchDiceType(diceType);

        this.GetComponent<Image>().sprite = myDiceType.GetImage();
        m_OnDiceStopped = myDiceType.GetOnStoppedEvent();
        m_OnAttack = myDiceType.GetOnAttackEvent();
        m_OnStatusEffect = myDiceType.GetOnStatusEvent();
    }

    public void DisableAllButtons()
    {
        for (int i = 0; i < this.transform.parent.childCount; i++)
        {
            this.transform.parent.GetChild(i).GetComponent<Button>().enabled = false;
            _hasEnabledButtons = false;
        }
    }

    public void EnableAllButtons()
    {
        for (int i = 0; i < this.transform.parent.childCount; i++)
        {
            this.transform.parent.GetChild(i).GetComponent<Button>().enabled = true;
            this.transform.parent.GetChild(i).GetComponent<Image>().color = Color.white;
            this.GetComponent<ShakeObject>().Shake();
            string questionMarkName = "QuestionMark" + this.name.ToCharArray()[this.name.Length - 1];
            GameObject.Find(questionMarkName).GetComponent<Image>().enabled = true;
        }
    }

    public void OnDiceClicked()
    {
        if (DiceManager.CurrCombatStage == DiceManager.CombatStage.DiceAndTargets)
        {
            _stopped = true;

            _lastDiceClicked = this.gameObject;

            this.GetComponent<ShakeObject>().StopShaking();
            string questionMarkName = "QuestionMark"+this.name.ToCharArray()[this.name.Length-1];
            GameObject.Find(questionMarkName).GetComponent<Image>().enabled = false;


            m_OnDiceStopped.Invoke();

            this.GetComponent<Button>().enabled = false;
        }
    }


    public void InvokeOnAttackEvent()
    {
        m_OnAttack.Invoke();
    }

    public static GameObject LastDiceClicked()
    {
        return _lastDiceClicked;
    }

 
    public bool HasStopped()
    {
        return _stopped;
    }

    public void SetStopped(bool stop)
    {
        _stopped = stop;
    }
}


//Old Methods


//public void ChangeBubbleText()
//{
//    if (DiceManager.GetCurrCharacter().tag != "Enemy")
//    {
//        string name;
//        string type;
//        string desc;

//        string[] allText;


//        if (this.gameObject.name.Equals("Ability1"))
//        {
//            allText = DiceManager.GetCurrCharacter().ability1Info.Split('#');

//            name = allText[0];
//            type = allText[1];
//            desc = allText[2];
//        }
//        else if (this.gameObject.name.Equals("Ability2"))
//        {
//            allText = DiceManager.GetCurrCharacter().ability2Info.Split('#');

//            name = allText[0];
//            type = allText[1];
//            desc = allText[2];

//        }
//        else
//        {
//            allText = DiceManager.GetCurrCharacter().ability3Info.Split('#');

//            name = allText[0];
//            type = allText[1];
//            desc = allText[2];
//        }
//    }
//}


