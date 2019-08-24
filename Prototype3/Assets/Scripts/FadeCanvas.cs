using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class FadeCanvas : MonoBehaviour
{

    public float fadeAmount;
    private bool _fadeIn;
    private bool _fadeOut;
    private string _nextScene;

    private static UnityEvent m_OnSceneLoaded;
    private static UnityEvent m_OnSceneLoadedReplaceable;

    // Use this for initialization
    void Start()
    {
        CanvasGroup fadeCanvas = this.GetComponent<CanvasGroup>();
        fadeCanvas.alpha = 1;
        OpenScene();

        //Will always happen when the scene is loaded
        if (m_OnSceneLoaded == null)
        {
            m_OnSceneLoaded = new UnityEvent();
        }

        //Events that will happen when the scene is loaded IF you want them to.
        if (m_OnSceneLoadedReplaceable == null)
        {
            m_OnSceneLoadedReplaceable = new UnityEvent();
        }
    }

    private void Update()
    {
        CanvasGroup fadeCanvas = this.GetComponent<CanvasGroup>();

        if (_fadeIn)
        {
            if (fadeCanvas.alpha > 0)
            {
                fadeCanvas.alpha -= fadeAmount;

            } else
            {
                this.gameObject.SetActive(false);
                _fadeIn = false;
            }
        } else if (_fadeOut)
        {
            if (fadeCanvas.alpha < 1)
            {
                fadeCanvas.alpha += fadeAmount;
            }
            else
            {
                _fadeOut = false;
                GameObject.Find("RoomManager").GetComponent<RoomManager>().ChangeRoom(_nextScene);
                Camera.main.GetComponent<ShadowgateSceneTransition>().ResetTransition();
                m_OnSceneLoadedReplaceable.Invoke();
                m_OnSceneLoadedReplaceable = new UnityEvent();
                m_OnSceneLoaded.Invoke();
                m_OnSceneLoaded = new UnityEvent();
                _fadeIn = true;
            }

        }
    }

    public void ChangeScene(string sceneName)
    {
        _fadeOut = true;
        _nextScene = sceneName;
        AudioManager.PlaySound(Resources.Load("CameraWooshSwitch") as AudioClip);
    }

    private void OpenScene()
    {
        _fadeIn = true;
    }

    private void MyLoadScene()
    {

    }

    public static void SetSceneLoadedEvent(UnityEvent newSceneLoadedEvent)
    {
        m_OnSceneLoaded = newSceneLoadedEvent;
    }

    public static void SetSceneLoadedEventReplacable(UnityEvent newSceneLoadedEvent)
    {
        m_OnSceneLoadedReplaceable = newSceneLoadedEvent;
    }

}
