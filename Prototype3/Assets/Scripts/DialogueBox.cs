using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class DialogueBox : MonoBehaviour
{

    public int startingNode;
    public float typeTime;
    public Color mcColour;
    public Color renColour;
    public Color akaneColour;
    public Color daichiColour;

    private int _currNode;
    private List<GameObject> _myChildren = new List<GameObject>();
    private Dictionary<int, MainText> _nodeDictionary = new Dictionary<int, MainText>();
    private int _clickCounter;
    private bool _displayMainText;
    private float _typeTimer;
    private int _charNum;

    private GameObject _logContent;
    private int _switchNode;

    private string _mainLogText;
    private bool _canControlTextDisplay;
    private string _displayText;

    private bool _textFullyDisplayed;

    // Use this for initialization
    void Start()
    {
        _clickCounter = 2;
        _typeTimer = 0;
        _charNum = 0;
        _canControlTextDisplay = true;

        FindAndSortMainNodes();

        _currNode = startingNode;

        for (int i = 0; i < this.transform.childCount; i++)
        {
            _myChildren.Add(this.transform.GetChild(i).gameObject);
        }

        ChangeNode(_currNode);

        _switchNode = -1;
    }

    private void Update()
    {
        if (_nodeDictionary[_currNode].GetMainText() != null)
        {
            if (_canControlTextDisplay)
            {
                if (_displayText.Contains("INSERTOBJECTONE"))
                {
                    _displayText = _displayText.Replace("INSERTOBJECTONE", UseItemManager.GetItemInUse().name);
                }

                ControlOverallTextDisplay(_displayText);
            }

            _mainLogText = _displayText;

        }

        //print(MyName.GetName());

        if (IsShowing())
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (_clickCounter < 2)
                {
                    _clickCounter += 1;

                    if (_clickCounter == 1)
                    {
                        if (!SceneManager.GetActiveScene().name.Equals("Prologue"))
                        {
                            string logText = GameObject.Find("LogContent").GetComponent<Text>().text;
                            MainText myCurrNode = _nodeDictionary[_currNode];
                            logText += "\n" + myCurrNode.GetCurrCharacter() + ":";
                            logText += "\n" + _mainLogText + "\n";
                            GameObject.Find("LogContent").GetComponent<Text>().text = logText;
                        }
                    }
                }

                if (_clickCounter == 2)
                {
                    MainText currNode = _nodeDictionary[_currNode];

                    if (currNode.HasChoice() == false)
                    {
                        currNode.InvokeOnClickedEvent();
                    }
                }
            }
        }

        MyButton returnButton = null;

        if (GameObject.Find("BackArrow") != null)
        {
            returnButton = GameObject.Find("BackArrow").GetComponent<MyButton>();
        }

        if (returnButton != null)
        {
            if (IsShowing())
            {
                InteractionZone.SetInteractionOn(false);
                if (returnButton != null)
                {
                    returnButton.Hide();
                }
            }
            else
            {
                InteractionZone.SetInteractionOn(true);
                if (returnButton != null && GameObject.Find("Classroom") != null && GameObject.Find("Classroom").GetComponent<SpriteRenderer>().color.a < 1)
                {
                    returnButton.Show();
                }
            }
        }

        if (GameObject.Find("Classroom") != null && GameObject.Find("Classroom").GetComponent<SpriteRenderer>().color.a == 1)
        {
            if (returnButton != null)
            {
                returnButton.Hide();
            }
        }
    }

    public void FindAndSortMainNodes()
    {
        foreach (GameObject currentNode in GameObject.FindGameObjectsWithTag("Main"))
        {
            int nodeNum = int.Parse(Utilities.SearchChild("NodeNum", currentNode).GetComponent<Text>().text);
            _nodeDictionary.Add(nodeNum, currentNode.GetComponent<MainText>());
        }
    }

    public void ChangeNode(int nodeNum)
    {

        _currNode = nodeNum;
        MainText currNode = _nodeDictionary[_currNode];

        string myText = _nodeDictionary[_currNode].GetMainText();
        _canControlTextDisplay = false;

        if (UseItemManager.GetItemInUse() != null)
        {
            if (myText.Contains("INSERTOBJECTONE") && myText.Contains("INSERTOBJECTTWO"))
            {
                myText = myText.Replace("INSERTOBJECTONE", UseItemManager.GetItemInUse().name);
                myText = myText.Replace("INSERTOBJECTTWO", UseItemManager.GetApplicableItem().name);

                if (UseItemManager.GetApplicableItem().GetComponent<TalkingPerson>() != null)
                {
                    myText = " If you want to show an item to this person, try talking to them and PRESENTING it.";
                }

                UseItemManager.SetItemInUse(null);
                UseItemManager.SetApplicableItem(null);
            }
            else if (myText.Contains("INSERTOBJECTONE"))
            {
                myText = myText.Replace("INSERTOBJECTONE", UseItemManager.GetItemInUse().name);
            }
            else if (UseItemManager.GetApplicableItem() != null)
            {
                if (myText.Contains("INSERTOBJECTTWO"))
                {
                    myText = myText.Replace("INSERTOBJECTTWO", UseItemManager.GetApplicableItem().name);

                    if (UseItemManager.GetApplicableItem().GetComponent<TalkingPerson>() != null)
                    {
                        myText = " If you want to show an item to this person, try talking to them and PRESENTING it.";
                    }
                }

            }
        }
        else if (myText.Contains("CURRSELECTEDOBJECT"))
        {
            if (Item.currSelectedItem != null)
            {
                myText = myText.Replace("CURRSELECTEDOBJECT", Item.currSelectedItem.name);
            }
        }
        else if (myText.Contains("CURRTALKINGPERSON"))
        {
            if (TalkingPerson.GetCurrSpeakingPerson() != null)
            {
                myText = myText.Replace("CURRTALKINGPERSON", TalkingPerson.GetCurrSpeakingPerson().name);
            }
        }
        _displayText = myText;
        _canControlTextDisplay = true;

        if (_nodeDictionary.ContainsKey(nodeNum))
        {

            string currSpeakingCharacter = currNode.GetCurrCharacter();

            if (currSpeakingCharacter.Equals("Kat") || currSpeakingCharacter.Equals("?")|| GameObject.Find(currNode.GetCurrCharacter()) != null || currSpeakingCharacter == "Narrator")
            {
                Show();
                currNode.InvokeOnShownEvent();
            } else
            {
                Hide();
                print("!!!SPEAKING CHARACTER IS NOT IN THE SCENE");
            }

            if (currNode.HasChoice())
            {
                int numChoices = currNode.GetChoiceList().Count;

                for (int i = 0; i < numChoices; i++)
                {
                    GameObject currChoice = Utilities.SearchChild("ChoiceButton" + i, this.gameObject);
                    ModifyChoice(i, currChoice, currNode);
                }

                //if (currChild.name.Equals("ChoiceButton0"))
                //{
                //    ModifyChoice(0, currChild, currNode);
                //}
                //else if (currChild.name.Equals("ChoiceButton1"))
                //{
                //    ModifyChoice(1, currChild, currNode);
                //}
                //else if (currChild.name.Equals("ChoiceButton2"))
                //{
                //    ModifyChoice(2, currChild, currNode);
                //}
            }

            foreach (GameObject currChild in _myChildren)
            {
                if (currChild.name.Equals("CurrentCharacterText"))
                {
                    currChild.GetComponent<Text>().text = currNode.GetCurrCharacter();
                }


                if (currChild.name.Equals("MainText"))
                {
                    currChild.GetComponent<Text>().text = "";
                    _displayMainText = true;
                    //    currChild.GetComponent<Text>().text = "";
                    //    string mainText = currChild.GetComponent<Text>().text;
                    //    string changeText = currNode.GetMainText();
                    //    foreach (char c in changeText.ToCharArray())
                    //    {
                    //        mainText += c.ToString();
                    //        currChild.GetComponent<Text>().text = mainText;
                    //    }

                    //    //currChild.GetComponent<Text>().text = currNode.GetMainText();
                }
            }
           
        }
    }

    public void Show()
    {
        if (GameObject.Find("MapButton") != null)
        {
            GameObject.Find("MapButton").GetComponent<MyUIFade>().FadeOut();
        }

        if (GameObject.Find("WrightControlsUI") != null)
        {
        Utilities.SearchChild("Controls", GameObject.Find("WrightControlsUI")).GetComponent<ControlsImage>().SwitchModeDialogueShowing(true);
            }

        int numChoices = _nodeDictionary[_currNode].GetChoiceList().Count;

        if (_nodeDictionary[_currNode].HasChoice())
        {
            for (int i = 0; i < numChoices; i++)
            {
                GameObject currChoice = Utilities.SearchChild("ChoiceButton" + i, this.gameObject);
                currChoice.SetActive(true);
            }
        }

        foreach (GameObject currChild in _myChildren)
        {
            if (!currChild.name.Contains("Choice"))
            {
                currChild.SetActive(true);
            } else if (!_nodeDictionary[_currNode].HasChoice())
            {
                currChild.SetActive(false);
            }

        }
    }

    public void Hide()
    {

        if (GameObject.Find("DialogueSystemWright") != null)
        {
            if (!GameObject.Find("DialogueSystemWright").GetComponent<DialogueSystemWright>().IsVisible())
            {
                if (GameObject.Find("MapButton") != null)
                {
                    GameObject.Find("MapButton").GetComponent<MyUIFade>().FadeIn();
                }
            }
        }


        if (GameObject.Find("WrightControlsUI") != null)
        {
            Utilities.SearchChild("Controls", GameObject.Find("WrightControlsUI")).GetComponent<ControlsImage>().SwitchModeDialogueShowing(false);
        }

        Utilities.SearchChild("BackgroundImage", this.gameObject).GetComponent<Image>().enabled = true;
        Utilities.SearchChild("CurrentCharacterImage", this.gameObject).GetComponent<Image>().enabled = true;
        Utilities.SearchChild("CurrentCharacterText", this.gameObject).GetComponent<Text>().enabled = true;

        foreach (GameObject currChild in _myChildren)
        {
            currChild.SetActive(false);
        }

        _clickCounter = 0;
    }

    private void ModifyChoice(int choiceNum, GameObject choiceGO, MainText currentNode)
    {
        Choice currChoice = currentNode.GetChoiceList()[choiceNum];

        choiceGO.transform.GetChild(0).GetComponent<Text>().text = currChoice.GetChoiceText();
        choiceGO.GetComponent<ChoiceButton>().SetOnPressedEvent(currChoice.GetOnChosenEvent());
        choiceGO.GetComponent<ChoiceButton>().SetMyChoice(currChoice);

        if (currChoice.CheckSeen())
        {
            choiceGO.GetComponent<Image>().color = Color.cyan;
        } else
        {
            choiceGO.GetComponent<Image>().color = Color.white;
        }
    }

    public bool IsShowing()
    {
        bool visible = false;

        foreach (GameObject currChild in _myChildren)
        {
            if (currChild.activeInHierarchy)
            {
                visible = true;
            }
        }

        return visible;
    }

    private void ControlMainTextDisplay(string displayText)
    {
        if (_displayMainText)
        {
            GameObject mainTextButton = Utilities.SearchChild("MainText", this.gameObject);

            if (displayText.Contains("("))
            {
                mainTextButton.GetComponent<Text>().color = new Color32 (133, 214, 241, 255);
                mainTextButton.GetComponent<Text>().fontStyle = FontStyle.Normal;
            } else
            {
                mainTextButton.GetComponent<Text>().color = Color.white;
                mainTextButton.GetComponent<Text>().fontStyle = FontStyle.Normal;
            }

            if (Utilities.SearchChild("CurrentCharacterText", this.gameObject).GetComponent<Text>().text == "Narrator")
            {
                Utilities.SearchChild("CurrentCharacterText", this.gameObject).GetComponent<Text>().color = Color.clear;
                mainTextButton.GetComponent<Text>().color = new Color32(69, 164, 71, 255);
                mainTextButton.GetComponent<Text>().fontStyle = FontStyle.Italic;
            } else
            {
                Utilities.SearchChild("CurrentCharacterText", this.gameObject).GetComponent<Text>().color = Color.white;
            }

            _typeTimer += Time.deltaTime;

            string mainText = mainTextButton.GetComponent<Text>().text;

            List<char> myChars = displayText.ToCharArray().ToList<char>();

            if (myChars != null)
            {
                if (_typeTimer >= typeTime)
                {
                    mainText += myChars[_charNum].ToString();
                    mainTextButton.GetComponent<Text>().text = mainText;
                    _charNum++;
                    _typeTimer = 0.0f;
                }

                if (_charNum == myChars.Count)
                {
                    _textFullyDisplayed = true;
                    _displayMainText = false;
                    _typeTimer = 0.0f;
                    _charNum = 0;
                } else
                {
                    _textFullyDisplayed = false;
                }

                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    _textFullyDisplayed = true;
                    _clickCounter = 0;
                    mainTextButton.GetComponent<Text>().text = displayText;
                    _displayMainText = false;
                    _typeTimer = 0.0f;
                    _charNum = 0;
                }
            }
        }
    }

    public void SwitchNode()
    {

        if (_switchNode != -1)
        {
            ChangeNode(_switchNode);
            Show();

        } else
        {
            Hide();
        }

        _switchNode = -1;
    }

    public void SetSwitchNode(int num)
    {
        _switchNode = num;
    }

    private void ControlOverallTextDisplay(string myText)
    {
        if (myText == "")
        {
            Utilities.SearchChild("BackgroundImage", this.gameObject).GetComponent<Image>().enabled = false;
            Utilities.SearchChild("CurrentCharacterImage", this.gameObject).GetComponent<Image>().enabled = false;
            Utilities.SearchChild("CurrentCharacterText", this.gameObject).GetComponent<Text>().enabled = false;
        }
        else
        {
            Utilities.SearchChild("BackgroundImage", this.gameObject).GetComponent<Image>().enabled = true;
            Utilities.SearchChild("CurrentCharacterImage", this.gameObject).GetComponent<Image>().enabled = true;
            Utilities.SearchChild("CurrentCharacterText", this.gameObject).GetComponent<Text>().enabled = true;

            ControlMainTextDisplay(myText);
        }
    }

    public void ChangeCurrNodeEvent(UnityEvent newOnClickedEvent)
    {
        if (IsShowing())
        {
            _nodeDictionary[_currNode].GetComponent<MainText>().ChangeOnClickedEvent(newOnClickedEvent);
        }
    }

    public bool MainTextIsFullyDisplayed()
    {
        return _textFullyDisplayed;
    }

    public void TestPrint()
    {
        Debug.Log("THIS BE THE TEST PRINT FROM THE MAIN DIALOGUE BOX");
    }
}
