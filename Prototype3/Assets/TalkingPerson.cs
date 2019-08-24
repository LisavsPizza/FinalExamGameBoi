using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TalkingPerson : MonoBehaviour {

    public UnityEvent m_MyTalkEvent;
    public UnityEvent m_MyGoodbyeEvent;
    public int mySwitchNode;

    private static GameObject _currSpeakingPerson;

    // Use this for initialization
    void Start () {
		if (m_MyTalkEvent == null)
        {
            m_MyTalkEvent = new UnityEvent();
        }

        if (m_MyGoodbyeEvent == null)
        {
            m_MyGoodbyeEvent = new UnityEvent();
        }
    }
	
	// Update is called once per frame
	void Update () {
	}

    public void SetMyTalkEvent()
    {
        GameObject.Find("DialogueSystemWright").GetComponent<DialogueSystemWright>().ChangeTalkEvent(m_MyTalkEvent);
    }

    public void SetMyGoodbyeEvent()
    {
        GameObject.Find("DialogueSystemWright").GetComponent<DialogueSystemWright>().ChangeGoodbyeEvent(m_MyGoodbyeEvent);
    }

    public static GameObject GetCurrSpeakingPerson()
    {
        return _currSpeakingPerson;
    }

    public static void SetCurrSpeakingPerson (GameObject person)
    {
        _currSpeakingPerson = person;
    }

    public void SetInactive()
    {
        this.GetComponent<SpriteRenderer>().enabled = false;
        this.GetComponent<BoxCollider>().enabled = false;
        this.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
    }

    public int GetSwitchNode()
    {
        return mySwitchNode;
    }
}
