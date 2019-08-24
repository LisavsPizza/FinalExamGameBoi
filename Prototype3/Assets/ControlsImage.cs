using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlsImage : MonoBehaviour {

    public float dialogueShowingXPos;
    public float dialogueNotShowingXPos;
    public float moveSpeed;

    private bool _dialogueShowing;
    private bool _move;
    private bool _posSet;

    private Vector3 _originalPos;
    private Vector3 _newPos;

    private Quaternion _originalRot;

    //private bool _testBool;


	// Use this for initialization
	void Start () {
        _originalPos = this.transform.localPosition;
        _originalRot = this.transform.localRotation;
        //_testBool = true;
    }
	
	// Update is called once per frame
	void Update () {

        //if (Input.GetKeyDown(KeyCode.Z))
        //{
        //    _testBool = !_testBool;
        //    SwitchModeDialogueShowing(_testBool);
        //}

		if (_move)
        {
            Color myColour = this.GetComponent<Image>().color;

            if (!_posSet)
            {
                Vector3 myRot = _originalRot.eulerAngles;


                myColour.a = 0;
                myRot.x = 90;

                this.transform.localRotation = Quaternion.Euler(myRot);
                this.transform.localPosition = _newPos;

                _posSet = true;
            }
            else
            {
                myColour.a = 1;

                float moveSpeed = 0.07f;
                float x = 0;

                if (this.transform.rotation.x > 0)
                {
                    this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.Euler(x, 0, 0), moveSpeed);
                }
                else
                {
                    this.transform.rotation = Quaternion.Euler(x, 0, 0);
                    _move = false;
                }
            }

            this.GetComponent<Image>().color = myColour;
        }
	}

    public void SwitchModeDialogueShowing(bool dialogueShowing)
    {
        if (dialogueShowing)
        {
            if (_newPos.x != dialogueShowingXPos)
            {
                _newPos.x = dialogueShowingXPos;

                DecideMove();
            }
        } else
        {
            if (_newPos.x == dialogueShowingXPos)
            {
                _newPos.x = dialogueNotShowingXPos;

                DecideMove();
            }
        }
    }

    private void DecideMove()
    {
        _move = true;

        _originalPos = this.transform.localPosition;
        _posSet = false;

        _newPos.y = _originalPos.y;
        _newPos.z = _originalPos.z;
    }
}
