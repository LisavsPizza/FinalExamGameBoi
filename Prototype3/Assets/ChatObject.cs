using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatObject : MonoBehaviour
{
    private bool _shouldHideCheck;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {

        CheckFadeOut();

        //if (GameObject.Find("DialogueCanvasDecorated").GetComponent<DialogueBox>().IsShowing())
        //{
        //    this.GetComponent<MyImage>().FadeOut();
        //    GameObject.Find("ChatObjectBG").GetComponent<MyImage>().FadeOut();
        //}
        //else if (GameObject.Find("DialogueSystemWright").GetComponent<DialogueSystemWright>().IsVisible())
        //{
        //    this.GetComponent<MyImage>().FadeOut();
        //    GameObject.Find("ChatObjectBG").GetComponent<MyImage>().FadeOut();
        //}
        //else if (!GameObject.Find("DialogueCanvasDecorated").GetComponent<DialogueBox>().IsShowing())
        //{
        //    if (!GameObject.Find("DialogueSystemWright").GetComponent<DialogueSystemWright>().IsVisible())
        //    {
        //        this.GetComponent<MyImage>().FadeIn();
        //        GameObject.Find("ChatObjectBG").GetComponent<MyImage>().FadeIn();
        //    }
        //}
    }

    private void CheckFadeOut()
    {
        bool shouldFadeOut = false;


        foreach (GameObject g in GameObject.FindGameObjectsWithTag("Chatbot"))
        {
            if (g.GetComponent<Chatbot>().CheckShowing())
            {
                shouldFadeOut = true;
            }
        }

            if (shouldFadeOut)
            {
                this.GetComponent<MyImage>().FadeOut();

                this.transform.GetChild(0).GetComponent<MyImage>().FadeOut();

            }
            else
            {
                this.GetComponent<MyImage>().FadeIn();

            this.transform.GetChild(0).GetComponent<MyImage>().FadeIn();
        }
    }
}
