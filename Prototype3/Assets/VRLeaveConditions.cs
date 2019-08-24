using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VRLeaveConditions : MonoBehaviour {

    public UnityEvent m_OnAllConditionsMet;

    private static bool _finishedMayaDialogue1;
    private static bool _finishedMayaDialogue2;
    private static bool _equippedTin;

    // Use this for initialization
    void Start()
    {
        if (m_OnAllConditionsMet == null)
        {
            m_OnAllConditionsMet = new UnityEvent();
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (CheckAllConditionsMet())
        {
            m_OnAllConditionsMet.Invoke();
            print("ALL CONDITIONS SHOULD BE MET FOR VOX BOIS!!");
            Destroy(this.gameObject);
        }
    }

    private bool CheckAllConditionsMet()
    {
        bool met = true;

        if (!_finishedMayaDialogue1)
        {
            met = false;
        }
        if (!_finishedMayaDialogue2)
        {
            met = false;
        }
        if (!_equippedTin)
        {
            met = false;
        }

        return met;
    }

    public void SetMayaDialogue1Finished()
    {
        _finishedMayaDialogue1 = true;
    }

    public void SetMayaDialogue2Finished()
    {
        _finishedMayaDialogue2 = true;
    }

    public void SetTinEquipped()
    {
        _equippedTin = true;
    }
}
