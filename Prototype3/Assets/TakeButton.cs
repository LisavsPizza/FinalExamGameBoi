using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeButton : MonoBehaviour {

    private static string _currScreen;
    private bool _firstTake;
    private bool _bypassTakeNode;
    private bool _returnToTakeNode;

    public int takeNodeItems;
    public int takeNodeArchives;
    public int takeNodeOutfit;

    public int firstTakeNode;

    private void Start()
    {
        _currScreen = "Items";
        _firstTake = false;
    }

    private void Update()
    {
      if (_returnToTakeNode)
        {
            CommandTakeDialogue();
            _returnToTakeNode = false;
        }
    }

    private void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (!_bypassTakeNode)
            {
                CommandTakeDialogue();
            }
        }
    }

    public static void SetCurrScreenAddingTo(string newCurrScreen)
    {
        _currScreen = newCurrScreen;
    }

    public static string GetCurrScreenAddingTo()
    {
        return _currScreen;
    }

    public void TakeExternally()
    {
        if (!_firstTake)
        {
            GameObject.Find("DialogueCanvasDecorated").GetComponent<DialogueBox>().SetSwitchNode(firstTakeNode);
            _firstTake = true;
        }

            CommandTakeDialogue();
    }

    public void BypassTakeNode(int newNode)
    {
        GameObject.Find("DialogueCanvasDecorated").GetComponent<DialogueBox>().ChangeNode(newNode);
        _bypassTakeNode = true;
    }

    public void ReturnToTakeNode()
    {
        _bypassTakeNode = false;
        _returnToTakeNode = true;
    }

    private void CommandTakeDialogue()
    {
        if (!_firstTake)
        {
            GameObject.Find("DialogueCanvasDecorated").GetComponent<DialogueBox>().SetSwitchNode(firstTakeNode);
            _firstTake = true;
        }

        GameObject.Find("DialogueCanvasDecorated").GetComponent<DialogueBox>().Show();

        if (_currScreen == "Items")
        {
            GameObject.Find("DialogueCanvasDecorated").GetComponent<DialogueBox>().ChangeNode(takeNodeItems);
        }
        else if (_currScreen == "Archives")
        {
            GameObject.Find("DialogueCanvasDecorated").GetComponent<DialogueBox>().ChangeNode(takeNodeArchives);
        }
        else if (_currScreen == "Outfit")
        {
            GameObject.Find("DialogueCanvasDecorated").GetComponent<DialogueBox>().ChangeNode(takeNodeOutfit);
        }
    }
}
