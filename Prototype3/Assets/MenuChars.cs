using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuChars : MonoBehaviour {

    public float speed;
    public float stopTime;
    public float buttonFadeAmount;

    private float _timer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        _timer += Time.deltaTime;

        if (_timer < stopTime)
        {
            Vector3 myPos = this.transform.position;
            myPos.z += speed * Time.deltaTime;
            this.transform.position = myPos;
        } else
        {
            GameObject canvas = GameObject.Find("Canvas");

            if (canvas != null)
            {
                for (int i = 0; i < canvas.transform.childCount; i++)
                {
                    GameObject currChild = canvas.transform.GetChild(i).gameObject;
                    Color buttonColour = currChild.GetComponent<Image>().color;
                    if (buttonColour.a < 1)
                    {
                        buttonColour.a += buttonFadeAmount;
                        currChild.GetComponent<Image>().color = buttonColour;
                    }

                    if (buttonColour.a >= 0.2f)
                    {
                        currChild.GetComponent<Button>().enabled = true;
                    }
                }
            }
        }
	}
}
