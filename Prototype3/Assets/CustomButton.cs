using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CustomButton : MonoBehaviour
{
    public UnityEvent m_OnButtonDown;

    public Color onMouseOver;
    public Color onMouseDown;

    // Start is called before the first frame update
    void Start()
    {
        if (m_OnButtonDown == null)
        {
            m_OnButtonDown = new UnityEvent();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseOver()
    {
        this.GetComponent<SpriteRenderer>().color = onMouseOver;
    }

    private void OnMouseExit()
    {
        this.GetComponent<SpriteRenderer>().color = Color.white;
    }

    private void OnMouseDown()
    {
        this.GetComponent<SpriteRenderer>().color = onMouseDown;
        m_OnButtonDown.Invoke();
    }
}
