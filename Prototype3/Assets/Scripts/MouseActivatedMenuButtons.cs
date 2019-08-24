using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseActivatedMenuButtons : MonoBehaviour
{

    public GameObject creditsImages;
    public GameObject aboutImage;
    public GameObject xToClose;

    private bool _canSelect;

    // Use this for initialization
    void Start()
    {
        _canSelect = true;
        xToClose.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (creditsImages.GetComponent<SpriteRenderer>().isVisible || aboutImage.GetComponent<SpriteRenderer>().isVisible)
        {
            xToClose.SetActive(true);
            _canSelect = false;
        }
        else
        {
            xToClose.SetActive(false);
            _canSelect = true;
        }
    }

    public void onStartSelected()
    {
        if (_canSelect)
        {
            GameObject.Find("FadeCanvas").GetComponent<TransitionFade>().nextScene = "GetPlayerName";
            GameObject.Find("FadeCanvas").GetComponent<TransitionFade>().NextScene();
        }
    }

    public void onQuitSelected()
    {
        if (_canSelect)
        {
            Application.Quit();
        }
    }

    public void onAboutSelected()
    {
        if (_canSelect)
        {
            aboutImage.GetComponent<Renderer>().enabled = true;
        }
    }

    public void onCreditsSelected()
    {
        if (_canSelect)
        {
            creditsImages.GetComponent<Renderer>().enabled = true;
        }
    }

    public void HideImages()
    {
        aboutImage.GetComponent<Renderer>().enabled = false;
        creditsImages.GetComponent<Renderer>().enabled = false;
    }
}
