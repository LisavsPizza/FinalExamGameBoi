using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionIndicator : MonoBehaviour {

    public float fadeAmount;
    public float maxIntensity;
    public float minIntensity;

    private bool _fadeOut;

    private void Start()
    {
        _fadeOut = true;
    }
    // Update is called once per frame
    void Update () {
        FadeIntensity();
	}

    void FadeIntensity()
    {
        Light myLight = this.GetComponent<Light>();

        if (myLight.enabled)
        {
            if (_fadeOut)
            {
                if (myLight.intensity >= minIntensity)
                {
                    myLight.intensity -= fadeAmount;
                }
                else
                {
                    _fadeOut = false;
                }
            } else
            {
                if (myLight.intensity <= maxIntensity)
                {
                    myLight.intensity += fadeAmount;
                } else
                {
                    _fadeOut = true;
                }
            }
        }
    }

  

}
