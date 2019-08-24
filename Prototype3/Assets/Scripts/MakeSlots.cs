using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeSlots : MonoBehaviour {

    public GameObject slot;

    public int columns;
    public int rows;
    public float gap;

	// Use this for initialization
	void Start () {
        Vector3 pos = this.transform.position;

        for (int j = 0; j < rows; j++)
        {
            for (int i = 0; i < columns; i++)
            {
                Instantiate(slot, pos, Quaternion.identity);
                pos.x += gap;
            }

            pos.x = this.transform.position.x;
            pos.y -= gap;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
