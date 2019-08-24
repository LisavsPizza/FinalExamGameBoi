using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class MapButton : MonoBehaviour {

    public string myScene;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.Find(myScene) != null)
        {
            this.GetComponent<Button>().enabled = false;
            this.GetComponent<Image>().color = Color.grey;
        } else
        {
            this.GetComponent<Button>().enabled = true;
            this.GetComponent<Image>().color = Color.white;
        }
	}
}
