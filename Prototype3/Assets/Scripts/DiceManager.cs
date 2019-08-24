using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceManager : MonoBehaviour
{

    public float resetDiceTime;

    public enum CombatStage { DiceAndTargets, ExecutingAttack, ChangingTurns }
    public static CombatStage CurrCombatStage = CombatStage.ChangingTurns;

    private static Character _currCharacter;
    private static List<Character> _currTargets = new List<Character>();

    private static bool _aPFound;
    private static bool _pPFound;

    private float _timer;

    private static bool _hasMovedDown;

    private Vector3 _targetDicePos;

    private Vector3 startPos;

    private static bool _resetManually;

    // Start is called before the first frame update
    void Start()
    {
        _timer = resetDiceTime;
        _hasMovedDown = false;

        _targetDicePos = GameObject.Find("Dice1").GetComponent<RectTransform>().position;
        _targetDicePos.y -= 200f;

        startPos = this.GetComponent<RectTransform>().position;

        _resetManually = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (ShouldResetDice())
        {
            _timer -= Time.deltaTime;

            if (_timer <= 0)
            {
                for (int i = 0; i < GameObject.Find("DiceCanvas").transform.childCount; i++)
                {
                    
                    GameObject currChild = GameObject.Find("DiceCanvas").transform.GetChild(i).gameObject;
                    if (!_hasMovedDown)
                    {
                        float speed = 1000f;
                        float step = speed * Time.deltaTime; // calculate distance to move

                        _targetDicePos.x = currChild.transform.position.x;
                        _targetDicePos.z = currChild.transform.position.z;

                        if (Vector3.Distance(currChild.transform.position, _targetDicePos) > 0.1f)
                        {
                            currChild.transform.position = Vector3.MoveTowards(currChild.GetComponent<RectTransform>().position, _targetDicePos, step);
                        }
                        else
                        {
                            _hasMovedDown = true;
                        }
                    }
                    else
                    {
                        for (int j = 0; j < GameObject.Find("DiceCanvas").transform.childCount; j++)
                        {
                            GameObject.Find("DiceCanvas").transform.GetChild(j).gameObject.GetComponent<ShakeObject>().StopShaking();
                        }


                        for (int k = 0; k < GameObject.Find("DiceCanvas").transform.childCount; k++)
                        {
                            GameObject.Find("DiceCanvas").transform.GetChild(k).gameObject.GetComponent<ShakeObject>().Shake();
                        }


                        ResetDice();
                        _timer = resetDiceTime;
                        _hasMovedDown = false;
                        _resetManually = false;

                        if (!TurnManager.GetCurrTurnCharacter().tag.Contains("Enemy"))
                        {
                            GameObject.Find("DiceCanvas").transform.GetChild(0).GetComponent<Dice>().EnableAllButtons();
                        } else
                        {
                            GameObject.Find("ClickTheDice").GetComponent<Text>().text = "";
                        }
                    }
                }
            }
        }
    }

    public static Character GetCurrCharacter()
    {
        return _currCharacter;
    }

    public static List<Character> GetCurrTargets()
    {
        return _currTargets;
    }

    public static void SetCurrCharacter(Character charac)
    {
        _currCharacter = charac;
    }

    public static void AddTarget(Character target)
    {
        _currTargets.Add(target);
    }

    public static void ClearTargets()
    {
        _currTargets = new List<Character>();
    }

    public static void ExecuteAttack()
    {
        foreach (Character c in _currTargets)
        {
            int damage = int.Parse(DiceManager.FindTypeTotalGameObject("AP").transform.GetChild(0).GetComponent<Text>().text);

            GameObject healthCanvas = Utilities.SearchChild("HealthCanvas", c.gameObject);
            GameObject healthBar = Utilities.SearchChild("HealthBar", healthCanvas);

            float excess = c.GetComponent<Character>().GetCurrHP() - damage;

            if (excess < 0)
            {
                GameObject currCharacter = TurnManager.GetCurrTurnCharacter().GetComponent<Character>().gameObject;
                GameObject healthCanvasChar = Utilities.SearchChild("HealthCanvas", currCharacter.gameObject);
                GameObject healthBarChar = Utilities.SearchChild("HealthBar", healthCanvasChar);

                healthBar.GetComponent<HealthBar>().ChangeHealth(Mathf.Abs(excess));
            }


            healthBar.GetComponent<HealthBar>().ChangeHealth(-damage);
        }
    }

    public static DiceType SearchDiceType(string diceTypeName)
    {

        DiceType returnDiceType = null;

        GameObject diceTypeManager = GameObject.Find("DiceTypeManager");

        foreach (DiceType dT in diceTypeManager.GetComponents<DiceType>())
        {
            if (dT.GetName().Contains(diceTypeName))
            {
                returnDiceType = dT;
            }
        }

        return returnDiceType;
    }

    public static bool APFound()
    {
        return _aPFound;
    }

    public static bool PPFound()
    {
        return _pPFound;
    }

    public static void SetAPFound(bool apFound)
    {
        _aPFound = apFound;
    }

    public static void SetPPFound(bool ppFound)
    {
        _pPFound = ppFound;
    }

    public static void ClearAllDiceTotals()
    {
        GameObject.Find("ClickTheDice").GetComponent<Text>().text = "CLICK THE DICE";

        _aPFound = false;
        _pPFound = false;

        foreach (GameObject g in GameObject.FindGameObjectsWithTag("TypeTotal"))
        {
           g.GetComponent<Text>().text = "";
           g.transform.GetChild(0).GetComponent<Text>().text = "0";
           g.transform.GetChild(0).GetComponent<Text>().enabled = false;
        }
    }

    public static GameObject FindEmptyTypeTotal()
    {
        GameObject firstEmptyType = null;

        foreach (GameObject g in GameObject.FindGameObjectsWithTag("TypeTotal"))
        {
            if (g.GetComponent<Text>().text.Equals(""))
            {
                firstEmptyType = g;
            }
        }

        return firstEmptyType;
    }

    public static GameObject FindTypeTotalGameObject(string typeTotal)
    {
        GameObject typeTotalObject = null;

        foreach (GameObject g in GameObject.FindGameObjectsWithTag("TypeTotal"))
        {
            if (g.GetComponent<Text>().text.ToUpper().Contains(typeTotal.ToUpper()))
            {
                typeTotalObject = g;
            }
        }

        return typeTotalObject;
    }

    public float GetResetDiceTime()
    {
        return resetDiceTime;
    }

    public bool ShouldResetDice()
    {
        if (!_resetManually)
        {
            bool allDiceUsed = true;

            for (int i = 0; i < GameObject.Find("DiceCanvas").transform.childCount; i++)
            {
                if (GameObject.Find("DiceCanvas").transform.GetChild(i).GetComponent<Dice>().HasStopped() == false)
                {
                    allDiceUsed = false;
                }
            }

            return allDiceUsed;
        } else
        {
            return true;
        }
    }

    public static void ResetDice()
    {
        GameObject.Find("RollTotal").GetComponent<Text>().text = "0";
        GameObject.Find("RollTotal").GetComponent<Text>().enabled = false;
        for (int i = 0; i < GameObject.Find("DiceStatsCanvas").transform.childCount; i++)
        {
            if (GameObject.Find("DiceStatsCanvas").transform.GetChild(i).name.Contains("RollValue"))
            {
                GameObject.Find("DiceStatsCanvas").transform.GetChild(i).GetComponent<Text>().text = "";
            }
        }

        for (int i = 0; i < GameObject.Find("DiceCanvas").transform.childCount; i++)
        {
            GameObject.Find("DiceCanvas").transform.GetChild(i).GetComponent<Dice>().SetStopped(false);
        }

    }

    public static void CallResetManually()
    {
        for (int j = 0; j < GameObject.Find("DiceCanvas").transform.childCount; j++)
        {
            GameObject.Find("DiceCanvas").transform.GetChild(j).GetComponent<Dice>().DisableAllButtons();
            GameObject.Find("DiceCanvas").transform.GetChild(j).gameObject.GetComponent<ShakeObject>().StopShaking();
        }

        _resetManually = true;
    }
}
