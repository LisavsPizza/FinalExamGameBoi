using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHoverSprite : MonoBehaviour {

    private Vector3 mousePosition;
    public float moveSpeed = 0.1f;

    // Use this for initialization
    void Start()
    {
        HideHoverSprite();
    }

    // Update is called once per frame
    void Update()
    {
            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);

    }

    public void ChangeHoverSprite(Sprite newSprite)
    {
        SpriteRenderer mySR = this.GetComponent<SpriteRenderer>();
        mySR.sprite = newSprite;
        mySR.color = Color.white;
    }

    public void HideHoverSprite()
    {
        this.GetComponent<SpriteRenderer>().color = Color.clear;
    }
}
