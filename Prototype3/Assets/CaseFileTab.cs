using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaseFileTab : MonoBehaviour {

    public List<Color> _depthColours;

    private static List<GameObject> _tabs;

    private void Awake()
    {
        _tabs = new List<GameObject>();
    }

    // Use this for initialization
    void Start () {
        _tabs.Add(this.gameObject);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetCurrSelected()
    {

        List<int> spriteValues = new List<int>();

        foreach (GameObject t in _tabs)
        {
            spriteValues.Add(t.GetComponent<SpriteRenderer>().sortingOrder);
        }

        spriteValues.Sort();

        int index = 1;

        foreach (GameObject t in _tabs)
        {
            if (t == this.gameObject)
            {
                this.GetComponent<SpriteRenderer>().sortingOrder = spriteValues[0];
                this.GetComponent<SpriteRenderer>().color = _depthColours[0];
            }
            else
            {
                t.GetComponent<SpriteRenderer>().sortingOrder = spriteValues[index];
                this.GetComponent<SpriteRenderer>().color = _depthColours[index];
                index++;
            }
        }
    }
}
