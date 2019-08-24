using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour {

    // Use this for initialization
    public bool setSlotNames;

	void Start () {

        if (setSlotNames)
        {
            SetSlotNames();
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddItemAtNearestSlot(GameObject item)
    {
        if (item != null)
        {
            bool added = false;
            for (int i = 0; i < this.transform.childCount; i++)
            {
                if (added == false)
                {
                    GameObject currChild = this.transform.GetChild(i).gameObject;
                    if (currChild.name.Contains("Slot_"))
                    {
                        SetCurrAddingToScreen();
                        Item.currSelectedItem = item;
                        currChild.GetComponent<Slot>().AddItem(item);
                        added = true;
                        GameObject.Find("Take").GetComponent<TakeButton>().TakeExternally();
                    }
                }
            }

            GameObject.Find("AddImageAnimator").GetComponent<ImageAddimation>().PlayAddItemAnimation(item.GetComponent<InventoryItem>().inventorySprite);
        } else
        {
            GameObject.Find("DialogueCanvasDecorated").GetComponent<DialogueBox>().Show();
            GameObject.Find("DialogueCanvasDecorated").GetComponent<DialogueBox>().ChangeNode(19);
        }
    }

    public void RemoveItem(string name)
    {
        GameObject itemToRemove = null;

        for (int i = 0; i < this.transform.childCount; i++)
        {
            GameObject currChild = this.transform.GetChild(i).gameObject;
            if (currChild.name == name)
            {
                itemToRemove = currChild;
            }
        }
        if (itemToRemove != null)
        {
            itemToRemove.GetComponent<Slot>().RemoveItem();
        }
        SortSlots();
    }

    private void SetSlotNames()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            GameObject currChild = this.transform.GetChild(i).gameObject;
            currChild.name = "Slot_" + i;
        }
    }

    private void SortSlots()
    {
        GameObject previousChild = null;

        for (int i = 0; i < this.transform.childCount; i++)
        {
            GameObject currChild = this.transform.GetChild(i).gameObject;

            if (i-1 >= 0)
            {
                previousChild = this.transform.GetChild(i - 1).gameObject;
            }

            if (!currChild.name.Contains("Slot_"))
            {
                if (previousChild!=null)
                {
                    if (previousChild.name.Contains("Slot_"))
                    {
                        Vector3 currChildPos = currChild.transform.position;

                        currChild.transform.position = previousChild.transform.position;
                        currChild.transform.SetSiblingIndex(i - 1);

                        previousChild.transform.position = currChildPos;
                        previousChild.transform.SetSiblingIndex(i);
                    }
                }
            }
        }
    }

    private void SetCurrAddingToScreen()
    {
        if (this.name.Contains("Items"))
        {
            TakeButton.SetCurrScreenAddingTo("Items");
            AudioManager.PlaySound(Resources.Load("Equip") as AudioClip);
        }
        else if (this.name.Contains("Archives"))
        {
            TakeButton.SetCurrScreenAddingTo("Archives");
            AudioManager.PlaySound(Resources.Load("Writing") as AudioClip);
        }
        else if (this.name.Contains("Outfit"))
        {
            TakeButton.SetCurrScreenAddingTo("Outfit");
            AudioManager.PlaySound(Resources.Load("Equip") as AudioClip);
        }
    }

    public bool CheckIfHasItem(string name)
    {
        GameObject itemToSearch = null;
        bool hasItem = false;

        for (int i = 0; i < this.transform.childCount; i++)
        {
            GameObject currChild = this.transform.GetChild(i).gameObject;
            if (currChild.name == name)
            {
                itemToSearch = currChild;
            }
        }
        if (itemToSearch != null)
        {
            hasItem = true;
        }

        return hasItem;
    }
}
