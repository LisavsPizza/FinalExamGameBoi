using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommonDice : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnStopped()
    {
        Random.InitState((int)System.DateTime.Now.Ticks);
        int diceRoll = Random.Range(1, 7);
       
            GameObject.Find("ClickTheDice").GetComponent<Text>().text = "DICE VALUES: ";

            if (DiceManager.APFound() == false)
            {
                GameObject ap = DiceManager.FindEmptyTypeTotal();
                ap.GetComponent<Text>().text = "AP: ";
                ap.transform.GetChild(0).GetComponent<Text>().enabled = true;
                DiceManager.SetAPFound(true);
            }

            string rollValueName = "RollValue" + Dice.LastDiceClicked().name.ToCharArray()[Dice.LastDiceClicked().name.Length - 1];
            GameObject.Find(rollValueName).GetComponent<Text>().text = diceRoll.ToString();

            int rollTotal = int.Parse(GameObject.Find("RollTotal").GetComponent<Text>().text);
            rollTotal += diceRoll;
            GameObject.Find("RollTotal").GetComponent<Text>().text = rollTotal.ToString();
            GameObject.Find("RollTotal").GetComponent<Text>().enabled = true;

            int attackTotal = int.Parse(DiceManager.FindTypeTotalGameObject("AP").transform.GetChild(0).GetComponent<Text>().text);
            attackTotal += diceRoll;
            DiceManager.FindTypeTotalGameObject("AP").transform.GetChild(0).GetComponent<Text>().text = attackTotal.ToString();

        if (diceRoll == 1)
        {
            GameObject.Find("AttackMissed").GetComponent<BillboardMessage>().ShowMessage();
        }
    }

    
}
