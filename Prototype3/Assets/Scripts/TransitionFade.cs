using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TransitionFade : MonoBehaviour
{

    public float fadeAmount;
    private bool _changingScene;
    private bool _cop;
    private bool _taxi;
    private bool _gameOver;
    public string nextScene;
    private float _delayTimer;
    private List<AudioSource> _aSources = new List<AudioSource>();
    private List<float> _aSourceVolumes = new List<float>();

    // Use this for initialization
    void Start()
    {
        CanvasGroup fadeCanvas;
        fadeCanvas = this.GetComponent<CanvasGroup>();
        fadeCanvas.alpha = 1;
        _delayTimer = 0;
        _cop = false;
        _taxi = false;
        //FindAudioSources();
    }

    // Update is called once per frame
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //FindAudioSources();
    }

    void Update()
    {

        for (int i = 0; i < _aSources.Count; i++)
        {
            if (_aSources[i].volume < _aSourceVolumes[i])
            {
                _aSources[i].volume += fadeAmount;
            }
        }

        if (_taxi)
        {
            ChangeScene("TaxiGameOver", true);
            this.GetComponent<CanvasGroup>().alpha = 1;

        }
        else if (_cop)
        {
            ChangeScene("CopGameOver", true);
            this.GetComponent<CanvasGroup>().alpha = 1;
        }
        else if (_changingScene)
        {
            ChangeScene(nextScene, true);
        }
        else
        {
            FadeOut();
        }
    }

    private void ChangeScene(string sceneName, bool fadeMusic)
    {


        CanvasGroup fadeCanvas;
        fadeCanvas = this.GetComponent<CanvasGroup>();

        if (fadeMusic)
        {
            foreach (AudioSource aSource in Camera.main.GetComponents<AudioSource>())
            {
                aSource.volume -= fadeAmount;
            }
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }

        if (fadeCanvas.alpha < 1)
        {
            fadeCanvas.alpha += fadeAmount;
        }
        else
        {
            for (int i = 0; i < _aSources.Count; i++)
            {
                _aSources[i].volume -= fadeAmount;
            }
            _delayTimer += Time.deltaTime;
            if (_delayTimer >= 1)
            {
                _delayTimer = 0;
                SceneManager.LoadScene(sceneName);
                _changingScene = false;
                _cop = false;
                _taxi = false;
            }
        }
    }

    public void NextScene()
    {
        _changingScene = true;
    }

    private void FadeOut()
    {
        CanvasGroup fadeCanvas;
        fadeCanvas = this.GetComponent<CanvasGroup>();

        if (fadeCanvas.alpha > 0)
        {
            fadeCanvas.alpha -= fadeAmount;
        }
    }

    private void FindAudioSources()
    {
        _aSources.Clear();
        _aSourceVolumes.Clear();

        foreach (AudioSource aSource in Camera.main.GetComponents<AudioSource>())
        {
            _aSources.Add(aSource);
            _aSourceVolumes.Add(aSource.volume);
            aSource.volume = 0;
        }
    }

    public void CopKilled()
    {
        _cop = true;
    }

    public void TaxiKilled()
    {
        _taxi = true;
    }

}
