using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeCanvasLegacy : MonoBehaviour {

    public float fadeAmount;
    public GameObject mainAudioSource;

    private bool _fadeIn;
    private bool _fadeOut;
    private string _nextScene;

    // Use this for initialization
    void Start()
    {
        if (mainAudioSource == null)
        {
            mainAudioSource = Camera.main.gameObject;
        }

        CanvasGroup fadeCanvas = this.GetComponent<CanvasGroup>();
        fadeCanvas.alpha = 1;
        OpenScene();
        //fadeAmount = 0.05f;

        mainAudioSource.GetComponent<AudioSource>().volume = 0;
    }

    private void Update()
    {
        CanvasGroup fadeCanvas = this.GetComponent<CanvasGroup>();

        if (_fadeIn)
        {
            if (fadeCanvas.alpha > 0)
            {
                fadeCanvas.alpha -= fadeAmount;
                mainAudioSource.GetComponent<AudioSource>().volume += fadeAmount;
            }
            else
            {
                this.gameObject.SetActive(false);
                _fadeIn = false;
            }
        }
        else if (_fadeOut)
        {
            if (fadeCanvas.alpha < 1)
            {
                fadeCanvas.alpha += fadeAmount;
                mainAudioSource.GetComponent<AudioSource>().volume -= fadeAmount;
            }
            else
            {
                _fadeOut = false;
                SceneManager.LoadScene(_nextScene);
            }

        }
    }

    public void ChangeScene(string sceneName)
    {
        _fadeOut = true;
        _nextScene = sceneName;
    }

    private void OpenScene()
    {
        _fadeIn = true;
    }
}
