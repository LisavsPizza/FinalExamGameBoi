using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCharacterFade2 : MonoBehaviour {

    public float waitTime;
    private float _waitTimer;
   
    private List<GameObject> _allChildren;
    private int _index;

    // Use this for initialization
    void Start () {
        _allChildren = new List<GameObject>();

		for (int i = 0; i < this.transform.childCount; i++)
        {
            _allChildren.Add(this.transform.GetChild(i).gameObject);
            _allChildren.Add(this.transform.GetChild(i).GetChild(0).gameObject);
        }

        foreach (GameObject g in _allChildren)
        {
            Color gColour = g.GetComponent<SpriteRenderer>().color;
            gColour.a = 0;
            g.GetComponent<SpriteRenderer>().color = gColour;
        }

        _index = 0;

    }
	
	// Update is called once per frame
	void Update () {
        _waitTimer += Time.deltaTime;
        if (_waitTimer >= waitTime)
        {
            _allChildren[_index].GetComponent<MyImage>().FadeIn();
            _index++;
            _allChildren[_index].GetComponent<MyImage>().FadeIn();

            if (_index >= _allChildren.Count - 2)
            {

                _allChildren[_index-1].GetComponent<MyImage>().FadeOut();
                _allChildren[_index].GetComponent<MyImage>().FadeOut();

                foreach (GameObject g in _allChildren)
                {
                    if (g != _allChildren[_index - 1] || g != _allChildren[_index])
                    {
                        Color gColour = g.GetComponent<SpriteRenderer>().color;
                        gColour.a = 0;
                        g.GetComponent<SpriteRenderer>().color = gColour;
                    } else
                    {
                        print(g.name);
                    }
                }

                _index = 0;

            }
            else
            {
                _index++;
            }

            _waitTimer = 0.0f;
        }
	}
}
