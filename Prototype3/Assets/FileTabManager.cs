using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileTabManager : MonoBehaviour {

    public List<Color> _depthColours;

    public List<GameObject> tabs;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetCurrSelected(GameObject frontTab)
    {
        int index = 7;
        int colourIndex = 1;

        foreach (GameObject t in tabs)
        {
            if (t == frontTab)
            {
                t.GetComponent<SpriteRenderer>().sortingOrder = 9;
                t.GetComponent<SpriteRenderer>().color = _depthColours[0];
                t.GetComponent<MyButtonCommand>().SetOriginalColour(_depthColours[0]);
            }
            else
            {
                t.GetComponent<SpriteRenderer>().sortingOrder = index;
                t.GetComponent<SpriteRenderer>().color = _depthColours[colourIndex];
                t.GetComponent<MyButtonCommand>().SetOriginalColour(_depthColours[colourIndex]);
                colourIndex++;
            }
        }
    }
}
