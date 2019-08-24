using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class BillboardMessage : MonoBehaviour
{
    public UnityEvent m_OnMessageHidden;

    public float fillRate = 0.1f;
    public float waitTime = 3.5f;

    private bool _fill;
    private bool _wait;

    private float _timer;

    // Start is called before the first frame update
    void Start()
    {
        _fill = false;
        _wait = false;
        _timer = 0f;

        this.GetComponent<Image>().enabled = false;

        if (m_OnMessageHidden == null)
        {
            m_OnMessageHidden = new UnityEvent();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_fill)
        {
            if (this.GetComponent<Image>().fillAmount < 1)
            {
                this.GetComponent<Image>().fillAmount += fillRate;
            } else
            {
                _fill = false;
                _wait = true;
            }
        } else if (_wait)
        {

            _timer += Time.deltaTime;

            if (_timer >= waitTime)
            {
                if (this.GetComponent<Image>().fillAmount > 0)
                {
                    this.GetComponent<Image>().fillAmount -= fillRate;
                }
                else
                {
                    _wait = false;
                    _timer = 0f;
                    this.GetComponent<Image>().enabled = false;

                    m_OnMessageHidden.Invoke();
                }
            }
        }
    }

    public void ShowMessage()
    {

        for (int j = 0; j < GameObject.Find("DiceCanvas").transform.childCount; j++)
        {
            GameObject.Find("DiceCanvas").transform.GetChild(j).gameObject.GetComponent<ShakeObject>().StopShaking();
        }


        _fill = true;
        _wait = true;
        this.GetComponent<Image>().enabled = true;

    }
}
