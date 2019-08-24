using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommandWheel : MonoBehaviour {

    public Vector3 smallScale;
    public float growthRate;

    private Vector3 _normalScale;
    private bool _playEntryAnimation;

    private bool _canClick;

	// Use this for initialization
	void Start () {
        _normalScale = this.transform.localScale;
        Hide();
        _canClick = true;
    }
	
	// Update is called once per frame
	void Update () {

        if (GameObject.Find("DialogueCanvasDecorated").GetComponent<DialogueBox>().IsShowing())
        {
            Hide();
        } else if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (_canClick)
            {
                if (MyButtonCommand.MouseIsOverOtherButton() == false && GameObject.Find("DialogueCanvasDecorated").GetComponent<DialogueBox>().IsShowing() == false)
                {
                    Vector3 mousePos = Input.mousePosition;
                    mousePos.z = 2.0f; // we want 2m away from the camera position
                    Vector3 objectPos = Camera.main.ScreenToWorldPoint(mousePos);
                    this.transform.position = objectPos;

                    PlayEntryAnimation();
                }
            } else
            {
                Hide();
            }
        }

		if (_playEntryAnimation)
        {
            if (this.transform.localScale.x < _normalScale.x)
            {
                this.transform.localScale += new Vector3(growthRate, growthRate, growthRate)*Time.deltaTime;
            } else if (this.transform.localScale.x > _normalScale.x)
            {
                this.transform.localScale = _normalScale;
                _playEntryAnimation = false;
                Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
                pos.x = Mathf.Clamp(pos.x, 0.1f, 0.88f);
                pos.y = Mathf.Clamp(pos.y, 0.3f, 0.82f);
                transform.position = Camera.main.ViewportToWorldPoint(pos);
            } else
            {
                _playEntryAnimation = false;
            }
        }
	}

    private void PlayEntryAnimation()
    {
        this.transform.localScale = smallScale;
        Show();
        _playEntryAnimation = true;
    }

    public void ChangeApplicableButtons(List<bool> applicableButtons)
    {
        
        for (int i = 0; i < this.transform.childCount; i++)
        {
            GameObject currChild = this.transform.GetChild(i).gameObject;

            if (currChild.name != "TextCanvas")
            {
                Color childColour = currChild.GetComponent<SpriteRenderer>().color;
                childColour = Color.white;
                childColour.a = 1;
                currChild.GetComponent<SpriteRenderer>().color = childColour;

                currChild.GetComponent<BoxCollider>().enabled = applicableButtons[i];
                if (applicableButtons[i] == false)
                {
                    childColour = Color.grey;
                    childColour.a = childColour.a * 0.5f;
                    currChild.GetComponent<SpriteRenderer>().color = childColour;
                }
                else
                {
                    childColour.a = 1;
                    currChild.GetComponent<SpriteRenderer>().color = childColour;
                }
            }

        }
    }

    public void Hide()
    {
        this.GetComponent<SpriteRenderer>().enabled = false;
        for (int i = 0; i < this.transform.childCount; i++)
        {
            GameObject currChild = this.transform.GetChild(i).gameObject;

            if (currChild.name != "TextCanvas")
            {
                currChild.GetComponent<SpriteRenderer>().enabled = false;
                currChild.GetComponent<BoxCollider>().enabled = false;
            } else
            {
                this.transform.GetChild(i).GetChild(1).GetComponent<MyUIFade>().FadeOut();
                this.transform.GetChild(i).GetChild(0).GetComponent<MyUIFade>().FadeOut();
            }
        }
    }

    public void Show()
    {
        AudioManager.PlaySound(Resources.Load("InteractSound") as AudioClip);

        this.GetComponent<SpriteRenderer>().enabled = true;
        for (int i = 0; i < this.transform.childCount; i++)
        {
            if (this.transform.GetChild(i).name != "TextCanvas")
            {
                this.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().enabled = true;
            }
        }
    }

    public void SetCanClick(bool canClick)
    {
        _canClick = canClick;
    }

    public bool CanClick()
    {
        return _canClick;
    }
}
