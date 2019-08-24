using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyName : MonoBehaviour {

    private static string _myName;

    // Use this for initialization
    void Start () {
        _myName = "NAME_NOT_FOUND";

    }
	
	// Update is called once per frame
	void Update () {
	}

    public void StoreName()
    {
        _myName = this.GetComponent<InputField>().textComponent.text;
    }

    public static string GetName()
    {
        return _myName;
    }
}
