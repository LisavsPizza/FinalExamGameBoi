using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChoiceButton : MonoBehaviour {

    private UnityEvent m_OnPressed;
    private GameObject _logContent;

    private Choice myChoice;

    // Use this for initialization

    private void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(InvokeOnPressed);
        _logContent = GameObject.Find("LogContent");
    }

    public void SetOnPressedEvent(UnityEvent newPressEvent)
    {
        m_OnPressed = newPressEvent;
    }

    void InvokeOnPressed()
    {
        string logText = _logContent.GetComponent<Text>().text;
        logText += "\n" + this.transform.GetChild(0).GetComponent<Text>().text + "\n";
        _logContent.GetComponent<Text>().text = logText;

        if (myChoice!=null)
        {
            myChoice.SetSeen();
        }

        AudioManager.PlaySound(Resources.Load("ButtonPress") as AudioClip);
        m_OnPressed.Invoke();
    }

    public void PlaySound()
    {
        AudioManager.PlaySound(Resources.Load("Select") as AudioClip, 0.8f);
    }

    public void SetMyChoice(Choice choice)
    {
        myChoice = choice;
    }
}
