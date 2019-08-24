using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PresentablePerson : MonoBehaviour
{

    public string presentedItemName;
    public UnityEvent m_OnPresented;

    public bool CheckMatch()
    {
        bool match = false;

        if (GameObject.Find("SatchelBG").GetComponent<SatchelScreen>().CheckPresentationMode())
        {
            if (PresentableItem.GetCurrSelectedObject().name == presentedItemName)
            {
                match = true;
                m_OnPresented.Invoke();
            }

        }

        return match;
    }

}
