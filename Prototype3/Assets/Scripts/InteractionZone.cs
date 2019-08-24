using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractionZone : MonoBehaviour
{

    public UnityEvent m_OnClicked;
    private static bool _canInteract;

    private void Start()
    {
        if (m_OnClicked == null)
        {
            m_OnClicked = new UnityEvent();
        }
    }

    private void Update()
    {
        CheckIfCanInteract();
    }

    private void OnMouseOver()
    {
        GameObject interactionIndicator = Utilities.SearchChild("InteractionIndicator", this.gameObject);
        interactionIndicator.GetComponent<Light>().enabled = true;
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            AudioManager.PlaySound(Resources.Load("Equip") as AudioClip, 0.9f);
            m_OnClicked.Invoke();
        }
    }

    private void OnMouseEnter()
    {
        AudioManager.PlaySound(Resources.Load("InteractSound") as AudioClip, 0.9f);
    }

    private void OnMouseExit()
    {
        GameObject interactionIndicator = Utilities.SearchChild("InteractionIndicator", this.gameObject);
        interactionIndicator.GetComponent<Light>().enabled = false;
    }

    //private void OnMouseDown()
    //{
    //    m_OnClicked.Invoke();
    //}

    public static bool SetInteractionOn(bool on)
    {
        if (on)
        {
            _canInteract = true;
        }
        else
        {
            _canInteract = false;
        }

        return _canInteract;
    }

    private void CheckIfCanInteract()
    {
        BoxCollider myBoxCollider = this.GetComponent<BoxCollider>();

        if (_canInteract)
        {
            myBoxCollider.enabled = true;
        }
        else
        {
            myBoxCollider.enabled = false;
        }
    }


}
