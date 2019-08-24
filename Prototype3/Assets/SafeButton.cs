using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SafeButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UpdateSafeText()
    {
       // PressIn();
        GameObject codeDisplay = GameObject.Find("CodeDisplay");
        codeDisplay.GetComponent<Text>().text += this.gameObject.name+" ";
    }

    public void PressIn()
    {
        this.GetComponent<SpriteRenderer>().color = Color.gray;
    }

    public void ReleaseButtons()
    {
        this.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
