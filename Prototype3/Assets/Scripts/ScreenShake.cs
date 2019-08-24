using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour {

	private Vector3 OriginalPos;

	public bool shake;

	float shakeTime=.25f;
	float xShake=.05f;
	float yShake=.05f;

	// Use this for initialization
	void Start () {

		OriginalPos = this.transform.position;

	}

	// Update is called once per frame
	void Update () {

		if (shake) {

			float xShakeAmount = Random.Range (-xShake, yShake);
			float yShakeAmount = Random.Range (-yShake, yShake);

			Vector3 pos = OriginalPos + new Vector3 (xShakeAmount, yShakeAmount);

			this.transform.position = pos;

			if ((Time.time >= shakeTime && shakeTime > 0)) {

				shake = false;
				shakeTime = -1;

				this.transform.position = pos;
			}


		}
	}

	public void Shake(float shakeDuration){

		shakeTime = Time.time + shakeDuration;
		shake = true;
	}
}
