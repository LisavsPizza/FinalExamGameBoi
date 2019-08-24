using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiceTinDialogueCheck : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SpiceTinCheck()
    {
        if (GameObject.FindGameObjectWithTag("VegasOriginalDesk")!=null)
        {
            GameObject.Find("DialogueCanvasDecorated").GetComponent<DialogueBox>().Show();
            GameObject.Find("DialogueCanvasDecorated").GetComponent<DialogueBox>().ChangeNode(445);
        } else
        {
            GameObject.Find("DialogueCanvasDecorated").GetComponent<DialogueBox>().Show();
            GameObject.Find("DialogueCanvasDecorated").GetComponent<DialogueBox>().ChangeNode(446);
        }
    }
}
