using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SatchelButtonUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (GameObject.Find("DialogueCanvasDecorated").GetComponent<DialogueBox>().IsShowing())
        {
            this.GetComponent<Button>().enabled = false;
        }else if (GameObject.Find("DialogueSystemWright").GetComponent<DialogueSystemWright>().ShouldBeVisible())
        {
            this.GetComponent<Button>().enabled = false;
        }

        if (!GameObject.Find("DialogueCanvasDecorated").GetComponent<DialogueBox>().IsShowing())
        {
            if (!GameObject.Find("DialogueSystemWright").GetComponent<DialogueSystemWright>().ShouldBeVisible())
            {
                this.GetComponent<Button>().enabled = true;
            }
        }
    }
}
