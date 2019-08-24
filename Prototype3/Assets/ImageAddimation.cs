using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageAddimation : MonoBehaviour {
    private bool _startMoving;

	// Use this for initialization
	void Start () {
        _startMoving = false;
    }
	
	// Update is called once per frame
	void Update () {

        if (_startMoving)
        {
            GameObject target = GameObject.Find("AddImageTarget");

            Vector3 pos = this.transform.position;
            pos = Vector3.MoveTowards(this.transform.position, target.transform.position, 10 * Time.deltaTime);
            this.transform.position = pos;


            this.transform.localScale -= new Vector3(1, 1, 1) * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (this.GetComponent<SpriteRenderer>().color.a >= 0.2f)
            {
                HideItemImage();
            }
        }
    }

    public void PlayAddItemAnimation(Sprite newSprite)
    {
        //this.transform.position = _originalPos;
        //this.transform.localScale = _originalScale;

        SpriteRenderer mySpriteRenderer = this.GetComponent<SpriteRenderer>();
        mySpriteRenderer.sprite = newSprite;
        this.GetComponent<MyImage>().FadeIn();
        this.transform.parent.GetComponent<MyImage>().FadeIn();

        //_startMoving = true;
    }

    public void HideItemImage()
    {
        if (GameObject.Find("DialogueCanvasDecorated").GetComponent<DialogueBox>().MainTextIsFullyDisplayed())
        {
            this.GetComponent<MyImage>().FadeOut();
            this.transform.parent.GetComponent<MyImage>().FadeOut();
        }
    }
}
