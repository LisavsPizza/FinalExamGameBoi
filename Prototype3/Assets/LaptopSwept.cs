using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaptopSwept : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
        if (GameObject.Find("ItemsScreen").GetComponent<Items>().CheckIfHasItem("Laptop"))
        {
            this.gameObject.SetActive(false);
        } else
        {
            this.gameObject.SetActive(true);
        }
	}

}
