using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeNumText : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        Hide();
	}

    private void Hide()
    {
        this.GetComponent<Text>().color = Color.clear;
    }
}
