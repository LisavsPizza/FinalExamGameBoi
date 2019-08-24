using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheckIfCanPrint : MonoBehaviour {

    bool canPrint;
    public UnityEvent m_OnCanPrint;

	// Use this for initialization
	void Start () {
		if (m_OnCanPrint == null)
        {
            m_OnCanPrint = new UnityEvent();
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void CheckCanPrint()
    {

        if (GameObject.Find("Elias") != null)
        {
            GameObject.Find("DialogueCanvasDecorated").GetComponent<DialogueBox>().Show();
            GameObject.Find("DialogueCanvasDecorated").GetComponent<DialogueBox>().ChangeNode(456);
        }
        else
        {
            m_OnCanPrint.Invoke();
            GameObject.Find("ItemsScreen").GetComponent<Items>().RemoveItem("Fingerprinting Kit");
        }
    }

    public void DestroyElias()
    {
        Destroy(GameObject.Find("Elias"));
    }
}
