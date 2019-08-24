using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseButton : MonoBehaviour {

    private static bool _useButtonClicked;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            UseItemManager.SetItemInUse(Item.currSelectedItem);
            GameObject.Find("SatchelBG").GetComponent<SatchelScreen>().Hide();
        }
    }

    public static void SetUseButtonClicked (bool clicked)
    {
        _useButtonClicked = clicked;
    }

    public static bool GetUseButtonClicked()
    {
        return _useButtonClicked;
    }

   

    }
