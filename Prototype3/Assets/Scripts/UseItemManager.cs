using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UseItemManager : MonoBehaviour {

    public UnityEvent m_OnClicked;

    private static GameObject _itemInUse;
    private static GameObject _itemAppliedTo;
    private UnityEvent m_OriginalOnClickedEvent;

    // Use this for initialization
    void Start () {
        _itemInUse = null;
        _itemAppliedTo = null;

        if (m_OnClicked == null)
        {
            m_OnClicked = new UnityEvent();
        }

        m_OriginalOnClickedEvent = m_OnClicked;
    }
	
	// Update is called once per frame
	void Update () {
        if (_itemInUse != null)
        {
            print(_itemInUse.name);
        } else
        {
           // print("No item in use.");
        }

        if (_itemAppliedTo != null)
        {
            print(_itemAppliedTo.name);
        } else
        {
         //   print("No item applied to.");
        }
	}

    public void UseObject(GameObject applicableItem)
    {
        if (_itemInUse != null)
        {
            GameObject.Find("DialogueCanvasDecorated").GetComponent<DialogueBox>().Hide();
            _itemAppliedTo = applicableItem;
            m_OnClicked.Invoke();
            if (applicableItem.GetComponent<ApplicableItem>() != null && applicableItem.GetComponent<ApplicableItem>().IsAMatch())
            {
                _itemInUse = null;
            }
            ResetClickedEvent();
            GameObject.Find("FollowMouseSprite").GetComponent<MouseHoverSprite>().HideHoverSprite();
        }
    }

    public static GameObject GetItemInUse()
    {
        return _itemInUse;
    }

    public static GameObject GetApplicableItem()
    {
        return _itemAppliedTo;
    }

    public static void SetItemInUse(GameObject newUse)
    {
        if (newUse != null)
        {
            //GameObject.Find("DialogueCanvasDecorated").GetComponent<DialogueBox>().Show();
            //GameObject.Find("DialogueCanvasDecorated").GetComponent<DialogueBox>().ChangeNode(10);
            GameObject.Find("FollowMouseSprite").GetComponent<MouseHoverSprite>().ChangeHoverSprite(newUse.GetComponent<SpriteRenderer>().sprite);
        }
        _itemInUse = newUse;
    }

    public static void SetApplicableItem(GameObject newApplicable)
    {
        _itemAppliedTo = null;
    }

    public void SetItemInUseEvent(GameObject newUse)
    {
        if (newUse != null)
        {
            GameObject.Find("DialogueCanvasDecorated").GetComponent<DialogueBox>().Show();
            GameObject.Find("DialogueCanvasDecorated").GetComponent<DialogueBox>().ChangeNode(10);
        }
        _itemInUse = newUse;
    }

    public void ChangeOnClickedEvent(UnityEvent newClickedEvent)
    {
        m_OnClicked = newClickedEvent;
    }

    public void ResetClickedEvent()
    {
        m_OnClicked = m_OriginalOnClickedEvent;
    }
}
