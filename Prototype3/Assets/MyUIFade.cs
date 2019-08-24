using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MyUIFade : MonoBehaviour {
    public float fadeAmount = 0.1f;
    public float originalFadeAlpha = 1;

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
        bool text = false;
        bool image = false;

        if (this.GetComponent<Text>() != null)
        {
            text = true;
        } else if (this.GetComponent<Image>() != null)
        {
            image = true;
        }


        Color myColour = Color.red;

        if (text)
        {
          myColour = this.GetComponent<Text>().color;
        } else if (image)
        {
            myColour = this.GetComponent<Image>().color;
        }


        if (_fadeIn)
        {
            if (myColour.a <= originalFadeAlpha)
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

        if (text)
        {
            this.GetComponent<Text>().color = myColour;
        }
        else if (image)
        {
            this.GetComponent<Image>().color = myColour;
        }
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
