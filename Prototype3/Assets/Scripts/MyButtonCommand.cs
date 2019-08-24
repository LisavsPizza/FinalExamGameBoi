using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MyButtonCommand : MonoBehaviour {

    public Color onMouseOver;
    public Color onClicked;
    public UnityEvent m_OnClicked;

    private Color _originalColour;
    private static bool _mouseOverOtherButton;

    // Use this for initialization
    void Start()
    {
        _originalColour = this.GetComponent<SpriteRenderer>().color;

        if (m_OnClicked == null)
        {
            m_OnClicked = new UnityEvent();
        }
        _mouseOverOtherButton = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseEnter()
    {
        if (!this.transform.parent.name.Contains("CommandWheel"))
        {
            AudioManager.PlaySound(Resources.Load("Select") as AudioClip);
        } else
        {
            AudioManager.PlaySound(Resources.Load("Place") as AudioClip);
        }

        this.GetComponent<SpriteRenderer>().color = onMouseOver;
        _mouseOverOtherButton = true;

        GameObject.Find("CommandWheel").GetComponent<CommandWheel>().SetCanClick(false);
    }
    private void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            this.GetComponent<SpriteRenderer>().color = onClicked;
            m_OnClicked.Invoke();

            if (!this.transform.parent.name.Contains("CommandWheel"))
            {
                AudioManager.PlaySound(Resources.Load("Place") as AudioClip);
            }
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            this.GetComponent<SpriteRenderer>().color = onMouseOver;
        }
        _mouseOverOtherButton = true;
    }

    private void OnMouseUp()
    {
        //if (this.gameObject.tag.Equals("FileTab"))
        //{
        //    this.GetComponent<SpriteRenderer>().color = _originalColour;
        //}
    }

    private void OnMouseExit()
    {
        this.GetComponent<SpriteRenderer>().color = _originalColour;
        _mouseOverOtherButton = false;
        GameObject.Find("CommandWheel").GetComponent<CommandWheel>().SetCanClick(true);
    }

    public static bool MouseIsOverOtherButton()
    {
        return _mouseOverOtherButton;
    }

    public void SetClickedEvent(UnityEvent newEvent)
    {
        m_OnClicked = newEvent;
    }

    public void SetOriginalColour (Color newColour)
    {
        _originalColour = newColour;
    }
}
