using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundEvent : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlaySound(AudioClip clip)
    {
        print("I'VE BEEN CALLED");
        AudioManager.PlaySound(clip);
    }
}
