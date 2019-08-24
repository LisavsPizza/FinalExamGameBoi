using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatPosSetter : MonoBehaviour
{

    public string person;
    public string pos;

    private bool _move;
    private Vector3 _currMovingPos;

    private void Awake()
    {
        this.gameObject.GetComponent<Chatbot>().AddChatBotPosSetterToList(this);
        print("SHOULD ADD TO LIST");
    }

    private void Update()
    {
        if (_move)
        {
            float step = 10 * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, _currMovingPos, step);

            // Check if the position of the cube and sphere are approximately equal.
            if (Vector3.Distance(transform.position, _currMovingPos) < 0.001f)
            {
                _move = false;
            }
        }
    }

    public void SetPosAccordingToPerson()
    {
        if (GameObject.Find(person + "_ChatBot") != null)
        {
            if (GameObject.Find(person + "_ChatBot").GetComponent<Chatbot>().CheckShowing())
            {
                if (this.GetComponent<SpriteRenderer>().color.a >= 1)
                {
                    _move = true;
                    if (pos.ToUpper() == "LEFT")
                    {
                        _currMovingPos = new Vector3(this.GetComponent<Chatbot>().leftPos, this.transform.position.y, this.transform.position.z);
                        print("SETTING POS ACCORDING TO PERSON: " + this.name + "should move " + "left");
                    }
                    else if (pos.ToUpper() == "RIGHT")
                    {
                        _currMovingPos = new Vector3(this.GetComponent<Chatbot>().rightPos, this.transform.position.y, this.transform.position.z);
                        print("SETTING POS ACCORDING TO PERSON: " + this.name + "should move " + "right");
                    }
                    else
                    {
                        _currMovingPos = new Vector3(this.GetComponent<Chatbot>().centerPos, this.transform.position.y, this.transform.position.z);
                        print("SETTING POS ACCORDING TO PERSON: " + this.name + "should move " + "center");
                    }
                }
                else
                {
                    _move = false;
                    if (pos.ToUpper() == "LEFT")
                    {
                        this.transform.position = new Vector3(this.GetComponent<Chatbot>().leftPos, this.transform.position.y, this.transform.position.z);
                        print("SETTING POS ACCORDING TO PERSON: " + this.name + "should move " + "left");
                    }
                    else if (pos.ToUpper() == "RIGHT")
                    {
                        this.transform.position = new Vector3(this.GetComponent<Chatbot>().rightPos, this.transform.position.y, this.transform.position.z);
                        print("SETTING POS ACCORDING TO PERSON: " + this.name + "should move " + "right");
                    }
                    else
                    {
                        this.transform.position = new Vector3(this.GetComponent<Chatbot>().centerPos, this.transform.position.y, this.transform.position.z);
                        print("SETTING POS ACCORDING TO PERSON: " + this.name + "should move " + "center");
                    }
                }
            }
        }
    }

    public void SetPosManually(string newPos)
    {
        if (newPos.ToUpper() == "LEFT")
        {
            _currMovingPos = new Vector3(this.GetComponent<Chatbot>().leftPos, this.transform.position.y, this.transform.position.z);
        }
        else if (newPos.ToUpper() == "RIGHT")
        {
            _currMovingPos = new Vector3(this.GetComponent<Chatbot>().rightPos, this.transform.position.y, this.transform.position.z);
        }
        else
        {
            _currMovingPos = new Vector3(this.GetComponent<Chatbot>().centerPos, this.transform.position.y, this.transform.position.z);
        }

        _move = true;
    }
}
