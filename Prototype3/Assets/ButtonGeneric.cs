using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonGeneric : MonoBehaviour {

    public Color mouseOverColour;
    public Color clickColour;
    public float fadeAmount;

    public UnityEvent m_OnClicked;

    private Color _originalColour;
    private bool _fadeOut;
    private bool _fadeIn;

    // Use this for initialization
    void Start()
    {
        _originalColour = this.GetComponent<SpriteRenderer>().color;

        if (m_OnClicked == null)
        {
            m_OnClicked = new UnityEvent();
        }
    }

    private void Update()
    {
        ControlFade();
    }

    private void OnMouseOver()
    {
        //if (!GameObject.Find("DialogueCanvasDecorated").GetComponent<DialogueBox>().IsShowing())
        //{
            this.GetComponent<SpriteRenderer>().color = mouseOverColour;
        //}
    }

    private void OnMouseDown()
    {
        //if (!GameObject.Find("DialogueCanvasDecorated").GetComponent<DialogueBox>().IsShowing())
        //{
            AudioManager.PlaySound(Resources.Load("ButtonPress") as AudioClip);
            this.GetComponent<SpriteRenderer>().color = clickColour;
            m_OnClicked.Invoke();
        //}
    }

    private void OnMouseEnter()
    {
        //if (!GameObject.Find("DialogueCanvasDecorated").GetComponent<DialogueBox>().IsShowing())
        //{
            AudioManager.PlaySound(Resources.Load("Select") as AudioClip, 0.8f);
        //}
    }

    private void OnMouseExit()
    {
        //if (!GameObject.Find("DialogueCanvasDecorated").GetComponent<DialogueBox>().IsShowing())
        //{
            this.GetComponent<SpriteRenderer>().color = _originalColour;
        //}
    }

    public void SetClickEvent(UnityEvent newEvent)
    {
        m_OnClicked = newEvent;
    }

    public void ControlFade()
    {
        Color myColour = this.GetComponent<SpriteRenderer>().color;

        if (_fadeIn)
        {
            if (myColour.a < 1)
            {
                myColour.a += fadeAmount;
            }
            else
            {
                _fadeIn = false;
            }
        }
        else if (_fadeOut)
        {
            if (myColour.a > 0)
            {
                myColour.a -= fadeAmount;
            }
            else
            {
                _fadeOut = false;
            }
        }

        this.GetComponent<SpriteRenderer>().color = myColour;
    }

    public void Show()
    {
        this.GetComponent<BoxCollider>().enabled = true;
        _fadeIn = true;
    }

    public void Hide()
    {
        this.GetComponent<BoxCollider>().enabled = false;
        _fadeOut = true;
    }
}
