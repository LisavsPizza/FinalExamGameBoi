using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityBubbleText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Hide();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeBubbleText(string name, string type, string desc)
    {
        Utilities.SearchChild("AbilityName", this.gameObject).GetComponent<Text>().text = name;
        Utilities.SearchChild("AbilityType", this.gameObject).GetComponent<Text>().text = type;
        Utilities.SearchChild("AbilityDesc", this.gameObject).GetComponent<Text>().text = desc;

        Show();
    }

    public void Show()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            this.transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    public void Hide()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            this.transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}
