using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintsObtainedDialogueCheck : MonoBehaviour {

    private bool _printsObtained;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetPrintsObtained()
    {
        _printsObtained = true;
    }

    public void SetPrintsDialogue()
    {
        if (_printsObtained)
        {
            GameObject.Find("DialogueCanvasDecorated").GetComponent<DialogueBox>().Show();
            GameObject.Find("DialogueCanvasDecorated").GetComponent<DialogueBox>().ChangeNode(457);
        }
        else
        {
            GameObject.Find("DialogueCanvasDecorated").GetComponent<DialogueBox>().Show();
            GameObject.Find("DialogueCanvasDecorated").GetComponent<DialogueBox>().ChangeNode(472);
        }
    }
}
