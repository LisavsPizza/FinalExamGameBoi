using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InventoryItem : MonoBehaviour
{
    public Sprite inventorySprite;

    public bool canEquip;
    public bool canHit;
    public bool canExamine;
    public bool canGo;
    public bool canTake;
    public bool canTalk;
    public bool canUse;
    public bool canOpen;

    public UnityEvent m_OnEquip;
    public UnityEvent m_OnHit;
    public UnityEvent m_OnExamine;
    public UnityEvent m_OnGo;
    public UnityEvent m_OnTake;
    public UnityEvent m_OnTalk;
    public UnityEvent m_OnUse;
    public UnityEvent m_OnOpen;

    private List<bool> _applicableButtons;

    public bool inInventory;

    private static bool _mouseOverInventoryItem;

    // Use this for initialization
    void Start()
    {
        _applicableButtons = new List<bool>();

        _applicableButtons.Add(canEquip);
        _applicableButtons.Add(canHit);
        _applicableButtons.Add(canExamine);
        _applicableButtons.Add(canGo);
        _applicableButtons.Add(canTake);
        _applicableButtons.Add(canTalk);
        _applicableButtons.Add(canUse);
        _applicableButtons.Add(canOpen);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseOver()
    {
        _mouseOverInventoryItem = true;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (inInventory)
            {
                Item.currSelectedItem = this.gameObject;
                ChangeCommandWheelEvents();
                GameObject.Find("CommandWheel").GetComponent<CommandWheel>().ChangeApplicableButtons(_applicableButtons);
            }
        }
    }

    private void OnMouseExit()
    {
        _mouseOverInventoryItem = false;
    }

    private void ChangeCommandWheelEvents()
    {
        GameObject commandWheel = GameObject.Find("CommandWheel");

        MyButtonCommand equip = Utilities.SearchChild("Equip", commandWheel).GetComponent<MyButtonCommand>();
        MyButtonCommand hit = Utilities.SearchChild("Hit", commandWheel).GetComponent<MyButtonCommand>();
        MyButtonCommand examine = Utilities.SearchChild("Examine", commandWheel).GetComponent<MyButtonCommand>();
        MyButtonCommand go = Utilities.SearchChild("Go", commandWheel).GetComponent<MyButtonCommand>();
        MyButtonCommand take = Utilities.SearchChild("Take", commandWheel).GetComponent<MyButtonCommand>();
        MyButtonCommand talk = Utilities.SearchChild("Talk", commandWheel).GetComponent<MyButtonCommand>();
        MyButtonCommand use = Utilities.SearchChild("Use", commandWheel).GetComponent<MyButtonCommand>();
        MyButtonCommand open = Utilities.SearchChild("Open", commandWheel).GetComponent<MyButtonCommand>();

        if (canEquip)
        {
            equip.SetClickedEvent(m_OnEquip);
        }
        else
        {
            equip.SetClickedEvent(new UnityEvent());
        }

        if (canHit)
        {
            hit.SetClickedEvent(m_OnHit);
        }
        else
        {
            hit.SetClickedEvent(new UnityEvent());
        }

        if (canExamine)
        {
            examine.SetClickedEvent(m_OnExamine);
        }
        else
        {
            examine.SetClickedEvent(new UnityEvent());
        }

        if (canGo)
        {
            go.SetClickedEvent(m_OnGo);
        }
        else
        {
            go.SetClickedEvent(new UnityEvent());
        }

        if (canTake)
        {
            take.SetClickedEvent(m_OnTake);
        }
        else
        {
            take.SetClickedEvent(new UnityEvent());
        }

        if (canTalk)
        {
            talk.SetClickedEvent(m_OnTalk);
        }
        else
        {
            talk.SetClickedEvent(new UnityEvent());
        }

        if (canUse)
        {
            use.SetClickedEvent(m_OnUse);
        }
        else
        {
            use.SetClickedEvent(new UnityEvent());
        }

        if (canOpen)
        {
            open.SetClickedEvent(m_OnOpen);
        }
        else
        {
            open.SetClickedEvent(new UnityEvent());
        }
    }
    
    public void SetInInventory(bool inInventory)
    {
        this.inInventory = inInventory;
    }

    public static bool MouseOverInventoryItem()
    {
        return _mouseOverInventoryItem;
    }
}
