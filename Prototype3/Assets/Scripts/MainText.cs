using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MainText : MonoBehaviour
{
    public string currCharacter;
    private bool _hasChoice;
    public UnityEvent m_OnClicked;
    public UnityEvent m_OnShown;

    private List<Choice> _choiceList = new List<Choice>();

    private void Start()
    {
        Hide();

        if (m_OnClicked == null)
        {
            m_OnClicked = new UnityEvent();
        }

        if (m_OnShown == null)
        {
            m_OnShown = new UnityEvent();
        }

        _hasChoice = false;

        for (int i = 0; i < this.transform.childCount; i++)
        {
            GameObject currChild = this.transform.GetChild(i).gameObject;

            if (currChild.tag.Equals("Choice") && currChild.activeInHierarchy)
            {
                _choiceList.Add(currChild.GetComponent<Choice>());
            }
        }

        if (_choiceList.Count > 0)
        {
            _hasChoice = true;
        }
    }

    public string GetCurrCharacter()
    {
        string myText = currCharacter;
        myText = myText.Replace("MC", MyName.GetName());
        return myText;
    }

    public string GetMainText()
    {
        string myText = this.GetComponent<Text>().text;
        myText = myText.Replace("MC", MyName.GetName());
        return myText;
    }

    public List<Choice> GetChoiceList()
    {
        return _choiceList;
    }

    public bool HasChoice()
    {
        return _hasChoice;
    }

    public void InvokeOnClickedEvent()
    {
        m_OnClicked.Invoke();
    }

    public void InvokeOnShownEvent()
    {
        m_OnShown.Invoke();
    }

    private void Hide()
    {
        this.GetComponent<Text>().color = Color.clear;
    }

    public bool MCIsSpeaking()
    {
        if (currCharacter.Equals("MC"))
        {
            return true;
        } else
        {
            return false;
        }
    }

    public void AddToChoiceList(Choice choice)
    {
        _choiceList.Add(choice);
        choice.gameObject.SetActive(true);
    }

    public void ChangeOnClickedEvent(UnityEvent newOnClicked)
    {
        m_OnClicked = newOnClicked;
    }
}
