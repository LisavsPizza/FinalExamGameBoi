using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnSceneLoadedEventSetter : MonoBehaviour {

    public UnityEvent m_OnMySceneLoaded;
    public UnityEvent m_OnMySceneLoadedReplaceable;

	// Use this for initialization
	void Start () {
		if (m_OnMySceneLoaded == null)
        {
            m_OnMySceneLoaded = new UnityEvent();
        }

        if (m_OnMySceneLoadedReplaceable == null)
        {
            m_OnMySceneLoadedReplaceable = new UnityEvent();
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetMyOnSceneLoadedEvent()
    {
        FadeCanvas.SetSceneLoadedEvent(m_OnMySceneLoaded);
    }

    public void SetMyOnSceneLoadedEventReplacable()
    {
        FadeCanvas.SetSceneLoadedEventReplacable(m_OnMySceneLoadedReplaceable);
    }

    public void RemoveReplaceableSceneChangeEvent()
    {
        m_OnMySceneLoadedReplaceable = new UnityEvent();
        FadeCanvas.SetSceneLoadedEventReplacable(m_OnMySceneLoadedReplaceable);
    }

    public void TestReplacableEventInvoke()
    {
        print("REPLACABLEEVENTSHOULDWORK");
    }

}
