using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{

    public List<AudioClip> audioClipList;
    public float fadeAmount;

    private AudioClip _newMusic;
    private bool _shouldChange;
    private bool _fadeOut;
    private float _initialVolume;

    private void Start()
    {
        _initialVolume = this.GetComponent<AudioSource>().volume;
    }

    private void Update()
    {
        ControlClipChange();
    }

    public void ChangeMusic(string spriteName)
    {
        foreach (AudioClip aC in audioClipList)
        {
            if (aC.name.Contains(spriteName))
            {
                _newMusic = aC;
                _shouldChange = true;
                _fadeOut = true;
            }
        }
    }

    private void ControlClipChange()
    {
        AudioSource myAudioSource = this.GetComponent<AudioSource>();

        if (_shouldChange)
        {
            if (_fadeOut)
            {
                if (myAudioSource.volume > 0)
                {
                    myAudioSource.volume -= fadeAmount;
                }
                else
                {
                    _fadeOut = false;
                }
            }
            else
            {
                myAudioSource.clip = _newMusic;

                if (!myAudioSource.isPlaying)
                {
                    myAudioSource.Play();
                }

                if (myAudioSource.volume < _initialVolume)
                {
                    myAudioSource.volume += fadeAmount;
                } else
                {
                    _shouldChange = false;
                }
            }
        }
    }
}
