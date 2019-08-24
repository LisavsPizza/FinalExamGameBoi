using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CodeDisplay : MonoBehaviour {

    public float flashTime;
    public int numFlashes;
    public int code;

    private bool _startTimer;
    private float _timer;

    private int _flashCounter;

    private bool _canEnterCode;
    private bool _hasCheckedCode;


	// Use this for initialization
	void Start () {
        _canEnterCode = false;
        _flashCounter = 0;
        _hasCheckedCode = false;
    }
	
	// Update is called once per frame
	void Update () {

        string checkString;

        if (this.GetComponent<Text>().text != null)
        {
            checkString = this.GetComponent<Text>().text;
        } else
        {
            checkString = "";
        }

        if (checkString!= "")
        {
            string enteredCodeString = checkString.Replace(" ", string.Empty);
            int enteredCode = int.Parse(checkString.Replace(" ", string.Empty));

            if (enteredCodeString.Length == 4)
            {
                if (_hasCheckedCode == false)
                {
                    if (_canEnterCode)
                    {
                        if (enteredCode == code)
                        {

                        }
                        else
                        {
                            WrongCode();
                        }
                    }
                    else
                    {
                        WrongCode();
                    }

                    _hasCheckedCode = true;
                }
            }
        }

        if (_startTimer)
        {
            if (_flashCounter < numFlashes)
            {
                _timer += Time.deltaTime;

                if (_timer >= flashTime)
                {
                    this.GetComponent<Text>().enabled = !this.GetComponent<Text>().enabled;
                    _timer = 0;
                    _flashCounter++;
                }
            } else
            {
                this.GetComponent<Text>().text = null;
                this.GetComponent<Text>().enabled = true;
                _startTimer = false;
                _timer = 0;
                _flashCounter = 0;
                EnableButtons();
                _hasCheckedCode = false;
            }
        }
	}

    private void WrongCode()
    {
        DisableButtons();
        _startTimer = true;
    }

    private void DisableButtons()
    {
        for (int i = 0; i < this.transform.parent.childCount; i++)
        {
            GameObject currChild = this.transform.parent.GetChild(i).gameObject;

            if (currChild != this.gameObject)
            {
                currChild.GetComponent<SafeButton>().enabled = false;
                currChild.GetComponent<BoxCollider>().enabled = false;
            }
        }
    }

    private void EnableButtons()
    {
        for (int i = 0; i < this.transform.parent.childCount; i++)
        {
            GameObject currChild = this.transform.parent.GetChild(i).gameObject;

            if (currChild != this.gameObject)
            {
                currChild.GetComponent<SafeButton>().enabled = true;
                currChild.GetComponent<BoxCollider>().enabled = true;
            }
        }
    }
}
