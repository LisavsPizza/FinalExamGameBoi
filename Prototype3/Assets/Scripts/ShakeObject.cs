using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// © 2017 TheFlyingKeyboard and released under MIT License
// theflyingkeyboard.net

public class ShakeObject : MonoBehaviour
{
    public Vector3 axisShakeMin;
    public Vector3 axisShakeMax;
    private bool shake;
    private Vector3 startPos;

    // Use this for initialization
    void Start()
    {
        shake = false;
        startPos = this.GetComponent<RectTransform>().position;

        Shake();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (shake)
        {
            this.GetComponent<RectTransform>().position = startPos + new Vector3(Random.Range(axisShakeMin.x, axisShakeMax.x), Random.Range(axisShakeMin.y, axisShakeMax.y), Random.Range(axisShakeMin.z, axisShakeMax.z));
        }
    }
    public void Shake()
    {
        shake = true;
    }

    public void StopShaking()
    {
        shake = false;
        this.GetComponent<RectTransform>().position = startPos;
    }

}
