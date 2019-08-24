using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodbyeButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject.Find("DialogueSystemWright").GetComponent<DialogueSystemWright>().Hide();
            GameObject.Find("DialogueCanvasDecorated").GetComponent<DialogueBox>().Hide();
            GameObject.Find("DialogueCanvasDecorated").GetComponent<DialogueBox>().SetSwitchNode(-1);
        }
    }
}
