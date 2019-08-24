using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ApplicableItem : MonoBehaviour {

    public string useItemName;
    public UnityEvent m_OnItemUsed;

    private bool _match;

	// Use this for initialization
	void Start () {
        _match = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnMouseEnter()
    {
        CheckMatch();
    }
    private void OnMouseOver()
    {
        CheckMatch();
    }

    private void OnMouseExit()
    {
        if (UseItemManager.GetItemInUse() != null)
        {
            GameObject.Find("UseItemManager").GetComponent<UseItemManager>().ResetClickedEvent();
        }
    }

    private void CheckMatch()
    {
        if (UseItemManager.GetItemInUse() != null)
        {
            UseItemManager sceneUseItemManager = GameObject.Find("UseItemManager").GetComponent<UseItemManager>();

            if (UseItemManager.GetItemInUse().name == useItemName)
            {
                sceneUseItemManager.ChangeOnClickedEvent(m_OnItemUsed);
                _match = true;
            }
            else
            {
                sceneUseItemManager.ResetClickedEvent();
                _match = false;
            }
        }
    }

    public bool IsAMatch()
    {
        return _match;
    }
}
