using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Slot : MonoBehaviour {

    private string _originalName;
    private Sprite _originalSprite;

	// Use this for initialization
	void Awake () {
        _originalName = this.gameObject.name;
        _originalSprite = this.GetComponent<SpriteRenderer>().sprite;
    }
	
	// Update is called once per frame
	void Update () {
	}

    public void AddItem(GameObject item)
    {
        if (this.gameObject.GetComponent<InventoryItem>()!=null)
        {
            Destroy(this.gameObject.GetComponent<InventoryItem>(), 0.1f);
        }

        this.name = item.name;

        SpriteRenderer mySprite = this.GetComponent<SpriteRenderer>();
        mySprite.sprite = item.GetComponent<InventoryItem>().inventorySprite;
        mySprite.color = Color.white;

        InventoryItem newInventoryItem = item.GetComponent<InventoryItem>();
        //newInventoryItem.inInventory = true;

        this.gameObject.AddComponent(newInventoryItem.GetType());
        this.gameObject.AddComponent<PresentableItem>();

        System.Reflection.FieldInfo[] fields = newInventoryItem.GetType().GetFields();
        foreach (System.Reflection.FieldInfo field in fields)
        {
            field.SetValue(this.GetComponent(newInventoryItem.GetType()), field.GetValue(newInventoryItem));
        }

        this.gameObject.GetComponent<InventoryItem>().SetInInventory(true);
        this.gameObject.GetComponent<PresentableItem>().enabled = false;
        Destroy(item, 0.1f);
    }

    public void RemoveItem()
    {
        if (this.gameObject.GetComponent<InventoryItem>() != null)
        {
            Destroy(this.gameObject.GetComponent<InventoryItem>(), 0.1f);
        }
        if (this.gameObject.GetComponent<PresentableItem>() != null)
        {
            Destroy(this.gameObject.GetComponent<PresentableItem>(), 0.1f);
        }

        this.gameObject.name = _originalName;

        SpriteRenderer mySprite = this.GetComponent<SpriteRenderer>();
        mySprite.sprite = _originalSprite;
        mySprite.color = Color.clear;
    }

    public void SetAsInventoryItemInUse()
    {
        UseItemManager.SetItemInUse(this.gameObject);
    }
}
