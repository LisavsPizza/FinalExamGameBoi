using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Item : MonoBehaviour
{

    public static GameObject currSelectedItem;

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

    public bool _canHueShift = true;

    private List<bool> _applicableButtons;
    private bool _fadeHue;

    private bool _fadeToBlue;
    private bool _resetToWhite;

    // Use this for initialization
    void Start()
    {
        ResetApplicableButtons();
        _fadeToBlue = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (_canHueShift)
        {
            if (Input.GetKeyDown(KeyCode.LeftControl)|| Input.GetKeyDown(KeyCode.RightControl)|| Input.GetKeyDown(KeyCode.LeftCommand) || Input.GetKeyDown(KeyCode.RightCommand))
            {
                _fadeHue = true;
                _resetToWhite = false;
            }

            if (_fadeHue)
            {

                if (_fadeToBlue)
                {
                    this.GetComponent<SpriteRenderer>().color = Color.Lerp(this.GetComponent<SpriteRenderer>().color, Color.blue, 0.02f);
                    print(this.GetComponent<SpriteRenderer>().color.r + "RCOLOUR");
                    if (this.GetComponent<SpriteRenderer>().color.r <= 0.3f)
                    {
                        _fadeToBlue = false;
                    }
                }
                else
                {
                    this.GetComponent<SpriteRenderer>().color = Color.Lerp(this.GetComponent<SpriteRenderer>().color, Color.white, 0.03f);
                    if (this.GetComponent<SpriteRenderer>().color.r >= 0.9f)
                    {
                        _fadeToBlue = true;
                    }
                }

                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    _fadeHue = false;
                    _resetToWhite = true;
                }
            }

            if (_resetToWhite)
            {
                this.GetComponent<SpriteRenderer>().color = Color.Lerp(this.GetComponent<SpriteRenderer>().color, Color.white, 0.03f);
            }
        }
    }

    private void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            currSelectedItem = this.gameObject;
            ChangeCommandWheelEvents();
            GameObject.Find("CommandWheel").GetComponent<CommandWheel>().ChangeApplicableButtons(_applicableButtons);

            if (GameObject.Find("CommandWheel").GetComponent<CommandWheel>().CanClick())
            {
                GameObject.Find("UseItemManager").GetComponent<UseItemManager>().UseObject(this.gameObject);
            }
        }
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

    public void ChangeApplicableButton(string button)
    {
        if (button.Equals("Equip"))
        {
            canEquip = !canEquip;
        }
        else if (button.Equals("Hit"))
        {
            canHit = !canHit;
        }
        else if (button.Equals("Examine"))
        {
            canExamine = !canExamine;
        }
        else if (button.Equals("Go"))
        {
            canGo = !canGo;
        }
        else if (button.Equals("Take"))
        {
            canTake = !canTake;
        }
        else if (button.Equals("Talk"))
        {
            canTalk = !canTalk;
        }
        else if (button.Equals("Use"))
        {
            canUse = !canUse;
        }
        else if (button.Equals("Open"))
        {
            canOpen = !canOpen;
        }

        ResetApplicableButtons();
    }

    public void ChangeApplicableButtonTrue(string button)
    {
        if (button.Equals("Equip"))
        {
            canEquip = true;
        }
        else if (button.Equals("Hit"))
        {
            canHit = true;
        }
        else if (button.Equals("Examine"))
        {
            canExamine = true;
        }
        else if (button.Equals("Go"))
        {
            canGo = true;
        }
        else if (button.Equals("Take"))
        {
            canTake = true;
        }
        else if (button.Equals("Talk"))
        {
            canTalk = true;
        }
        else if (button.Equals("Use"))
        {
            canUse = true;
        }
        else if (button.Equals("Open"))
        {
            canOpen = true;
        }

        ResetApplicableButtons();
    }

    private void ResetApplicableButtons()
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

    public void UpdateItem(int num)
    {
        List<GameObject> allObjects = new List<GameObject>();
        allObjects.Add(this.gameObject);

        for (int i = 0; i < this.transform.childCount; i++)
        {
            allObjects.Add(this.gameObject.transform.GetChild(i).gameObject);
        }

        GameObject update = Utilities.SearchChild(num + "_Update", this.gameObject);
        update.SetActive(true);
        update.name = this.name;
        update.transform.parent = this.transform.parent;

        foreach (GameObject g in allObjects)
        {
            if (g != update)
            {
                g.transform.SetParent(update.transform);
            }
        }

        Destroy(this.gameObject);
    }

    public void HueShift()
    {
        _fadeHue = true;
    }
}
