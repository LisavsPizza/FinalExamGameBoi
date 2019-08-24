using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAnimation : MonoBehaviour {

    public float time;

    private float _timer;
    private bool _startTimer;

    private GameObject canvas;

    // Use this for initialization
    void Start () {
            _startTimer = true;

        if (GameObject.Find("Canvas") != null)
        {
            canvas = GameObject.Find("Canvas");
            canvas.SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update () {


        if (_startTimer)
        {
            _timer += Time.deltaTime;
            if (_timer >= time)
            {
                GameObject.Find("LoadingTitle").GetComponent<MyImage>().FadeOut();
                this.GetComponent<MyImage>().FadeIn();
                if (canvas)
                {
                    canvas.SetActive(true);
                }
                _startTimer = false;
            }
        }
    }
}
