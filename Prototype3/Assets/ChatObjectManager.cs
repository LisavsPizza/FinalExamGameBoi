using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatObjectManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SwitchToPersonSpeakingNode()
    {
      
            foreach (GameObject g in GameObject.FindGameObjectsWithTag("ChatObject"))
            {
            if (GameObject.Find(g.gameObject.name + "_ChatBot") != null)
            {
                if (GameObject.Find(g.gameObject.name + "_ChatBot").GetComponent<Chatbot>().CheckShowing())
                {
                    GameObject.Find("DialogueCanvasDecorated").GetComponent<DialogueBox>().SetSwitchNode(g.GetComponent<TalkingPerson>().GetSwitchNode());
                }
            }
            }
    }
}
