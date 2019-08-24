using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipButton : MonoBehaviour {

    private static int equipNode;

    private void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject.Find("DialogueCanvasDecorated").GetComponent<DialogueBox>().Show();
            GameObject.Find("DialogueCanvasDecorated").GetComponent<DialogueBox>().ChangeNode(equipNode);
        }
    }

    public static void ChangeEquipNode(int newNode)
    {
        equipNode = newNode;
    }
}
