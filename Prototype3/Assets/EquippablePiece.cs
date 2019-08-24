using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquippablePiece : MonoBehaviour {

    private Sprite _originalSprite;

	// Use this for initialization
	void Awake () {
        _originalSprite = this.GetComponent<SpriteRenderer>().sprite;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void EquipItem(Sprite item)
    {

        if (this.GetComponent<SpriteRenderer>().sprite != item)
        {
            this.GetComponent<SpriteRenderer>().sprite = item;
            EquipButton.ChangeEquipNode(11);
        }
        else
        {
            this.GetComponent<SpriteRenderer>().sprite = _originalSprite;
            EquipButton.ChangeEquipNode(9);
        }
    }
}
