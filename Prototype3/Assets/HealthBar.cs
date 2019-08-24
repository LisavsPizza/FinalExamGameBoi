using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeHealth(float healthPoints)
    {
        GameObject character = this.transform.parent.transform.parent.gameObject;
        character.GetComponent<Character>().ChangeCurrHPPoints(healthPoints);

        float currHealth = character.GetComponent<Character>().GetCurrHP();
        float maxHealth = character.GetComponent<Character>().hp;

        if (DiceManager.GetCurrCharacter() == character)
        {
            GameObject statsCanvas = GameObject.Find("StatsCanvas");
            Utilities.SearchChild("Health", statsCanvas).GetComponent<Text>().text = currHealth + "/" + maxHealth.ToString();
        }

        this.GetComponent<Image>().fillAmount = currHealth / maxHealth;
    }
}
