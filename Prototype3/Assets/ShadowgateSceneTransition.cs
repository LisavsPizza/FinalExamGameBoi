using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.Events;

public class ShadowgateSceneTransition : MonoBehaviour
{
    //remember to drag and drop your scriptable object into this field in the inspector...
    public PostProcessingProfile ppProfile;
    public UnityEvent m_OnTransition;
    public float speed;

    private Transform zoomObject;
    private string sceneName;

    private bool _startTransition = false;
    private bool _canTransition = true;

    private float _originalOrthographicSize;
    private Vector3 _originalCameraPos;

    private bool _manuallyDelaySceneTransition;
    private bool _hasInvokedDelayedEvent;

    public UnityEvent m_OnSceneTransitionDelayed;

    private void Start()
    {
        _originalOrthographicSize = Camera.main.orthographicSize;
        _originalCameraPos = Camera.main.transform.position;

        if (m_OnTransition == null)
        {
            m_OnTransition = new UnityEvent();
        }

        if (m_OnSceneTransitionDelayed == null)
        {
            m_OnSceneTransitionDelayed = new UnityEvent();
        }

        ResetTransition();
    }
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.R))
        //{
        //    _startTransition = true;

        //}

            if (_startTransition)
            {

            if (!_manuallyDelaySceneTransition)
            {
                if (_canTransition)
                {
                    ChromaticAberrationModel.Settings chromaSettings = ppProfile.chromaticAberration.settings;
                    chromaSettings.intensity += 0.1f;
                    ppProfile.chromaticAberration.settings = chromaSettings;
                    ppProfile.vignette.enabled = true;

                    Camera.main.transform.position = Vector3.MoveTowards(this.transform.position, zoomObject.position, speed * Time.deltaTime);

                    if (Camera.main.orthographicSize > 0)
                    {
                        Camera.main.orthographicSize -= 0.1f;
                    }
                }
            }
            else
            {
                if (!_hasInvokedDelayedEvent)
                {
                    _canTransition = false;
                    m_OnSceneTransitionDelayed.Invoke();
                    _hasInvokedDelayedEvent = true;
                }
            }
        }
    }

    void ChangeChromaAbberationAtRunTime()
    {
        ChromaticAberrationModel.Settings chromaSettings = ppProfile.chromaticAberration.settings;

        if (chromaSettings.intensity < 3.2f)
        {
            chromaSettings.intensity += 0.1f;
            ppProfile.chromaticAberration.settings = chromaSettings;
        }
        else
        {
            // _canTransition = false;
            GameObject.Find("FadeCanvas").GetComponent<FadeCanvas>().ChangeScene(sceneName);
        }
    }

    public void ChangeTransitionObject(Transform newZoomObject)
    {
        zoomObject = newZoomObject;
    }

    public void ChangeScene(string scene)
    {
        sceneName = scene;
        _startTransition = true;
        if (!_manuallyDelaySceneTransition)
        {
            m_OnTransition.Invoke();
            GameObject.Find("FadeCanvas").GetComponent<FadeCanvas>().ChangeScene(sceneName);
        }
    }

    public void ResetTransition()
    {
        ChromaticAberrationModel.Settings chromaSettings = ppProfile.chromaticAberration.settings;
        chromaSettings.intensity = 0;
        ppProfile.chromaticAberration.settings = chromaSettings;
        ppProfile.vignette.enabled = false;

        _startTransition = false;
        _canTransition = true;

        Camera.main.orthographicSize= _originalOrthographicSize;
        Camera.main.transform.position = _originalCameraPos;
    }

    public void ManuallyDelaySceneTransition()
    {
        _manuallyDelaySceneTransition = true;
    }

    public void ResumeSceneTransition()
    {
        _manuallyDelaySceneTransition = false;
        _canTransition = true;
        m_OnTransition.Invoke();
        GameObject.Find("FadeCanvas").GetComponent<FadeCanvas>().ChangeScene(sceneName);
    }

    public void SetDelayedSceneTransitionEvent(UnityEvent newEvent)
    {
        _hasInvokedDelayedEvent = false;
        m_OnSceneTransitionDelayed = newEvent;
    }
}
