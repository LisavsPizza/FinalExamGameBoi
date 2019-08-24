using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SceneDelayMetaEvent : MonoBehaviour {

    public UnityEvent m_NewSceneDelayEvent;

	// Use this for initialization
	void Start () {
	if (m_NewSceneDelayEvent == null)
        {
            m_NewSceneDelayEvent = new UnityEvent();
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetDelayEvent()
    {
        Camera.main.GetComponent<ShadowgateSceneTransition>().SetDelayedSceneTransitionEvent(m_NewSceneDelayEvent);
    }
}
