using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCharacterFade : MonoBehaviour {

    public List<Sprite> characters;
    public List<Sprite> colorBGs;
    public float waitTime;

    private float _waitTimer;

    private bool _silhouetteToClear;
    private bool _char1;

    private GameObject char1;
    private GameObject char2;

    private int charIndex;

	// Use this for initialization
	void Start () {
        _silhouetteToClear = false;
        char1 = this.transform.GetChild(0).gameObject;
        char2 = this.transform.GetChild(1).gameObject;
        _char1 = true;

        charIndex = 0;
        char1.GetComponent<SpriteRenderer>().sprite = characters[charIndex];
        char1.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = colorBGs[charIndex];
    }
	
	// Update is called once per frame
	void Update () {
        _waitTimer += Time.deltaTime;

        if (_waitTimer >= waitTime)
        {
            if (!_silhouetteToClear)
            {
                Color charColour = Color.red;

                if (_char1)
                {
                    charColour = char1.GetComponent<SpriteRenderer>().color;
                } else
                {
                    charColour = char2.GetComponent<SpriteRenderer>().color;
                }

                charColour.r += 0.1f;
                charColour.g += 0.1f;
                charColour.b += 0.1f;

                if (_char1)
                {
                    char1.GetComponent<SpriteRenderer>().color = charColour;
                } else
                {
                    char2.GetComponent<SpriteRenderer>().color = charColour;
                }

                if (charColour.g >= 1)
                {
                    _silhouetteToClear = true;
                    _waitTimer = 0.0f;
                }
            } else
            {
                if (_char1)
                {
                    char2.GetComponent<SpriteRenderer>().sprite = characters[charIndex + 1];
                    char2.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = colorBGs[charIndex + 1];

                    Color charColour = char1.GetComponent<SpriteRenderer>().color;

                    charColour.r = 0f;
                    charColour.g = 0f;
                    charColour.b = 0f;

                    char1.GetComponent<SpriteRenderer>().color = charColour;

                    if (charIndex == characters.Count - 2)
                    {
                        charIndex = 0;
                    }
                    else
                    {
                        charIndex++;
                    }

                    char1.GetComponent<MyImage>().FadeOut();
                    char1.transform.GetChild(0).GetComponent<MyImage>().FadeOut();

                    char2.GetComponent<MyImage>().FadeIn();
                    char2.transform.GetChild(0).GetComponent<MyImage>().FadeIn();
                } else
                {
                    char1.GetComponent<SpriteRenderer>().sprite = characters[charIndex + 1];
                    char1.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = colorBGs[charIndex + 1];

                    Color charColour = char2.GetComponent<SpriteRenderer>().color;

                    charColour.r = 0f;
                    charColour.g = 0f;
                    charColour.b = 0f;

                    char2.GetComponent<SpriteRenderer>().color = charColour;

                    if (charIndex == characters.Count - 2)
                    {
                        charIndex = 0;
                    }
                    else
                    {
                        charIndex++;
                    }

                    char2.GetComponent<MyImage>().FadeOut();
                    char2.transform.GetChild(0).GetComponent<MyImage>().FadeOut();

                    char1.GetComponent<MyImage>().FadeIn();
                    char1.transform.GetChild(0).GetComponent<MyImage>().FadeIn();
                }
                _char1 = !char1;
                _silhouetteToClear = false;
                _waitTimer = 0.0f;
            }
        }
    }
}
