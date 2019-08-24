using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MyImage : MonoBehaviour
{

    public float fadeAmount;
    private UnityEvent m_ReturnToImage;

    private bool _fadeIn;
    private bool _fadeOut;

    private void Start()
    {
        _fadeIn = false;
        _fadeOut = false;
    }

    private void Update()
    {
        ControlFade();
    }

    public void ControlFade()
    {
        Color myColour = this.GetComponent<SpriteRenderer>().color;

        if (_fadeIn)
        {
            if (myColour.a <= 1)
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
            if (myColour.a >= 0)
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

    public void FadeIn()
    {
        _fadeIn = true;
    }

    public void FadeOut()
    {
        _fadeOut = true;
    }
}
