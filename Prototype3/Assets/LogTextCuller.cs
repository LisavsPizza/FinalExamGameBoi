using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class LogTextCuller : MonoBehaviour
{

    public int maxNumChars;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CullText();
    }

    private void LateUpdate()
    {
        
    }

    public void CullText()
    {
        string myText = this.GetComponent<Text>().text;

        if (myText.Length >= maxNumChars)
        {
            if (myText.IndexOf("\n\n", 0) >= 0)
            {
                string firstSentence = myText.Substring(0, (myText.IndexOf("\n\n", 0))+1);

                Regex regex = new Regex(Regex.Escape(firstSentence));
                string newText = regex.Replace(myText, "", 1);

                this.GetComponent<Text>().text = newText;
            }
        }
    }
}
