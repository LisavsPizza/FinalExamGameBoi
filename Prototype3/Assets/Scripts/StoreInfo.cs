using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StoreInfo : MonoBehaviour {

    //Phone Info://
    private static bool _hasPhone;
    public UnityEvent m_OnHasPhone;
    public UnityEvent m_OnHasNoPhone;

    //Date Info://
    private static int _dateScore;
    public int pointsForGoodDate;
    public int pointsForBadDate;
    public int goodEndingNode;
    public int neutralEndingNode;
    public int badEndingNode;

	// Use this for initialization
	void Start () {
        _dateScore = 0;

        if (SceneManager.GetActiveScene().name.Equals("DialogueScene2"))
        {
            _hasPhone = false;
        }

        if (m_OnHasPhone == null)
        {
            m_OnHasPhone = new UnityEvent();
        }

        if (m_OnHasNoPhone == null)
        {
            m_OnHasNoPhone = new UnityEvent();
        }
    }
	
    public void ObtainPhone()
    {
        _hasPhone = true;
    }

    public void ChangeDateScore(int score)
    {
        _dateScore += score;
        if (score != 0)
        {
            if (score == Mathf.Abs(score))
            {
                GameObject.Find("Convinced").GetComponent<Image>().fillAmount += 0.1f;
            }
            else
            {
                GameObject.Find("NotConvinced").GetComponent<Image>().fillAmount += 0.1f;
            }
        }
    }

    public void CheckHasPhone()
    {
        if (_hasPhone)
        {
            m_OnHasPhone.Invoke();
        } else
        {
            m_OnHasNoPhone.Invoke();
        }
    }

    public void SetDateEndingNodeBasedOnScore()
    {
        DialogueBox myDialogueBox = GameObject.Find("DialogueCanvas").GetComponent<DialogueBox>();

        if (_dateScore > pointsForGoodDate)
        {
            myDialogueBox.ChangeNode(goodEndingNode);
        }
        else if (_dateScore <= pointsForGoodDate && _dateScore > pointsForBadDate)
        {
            myDialogueBox.ChangeNode(neutralEndingNode);
        } else
        {
            myDialogueBox.ChangeNode(badEndingNode);
        }
    }

}
