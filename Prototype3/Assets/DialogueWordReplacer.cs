using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueWordReplacer : MonoBehaviour {

    string replaceText = "CURRSELECTEDOBJECT";
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        string myText = this.GetComponent<Text>().text;

        if (myText.Contains(replaceText))
        {
            if (Item.currSelectedItem != null)
            {
                myText = myText.Replace(replaceText, Item.currSelectedItem.name);
                replaceText = Item.currSelectedItem.name;
            }
        }

        this.GetComponent<Text>().text = myText;
    }
}
