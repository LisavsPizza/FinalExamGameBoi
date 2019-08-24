using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverallGameController : MonoBehaviour {

    private GameObject _instructionsCanvas;
	// Use this for initialization
	void Start () {
        _instructionsCanvas = GameObject.Find("InstructionsCanvas");
        _instructionsCanvas.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!_instructionsCanvas.activeInHierarchy)
            {
                _instructionsCanvas.SetActive(true);
            } else
            {
                _instructionsCanvas.SetActive(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftShift)|| Input.GetKeyDown(KeyCode.RightShift))
        {
            GameObject.Find("TextLog").GetComponent<TextLog>().ControlVisibility();
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (!GameObject.Find("DialogueSystemWright").GetComponent<DialogueSystemWright>().IsVisible())
            {
                if (!GameObject.Find("TextLog").GetComponent<TextLog>().CheckHidDialogueBoxFromHere())
                {
                    GameObject.Find("SatchelBG").GetComponent<SatchelScreen>().ControlVisibilityForTabAndXButton();
                }
            }
        }
    }
}
