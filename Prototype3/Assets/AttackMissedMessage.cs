using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMissedMessage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnAttackMissed()
    {
        for (int j = 0; j < GameObject.Find("DiceCanvas").transform.childCount; j++)
        {
            GameObject.Find("DiceCanvas").transform.GetChild(j).gameObject.GetComponent<Dice>().DisableAllButtons();
        }

        TurnManager.NextTurn();
    }
}
