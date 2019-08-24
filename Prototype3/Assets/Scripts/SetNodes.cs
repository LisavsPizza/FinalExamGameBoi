using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
[ExecuteInEditMode]

public class SetNodes : MonoBehaviour {

    // Use this for initialization
    void Start () {

        for (int i = 0; i < this.transform.childCount; i++)
        {
            GameObject currChild = this.transform.GetChild(i).gameObject;
            currChild.name = "Main_" + i;
            Utilities.SearchChild("NodeNum", currChild).GetComponent<Text>().text = i.ToString();
        }
	}
}
