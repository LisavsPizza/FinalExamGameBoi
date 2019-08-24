using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DiceType : MonoBehaviour
{
    public string diceName;
    public Sprite diceImage;
    public UnityEvent m_OnStopped;
    public UnityEvent m_OnAttack;
    public UnityEvent m_OnStatusEffect;

    // Start is called before the first frame update
    void Start()
    {
        if (m_OnStopped == null)
        {
            m_OnStopped = new UnityEvent();
        }


        if (m_OnAttack == null)
        {
            m_OnAttack = new UnityEvent();
        }


        if (m_OnStatusEffect == null)
        {
            m_OnStatusEffect = new UnityEvent();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string GetName()
    {
        return diceName;
    }

    public Sprite GetImage()
    {
        return diceImage;
    }

    public UnityEvent GetOnStoppedEvent()
    {
        return m_OnStopped;
    }

    public UnityEvent GetOnAttackEvent()
    {
        return m_OnAttack;
    }

    public UnityEvent GetOnStatusEvent()
    {
        return m_OnStatusEffect;
    }
}
