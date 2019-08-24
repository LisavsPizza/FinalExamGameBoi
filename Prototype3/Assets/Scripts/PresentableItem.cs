using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresentableItem : MonoBehaviour {

    private static GameObject currSelectedItem;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnMouseOver()
    {
        if (GameObject.Find("SatchelBG").GetComponent<SatchelScreen>().CheckPresentationMode())
        {

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                currSelectedItem = this.gameObject;

                if (TalkingPerson.GetCurrSpeakingPerson() != null)
                {
                    if (TalkingPerson.GetCurrSpeakingPerson().GetComponents<PresentablePerson>() != null)
                    {
                        bool foundMatch = false;
                        foreach (PresentablePerson p in TalkingPerson.GetCurrSpeakingPerson().GetComponents<PresentablePerson>())
                        {
                            if (p.CheckMatch())
                            {
                                foundMatch = true;
                            }
                        }

                        if (foundMatch == false)
                        {
                                GameObject.Find("DialogueCanvasDecorated").GetComponent<DialogueBox>().ChangeNode(12);
                                GameObject.Find("DialogueCanvasDecorated").GetComponent<DialogueBox>().Show();
                        }
                    }
                    GameObject.Find("SatchelBG").GetComponent<SatchelScreen>().SetPresentationMode(false);
                    GameObject.Find("DialogueCanvasDecorated").GetComponent<DialogueBox>().SetSwitchNode(TalkingPerson.GetCurrSpeakingPerson().GetComponent<TalkingPerson>().mySwitchNode);
                } else
                {
                }
            }
        }
    }

    public static GameObject GetCurrSelectedObject()
    {
        return currSelectedItem;
    }
}
