using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ClickToContinue : MonoBehaviour {

    public UnityEvent m_OnClicked;

	// Use this for initialization
	void Start () {
		if (m_OnClicked == null)
        {
            m_OnClicked = new UnityEvent();
        }
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            m_OnClicked.Invoke();
        }
	}
}
