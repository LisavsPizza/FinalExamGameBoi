using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class LeaveConditionB_Chronicle : MonoBehaviour {

    public UnityEvent m_OnAllConditionsMet;

    private static bool _finishedKimberlyDialogue1;
    private static bool _finishedMaxDialogue1;
    private static bool _finishedMaxDialogue2;
    private static bool _finishedKimberlyPresentMaxAccount;
    private static bool _finishedKimberlySafe;
    private static bool _finishedMaxBullets;
    private static bool _foundPin;

    // Use this for initialization
    void Start () {
		if (m_OnAllConditionsMet == null)
        {
            m_OnAllConditionsMet = new UnityEvent();
        }
	}
	
	// Update is called once per frame
	void Update () {

		if (CheckAllConditionsMet())
        {
            m_OnAllConditionsMet.Invoke();
            print ("ALL CONDITIONS SHOULD BE MET!!");
            Destroy(this.gameObject);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("KD_1: " + _finishedKimberlyDialogue1);
            Debug.Log("MD_1: " + _finishedMaxDialogue1);
            Debug.Log("MD_2: " + _finishedMaxDialogue2);
            Debug.Log("KM_Account: " + _finishedKimberlyPresentMaxAccount);
            Debug.Log("K_Safe: " + _finishedKimberlySafe);
            Debug.Log("M_Bullets: " + _finishedMaxBullets);
        }
	}

    private bool CheckAllConditionsMet()
    {
        bool met = true;

        if (!_finishedKimberlyDialogue1)
        {
            met = false;
        }
        if (!_finishedMaxDialogue1)
        {
            met = false;
        }
        if (!_finishedMaxDialogue2)
        {
            met = false;
        }
        if (!_finishedKimberlyPresentMaxAccount)
        {
            met = false;
        }
        if (!_finishedKimberlySafe)
        {
            met = false;
        }
        if (!_finishedMaxBullets)
        {
            met = false;
        }
        if (!_foundPin)
        {
            met = false;
        }

        return met;
    }

    public void SetKimberlyDialogue1Finished()
    {
        _finishedKimberlyDialogue1 = true;
    }

    public void SetMaxDialogue1Finished()
    {
        _finishedMaxDialogue1 = true;
    }

    public void SetMaxDialogue2Finished()
    {
        _finishedMaxDialogue2 = true;
    }

    public void SetKimberlyPresentMaxAccountFinished()
    {
        _finishedKimberlyPresentMaxAccount = true;
    }

    public void SetKimberlySafeFinished()
    {
        _finishedKimberlySafe = true;
    }

    public void SetMaxBulletsFinished()
    {
        _finishedMaxBullets = true;
    }

    public void FoundPin()
    {
        _foundPin = true;
    }
}
