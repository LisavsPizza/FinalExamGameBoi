using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void PlaySound(AudioClip newClip)
    {
        AudioSource myAudioSource = GameObject.FindGameObjectWithTag("AudioManager").GetComponents<AudioSource>()[0];
        AudioSource backupAudioSource = GameObject.FindGameObjectWithTag("AudioManager").GetComponents<AudioSource>()[1];

        if (myAudioSource != null)
        {
            if (myAudioSource.isPlaying)
            {
                backupAudioSource.clip = newClip;
                backupAudioSource.volume = 1;
                backupAudioSource.loop = false;
                backupAudioSource.Play();
            }
            else
            {
                myAudioSource.clip = newClip;
                myAudioSource.volume = 1;
                myAudioSource.loop = false;
                myAudioSource.Play();
            }
        }
    }

    public static void PlaySound(AudioClip newClip, float volume)
    {
        AudioSource myAudioSource = GameObject.FindGameObjectWithTag("AudioManager").GetComponents<AudioSource>()[0];
        AudioSource backupAudioSource = GameObject.FindGameObjectWithTag("AudioManager").GetComponents<AudioSource>()[1];

        if (myAudioSource != null)
        {
            if (myAudioSource.isPlaying)
            {
                backupAudioSource.clip = newClip;
                backupAudioSource.volume = volume;
                backupAudioSource.loop = false;
                backupAudioSource.Play();
            }
            else
            {
                myAudioSource.clip = newClip;
                myAudioSource.volume = volume;
                myAudioSource.loop = false;
                myAudioSource.Play();
            }
        }
    }

    public static void PlaySound(AudioClip newClip, float volume, bool repeat)
    {
        AudioSource myAudioSource = GameObject.FindGameObjectWithTag("AudioManager").GetComponents<AudioSource>()[0];
        AudioSource backupAudioSource = GameObject.FindGameObjectWithTag("AudioManager").GetComponents<AudioSource>()[1];

        if (myAudioSource != null)
        {
            if (myAudioSource.isPlaying)
            {
                backupAudioSource.clip = newClip;
                backupAudioSource.volume = volume;
                backupAudioSource.loop = true;
                backupAudioSource.Play();
            }
            else
            {
                myAudioSource.clip = newClip;
                myAudioSource.volume = volume;
                myAudioSource.loop = true;
                myAudioSource.Play();
            }
        }
    }
}
