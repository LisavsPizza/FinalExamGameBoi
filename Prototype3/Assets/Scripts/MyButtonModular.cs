using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class MyButtonModular : MonoBehaviour {

    public Material selected;
    public Material unselected;

    public UnityEvent m_OnClicked;
    // Use this for initialization
    void Start()
    {
        if (m_OnClicked == null)
        {
            m_OnClicked = new UnityEvent();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }


        private void OnMouseOver()
    {
        print("PICKED UP");

        this.GetComponent<Renderer>().material = selected;
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            m_OnClicked.Invoke();
        }
    }

    private void OnMouseExit()
    {
        this.GetComponent<Renderer>().material = unselected;
    }
}
