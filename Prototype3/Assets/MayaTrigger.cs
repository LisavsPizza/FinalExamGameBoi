using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MayaTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlayGunShotSound()
    {
        AudioManager.PlaySound(Resources.Load("Shot") as AudioClip);
    }
}
