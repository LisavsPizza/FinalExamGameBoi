using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueSystemWright : MonoBehaviour
{

    private List<GameObject> _myChildren;
    private bool _showTemporarily;
    private bool _shouldBeVisible;

    // Use this for initialization
    void Start()
    {

        _myChildren = new List<GameObject>();

        for (int i = 0; i < this.transform.childCount; i++)
        {
            _myChildren.Add(this.transform.GetChild(i).gameObject);
        }

        Hide();

    }

    // Update is called once per frame
    void Update()
    {

        if (_shouldBeVisible)
        {
            if (_showTemporarily == false)
            {
                foreach (GameObject g in _myChildren)
                {
                    g.SetActive(false);
                }

                if (!GameObject.Find("DialogueCanvasDecorated").GetComponent<DialogueBox>().IsShowing())
                {

                    if (GameObject.Find("MapButton") != null)
                    {
                        GameObject.Find("MapButton").GetComponent<MyUIFade>().FadeIn();
                    }

                }
            }
            else
            {
                foreach (GameObject g in _myChildren)
                {
                    g.SetActive(true);
                }


                if (GameObject.Find("MapButton") != null)
                {
                    GameObject.Find("MapButton").GetComponent<MyUIFade>().FadeOut();
                }

            }
        }

        if (IsVisible())
        {
            Utilities.SearchChild("Controls", GameObject.Find("WrightControlsUI")).GetComponent<ControlsImage>().SwitchModeDialogueShowing(true);
            GameObject.Find("CommandWheel").GetComponent<CommandWheel>().Hide();
            GameObject.Find("CommandWheel").GetComponent<CommandWheel>().SetCanClick(false);
        }
    }

    public void Hide()
    {
        foreach (GameObject g in _myChildren)
        {
            if (g.GetComponent<SpriteRenderer>() != null)
            {
                g.GetComponent<SpriteRenderer>().enabled = false;
            }

            if (g.GetComponent<BoxCollider>() != null)
            {
                g.GetComponent<BoxCollider>().enabled = false;
            }
        }
        GameObject.Find("DialogueCanvasDecorated").GetComponent<DialogueBox>().SetSwitchNode(-1);
        _shouldBeVisible = false;
    }

    public void Show()
    {
        foreach (GameObject g in _myChildren)
        {
            if (g.GetComponent<SpriteRenderer>() != null)
            {
                g.GetComponent<SpriteRenderer>().enabled = true;
            }

            if (g.GetComponent<BoxCollider>() != null)
            {
                g.GetComponent<BoxCollider>().enabled = true;
            }
        }
        _shouldBeVisible = true;
        _showTemporarily = true;
    }

    public void ChangeTalkEvent(UnityEvent talkEvent)
    {
        foreach (GameObject g in _myChildren)
        {
            if (g.name == "Talk")
            {
                g.GetComponent<MyButtonCommand>().SetClickedEvent(talkEvent);
            }
        }
    }

    public void ChangeGoodbyeEvent(UnityEvent goodbyeEvent)
    {
        foreach (GameObject g in _myChildren)
        {
            if (g.name == "Goodbye")
            {
                g.GetComponent<MyButtonCommand>().SetClickedEvent(goodbyeEvent);
            }
        }
    }

    public void ShowTemporarily()
    {
        _showTemporarily = true;
    }

    public void HideTemporarily()
    {
        _showTemporarily = false;
    }

    public bool ShouldBeVisible()
    {
        return _shouldBeVisible;
    }

    public bool IsVisible()
    {
        if (_myChildren[0].GetComponent<SpriteRenderer>().enabled)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
