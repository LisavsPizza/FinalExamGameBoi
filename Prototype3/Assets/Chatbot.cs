using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chatbot : MonoBehaviour {

    public List<Sprite> myExpressions;

    public float leftPos;
    public float centerPos;
    public float rightPos;

    private List<ChatPosSetter> _myChatPosSetters = new List<ChatPosSetter>();

    private bool _isShowing;

    private static bool _anyShowing;

    private bool _finishedHiding;

    // Use this for initialization
    private void Awake()
    {
    }

    void Start () {
		
	}

    private void LateUpdate()
    {
    }

    // Update is called once per frame
    void Update () {
        if (!_finishedHiding)
        {
            if (this.GetComponent<SpriteRenderer>().color.a <= 0)
            {
                ChangeExpression("Default");
                CheckAllAlone();
                _finishedHiding = true;
            }
        }
	}

    public void Show()
    {
        _isShowing = true;

        if (IsAlone())
        {
            this.transform.position = new Vector3(centerPos, this.transform.position.y, this.transform.position.z);
        }
        else
        {
            AdjustAllPositions();
        }

        this.GetComponent<MyImage>().FadeIn();
        GameObject.Find("TalkFader").GetComponent<MyImage>().FadeIn();
    }

    public void Hide()
    {
        _finishedHiding = false;
        _isShowing = false;

        this.GetComponent<MyImage>().FadeOut();

        bool tempShow = false;

        foreach (GameObject g in GameObject.FindGameObjectsWithTag("Chatbot"))
        {
            if (g.GetComponent<Chatbot>().CheckShowing())
            {
                tempShow = true;
            }
        }

        if (tempShow == false)
        {
            GameObject.Find("TalkFader").GetComponent<MyImage>().FadeOut();
        }
    }

    public bool CheckShowing()
    {
        return _isShowing;
    }

    public void ChangeExpression(string expression)
    {
        Sprite changeSprite = this.GetComponent<SpriteRenderer>().sprite;

        foreach (Sprite s in myExpressions)
        {
            string expressionName = s.name.Substring(s.name.IndexOf("_")+1);

            if (expressionName.ToUpper().Equals(expression.ToUpper()))
            {
                changeSprite = s;
            }
        }

        this.GetComponent<SpriteRenderer>().sprite = changeSprite;
    }

    public static bool CheckAnyShowing()
    {
        bool anyShowing = false;

        foreach (GameObject g in GameObject.FindGameObjectsWithTag("Chatbot"))
        {
            if (g.GetComponent<Chatbot>().CheckShowing())
            {
                anyShowing = true;
            }
        }

        return anyShowing;
    }

    private void AdjustAllPositions()
    {
        print("ADJUST ALL POSITIONS CALLED");
        foreach (GameObject g in GameObject.FindGameObjectsWithTag("ChatObject"))
        {
            if (GameObject.Find(g.name + "_ChatBot") != null)
            {
                GameObject currChatBot = GameObject.Find(g.name + "_ChatBot");

                foreach (ChatPosSetter c in currChatBot.GetComponent<Chatbot>().myListChatPosSetters())
                {
                    print("ADJUSTING POSITION: " + currChatBot.name + " should move " + c.pos + " because of " + c.person);
                    c.SetPosAccordingToPerson();
                }
            }
        }
    }

    private bool IsAlone()
    {
        bool alone = true;

        foreach (GameObject g in GameObject.FindGameObjectsWithTag("Chatbot"))
        {
            if (g != this.gameObject)
            {
                if (g.GetComponent<Chatbot>().CheckShowing())
                {
                    alone = false;
                }
            }
        }

        return alone;
    }

    private void CheckAllAlone()
    {
        foreach (GameObject g in GameObject.FindGameObjectsWithTag("ChatObject"))
        {
            if (GameObject.Find(g + "_ChatBot") != null)
            {
                GameObject currChatBot = GameObject.Find(g + "_ChatBot");
                if (currChatBot.GetComponent<Chatbot>().IsAlone())
                {
                    currChatBot.transform.position = new Vector3(centerPos, this.transform.position.y, this.transform.position.z);
                }
            }
        }
    }

    public void AddChatBotPosSetterToList(ChatPosSetter cP)
    {
        _myChatPosSetters.Add(cP);
    }

    public List<ChatPosSetter> myListChatPosSetters()
    {
        return _myChatPosSetters;
    }
}
