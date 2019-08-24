using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SatchelScreen : MonoBehaviour {

    public Sprite satchelOpenSprite;

    private bool _isVisible;
    private GameObject _currScreen;

    private List<GameObject> myScreens = new List<GameObject>();
    private bool _isPresentationMode;

    private Sprite _originalButtonSprite;

    private int _afterPresentationNode;

	// Use this for initialization
	void Start () {
       
        myScreens.Add(Utilities.SearchChild("ItemsScreen", this.gameObject));
        myScreens.Add(Utilities.SearchChild("ArchivesScreen", this.gameObject));
        myScreens.Add(Utilities.SearchChild("OutfitScreen", this.gameObject));

        _currScreen = GetScreenByName("ItemsScreen");

        Hide();

        _isPresentationMode = false;
    }
	
	// Update is called once per frame
	void Update () {

        print("IS PRESENTATION: " + _isPresentationMode);

        if (_isVisible)
        {
            if (InventoryItem.MouseOverInventoryItem())
            {
                GameObject.Find("CommandWheel").GetComponent<CommandWheel>().SetCanClick(true);
            }
            else
            {
                GameObject.Find("CommandWheel").GetComponent<CommandWheel>().SetCanClick(false);
            }
        }
    }

    public void Hide()
    {
        this.GetComponent<SpriteRenderer>().enabled = false;

        for (int i = 0; i < this.transform.childCount; i++)
        {
            GameObject currChild = this.gameObject.transform.GetChild(i).gameObject;

            if (currChild.GetComponent<SpriteRenderer>()!=null)
            {
                currChild.GetComponent<SpriteRenderer>().enabled = false;
            } else
            {
                currChild.SetActive(false);
            }

            if (currChild.GetComponent<BoxCollider>() != null)
            {
                currChild.GetComponent<BoxCollider>().enabled = false;
            }
        }

        _isVisible = false;
        _currScreen = GetScreenByName("ItemsScreen");
        _isPresentationMode = false;

        Debug.Log("SOMETHING HID THE SATCHEL SCREEN");
    }

    public void Show()
    {
        GameObject.Find("CommandWheel").GetComponent<CommandWheel>().Hide();
        this.GetComponent<FileTabManager>().SetCurrSelected(this.transform.GetChild(0).gameObject);

        if (!GameObject.Find("DialogueCanvasDecorated").GetComponent<DialogueBox>().IsShowing())
        {
            GameObject.Find("TextLog").GetComponent<TextLog>().Hide();

                this.GetComponent<SpriteRenderer>().enabled = true;

                for (int i = 0; i < this.transform.childCount; i++)
                {
                    GameObject currChild = this.gameObject.transform.GetChild(i).gameObject;

                    if (currChild.GetComponent<SpriteRenderer>() != null)
                    {
                        currChild.GetComponent<SpriteRenderer>().enabled = true;

                    }
                    else
                    {
                        if (currChild = _currScreen)
                        {
                            currChild.SetActive(true);
                        }
                    }

                    if (currChild.GetComponent<BoxCollider>() != null)
                    {
                        currChild.GetComponent<BoxCollider>().enabled = true;
                    }

                }

                _isVisible = true;
        }
    }

    public void ControlVisibility()
    {
        if (_isVisible)
        {
            if (_isPresentationMode)
            {
                GameObject.Find("SatchelBG").GetComponent<SatchelScreen>().SetPresentationMode(false);
            } else
            {
                Hide();
                GameObject.Find("CommandWheel").GetComponent<CommandWheel>().SetCanClick(true);
            }
        } else
        {
            Show();
        }
    }

    public void ControlVisibilityForTabAndXButton()
    {
        if (_isVisible)
        {
            if (_isPresentationMode)
            {
                GameObject.Find("SatchelBG").GetComponent<SatchelScreen>().SetPresentationMode(false);
                GameObject.Find("DialogueCanvasDecorated").GetComponent<DialogueBox>().ChangeNode(_afterPresentationNode);
                GameObject.Find("DialogueSystemWright").GetComponent<DialogueSystemWright>().Show();
            }
            else
            {
                Hide();
                GameObject.Find("CommandWheel").GetComponent<CommandWheel>().SetCanClick(true);
            }
        }
        else
        {
            Show();
        }
    }

    private GameObject GetScreenByName(string screenName)
    {
        GameObject returnScreen = null;

        foreach (GameObject g in myScreens)
        {
            if (g.name == screenName)
            {
                returnScreen = g;
            }
        }

        return returnScreen;
    }

    public void ChangeScreen(string screenName)
    {
        _currScreen.SetActive(false);
        _currScreen = GetScreenByName(screenName);
        _currScreen.SetActive(true);
    }

    public void SetPresentationMode(bool isPresentation)
    {
        if (isPresentation)
        {
            foreach (GameObject g in GameObject.FindGameObjectsWithTag("Slot"))
            {
                if (g.GetComponent<InventoryItem>() != null)
                {
                    g.GetComponent<InventoryItem>().enabled = false;
                }

                if (g.GetComponent<PresentableItem>() != null)
                {
                    GetComponent<PresentableItem>().enabled = true;
                }
            }
            Show();
            _isPresentationMode = true;
        } else
        {
            foreach (GameObject g in GameObject.FindGameObjectsWithTag("Slot"))
            {
                if (g.GetComponent<InventoryItem>() != null)
                {
                    g.GetComponent<InventoryItem>().enabled = true;
                    
                }

                if (g.GetComponent<PresentableItem>() != null)
                {
                    g.GetComponent<PresentableItem>().enabled = false;
                }
            }
            GameObject.Find("DialogueCanvasDecorated").GetComponent<DialogueBox>().Show();
            GameObject.Find("DialogueSystemWright").GetComponent<DialogueSystemWright>().HideTemporarily();
            Hide();
            _isPresentationMode = false;
        }
    }

    public bool CheckPresentationMode()
    {
        return _isPresentationMode;
    }

    public bool IsShowing()
    {
        return _isVisible;
    }

    public void ChangeAfterPresentingNode(int newNode)
    {
        _afterPresentationNode = newNode;
    }
}
