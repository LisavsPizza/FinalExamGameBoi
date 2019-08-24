using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextLog : MonoBehaviour {

    public Sprite logOpenSprite;

    private GameObject _logContent;
    private GameObject _scrollView;
    private GameObject _viewPort;
    private GameObject _scrollbarVertical;

    private bool _hidDialogueBoxFromHere;
    private bool _isVisible;

    // Use this for initialization
    void Start()
    {

        _logContent = GameObject.Find("LogContent");
        _scrollView = GameObject.Find("Scroll View");
        _viewPort = GameObject.Find("Viewport");
        _scrollbarVertical = GameObject.Find("Scrollbar Vertical");

        Hide();
        _hidDialogueBoxFromHere = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (_isVisible)
        {
            GameObject.Find("CommandWheel").GetComponent<CommandWheel>().SetCanClick(false);
        }

        if (_hidDialogueBoxFromHere)
        {
            Utilities.SearchChild("Controls", GameObject.Find("WrightControlsUI")).GetComponent<ControlsImage>().SwitchModeDialogueShowing(true);
        }
    }

    public void Hide()
    {
        GameObject.Find("CommandWheel").GetComponent<CommandWheel>().SetCanClick(true);

        _scrollView.GetComponent<Image>().enabled = false;
        _scrollView.GetComponent<ScrollRect>().enabled = false;
        _viewPort.GetComponent<Image>().enabled = false;
        _viewPort.GetComponent<Mask>().enabled = false;
        _logContent.GetComponent<Text>().color = Color.clear;
        _scrollbarVertical.SetActive(false);
        Utilities.SearchChild("CloseButton", this.gameObject).SetActive(false);

        if (_hidDialogueBoxFromHere)
        {
            GameObject.Find("DialogueCanvasDecorated").GetComponent<DialogueBox>().Show();
            _hidDialogueBoxFromHere = false;
        }

        _isVisible = false;
    }

    public void Show()
    {

        GameObject.Find("SatchelBG").GetComponent<SatchelScreen>().Hide();
        GameObject.Find("CommandWheel").GetComponent<CommandWheel>().Hide();
        GameObject.Find("CommandWheel").GetComponent<CommandWheel>().SetCanClick(false);

        _scrollView.GetComponent<Image>().enabled = true;
        _scrollView.GetComponent<ScrollRect>().enabled = true;
        _viewPort.GetComponent<Image>().enabled = true;
        _viewPort.GetComponent<Mask>().enabled = true;
        _logContent.GetComponent<Text>().color = Color.white;
        _scrollbarVertical.SetActive(true);
        _scrollView.GetComponent<ScrollRect>().verticalNormalizedPosition = 0;

        Utilities.SearchChild("CloseButton", this.gameObject).SetActive(true);

        if (GameObject.Find("DialogueCanvasDecorated").GetComponent<DialogueBox>().IsShowing())
        {
            _hidDialogueBoxFromHere = true;
            GameObject.Find("DialogueCanvasDecorated").GetComponent<DialogueBox>().Hide();
        }

        _isVisible = true;
    }

    public void ControlVisibility()
    {
        if (_scrollView.GetComponent<Image>().enabled)
        {
            Hide();
        } else
        {
            Show();
        }
    }

    public bool CheckHidDialogueBoxFromHere()
    {
        return _hidDialogueBoxFromHere;
    }
}
