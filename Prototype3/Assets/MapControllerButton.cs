using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapControllerButton : MonoBehaviour {

    GameObject mapCanvas;

    private bool _buttonRevealed;

    // Use this for initialization
    void Start () {
        mapCanvas = GameObject.Find("MapCanvas");
        mapCanvas.SetActive(false);
        this.gameObject.SetActive(false);
        _buttonRevealed = false;
    }
	
	// Update is called once per frame
	void Update () {
    }

    public void ControlVisibility()
    {
        if (mapCanvas.activeInHierarchy)
        {
            mapCanvas.SetActive(false);
        } else

        {
            mapCanvas.SetActive(true);
        }
    }

    public void RevealButton()
    {
        this.gameObject.SetActive(true);
        AudioManager.PlaySound(Resources.Load("Ping") as AudioClip);
        this.transform.GetChild(0).GetComponent<ParticleSystem>().Play();
        _buttonRevealed = true;
    }

    public bool CheckButtonRevealed()
    {
        return _buttonRevealed;
    }
}
