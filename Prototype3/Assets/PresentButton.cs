using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresentButton : MonoBehaviour {

    private GameObject _satchelScreen;

	// Use this for initialization
	void Awake () {
        _satchelScreen = GameObject.Find("SatchelBG");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _satchelScreen.GetComponent<SatchelScreen>().ChangeAfterPresentingNode(TalkingPerson.GetCurrSpeakingPerson().GetComponent<TalkingPerson>().GetSwitchNode());
            GameObject.Find("DialogueCanvasDecorated").GetComponent<DialogueBox>().Hide();
            GameObject.Find("DialogueSystemWright").GetComponent<DialogueSystemWright>().Hide();
            _satchelScreen.GetComponent<SatchelScreen>().SetPresentationMode(true);
        }

    }
}
