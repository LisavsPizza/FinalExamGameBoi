using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Choice : MonoBehaviour {

    public UnityEvent m_OnChosen;
    private string _choiceText;
    private bool _seen;

	// Use this for initialization
	void Start () {
        Hide();

		if (m_OnChosen == null)
        {
            m_OnChosen = new UnityEvent();
        }
	}

    public string GetChoiceText()
    {
        return this.GetComponent<Text>().text;
    }

    public UnityEvent GetOnChosenEvent()
    {
        return m_OnChosen;
    }

    private void Hide()
    {
        this.GetComponent<Text>().color = Color.clear;
    }

    public void SetSeen()
    {
        _seen = true;
        string myText = this.GetComponent<Text>().text;

        if (!myText.Contains(" [SEEN]"))
        {
            this.GetComponent<Text>().text = myText + " [SEEN]";
        }
    }

    public bool CheckSeen()
    {
        return _seen;
    }

    public void EnableChoice()
    {
        this.transform.parent.GetComponent<MainText>().AddToChoiceList(this);
    }
}
