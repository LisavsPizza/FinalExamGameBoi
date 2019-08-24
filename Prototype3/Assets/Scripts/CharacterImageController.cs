using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterImageController : MonoBehaviour {

    public List <Sprite> spriteList;
    public float fadeAmount;
    public UnityEvent m_OnClickedWhenVisible;
    public UnityEvent m_OnEnterPressedWhenVisible;

    private bool _fadeIn;
    private bool _fadeOut;

    private void Start()
    {
        _fadeIn = false;
        _fadeOut = false;

        if(m_OnClickedWhenVisible == null)
        {
            m_OnClickedWhenVisible = new UnityEvent();
        }

        if (m_OnEnterPressedWhenVisible == null)
        {
            m_OnEnterPressedWhenVisible = new UnityEvent();
        }
    }

    private void Update()
    {
        ControlFade();

        if (this.GetComponent<SpriteRenderer>().color.a >= 1)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                m_OnClickedWhenVisible.Invoke();
            } else if (Input.GetKeyDown(KeyCode.Return))
            {
                m_OnEnterPressedWhenVisible.Invoke();
            }
        }
    }

    public void ChangeSprite(string spriteName)
    {
        foreach (Sprite s in spriteList)
        {
            if (s.name.Contains(spriteName))
            {
                this.GetComponent<SpriteRenderer>().sprite = s;
            }
        }
    }

    public void Show()
    {
        _fadeIn = true;
    }

    public void Hide()
    {
        _fadeOut = true;
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
}
