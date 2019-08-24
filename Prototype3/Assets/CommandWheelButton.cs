using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommandWheelButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseOver()
    {
        GameObject commandWheelText = Utilities.SearchChild("TextCanvas", this.transform.parent.gameObject).transform.GetChild(1).gameObject;
        GameObject commandWheelImage = Utilities.SearchChild("TextCanvas", this.transform.parent.gameObject).transform.GetChild(0).gameObject;

        commandWheelText.GetComponent<MyUIFade>().FadeIn();
        commandWheelImage.GetComponent<MyUIFade>().FadeIn();

        string commandName = this.gameObject.name;
        if (commandName == "Go")
        {
            commandName = "Go To";
        } else if (commandName == "Talk")
        {
            commandName = "Talk To";
        }
        commandWheelText.GetComponent<Text>().text = commandName + "\n" + Item.currSelectedItem.name;
    }

    private void OnMouseExit()
    {
        GameObject commandWheelText = Utilities.SearchChild("TextCanvas", this.transform.parent.gameObject).transform.GetChild(1).gameObject;
        GameObject commandWheelImage = Utilities.SearchChild("TextCanvas", this.transform.parent.gameObject).transform.GetChild(0).gameObject;
        commandWheelText.GetComponent<MyUIFade>().FadeOut();
        commandWheelImage.GetComponent<MyUIFade>().FadeOut();
    }
}
