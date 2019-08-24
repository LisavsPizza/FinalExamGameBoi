using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChanger : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Return))
        {
            if (SceneManager.GetActiveScene().name == "Instructions")
            {
                SceneManager.LoadScene("Prologue");
            }
        }
	}

    public void ChangeSceneInstructions()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void ChangeScenePlay()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
