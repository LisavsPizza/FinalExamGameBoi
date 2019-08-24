using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyFilledImage : MonoBehaviour {
    public float fillAmount = 0.1f;

    private bool _fillUp;
    private bool _empty;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if (_fillUp && this.transform.parent.GetComponent<Image>().color.a >= 0.2f)
        {
            if (this.GetComponent<Image>().fillAmount < 1)
            {
                this.GetComponent<Image>().fillAmount += fillAmount;
            } else
            {
                _fillUp = false;
            }
        } else if (_empty && this.transform.parent.GetComponent<Image>().color.a >= 0.2f)
        {
                if (this.GetComponent<Image>().fillAmount > 0)
                {
                    this.GetComponent<Image>().fillAmount -= fillAmount;
                }
                else
                {
                    _fillUp = false;
                }
        }
	}

    public void FillUp()
    {
        _empty = false;
        _fillUp = true;
    }

    public void Empty()
    {
        _fillUp = false;
        _empty = true;
    }
}
