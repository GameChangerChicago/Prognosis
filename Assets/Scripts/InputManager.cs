using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    //Dictionary for these two
    //DUh!
    private Dictionary<string, GameObject> _currentMousedOverClickables = new Dictionary<string, GameObject>();

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            MouseDownHandler();
        }
        if(Input.GetKeyUp(KeyCode.Mouse0))
        {
            MouseUpHandler();
        }
    }

    public void ClickableMousedEnter(GameObject clickableObj)
    {
        if(!_currentMousedOverClickables.ContainsValue(clickableObj))
        {
            _currentMousedOverClickables.Add(clickableObj.name, clickableObj);
        }
    }

    public void ClickableMousedExit(GameObject clickableObj)
    {
        if (_currentMousedOverClickables.ContainsValue(clickableObj))
        {
            _currentMousedOverClickables.Remove(clickableObj.name);
        }
    }

    private void MouseDownHandler()
    {
        if (_currentMousedOverClickables.ContainsKey("Professional") || _currentMousedOverClickables.ContainsKey("upArrow") || _currentMousedOverClickables.ContainsKey("downArrow"))
        {
            if (_currentMousedOverClickables.ContainsKey("Professional"))
            {
                _currentMousedOverClickables["Professional"].GetComponent<ProfessionalStack>().TakeProfessional();
            }
        }
    }

    private void MouseUpHandler()
    {
        if (_currentMousedOverClickables.ContainsKey("PausePlay") || _currentMousedOverClickables.ContainsKey("FastForward") || _currentMousedOverClickables.ContainsKey("GoalButton"))
        {
            if (_currentMousedOverClickables.ContainsKey("PausePlay"))
            {
                _currentMousedOverClickables["PausePlay"].transform.parent.GetComponent<TimerController>().ToggglePauseTimer();
            }

            if (_currentMousedOverClickables.ContainsKey("FastForward"))
            {
                _currentMousedOverClickables["FastForward"].transform.parent.GetComponent<TimerController>().SkipToNextDay();
            }

            if(_currentMousedOverClickables.ContainsKey("GoalButton"))
            {
                Debug.Log("????");
                _currentMousedOverClickables["GoalButton"].GetComponent<GoalMenuController>().ShowGoalInfo();
            }
        }
        else if (_currentMousedOverClickables.ContainsKey("Professional") || _currentMousedOverClickables.ContainsKey("upArrow") || _currentMousedOverClickables.ContainsKey("downArrow"))
        {
            if (_currentMousedOverClickables.ContainsKey("upArrow"))
            {
                _currentMousedOverClickables["upArrow"].transform.parent.GetComponent<ProfessionalsMenu>().MoveUp();
            }
            else if (_currentMousedOverClickables.ContainsKey("downArrow"))
            {
                _currentMousedOverClickables["downArrow"].transform.parent.GetComponent<ProfessionalsMenu>().MoveDown();
            }
        }
        else if (_currentMousedOverClickables.ContainsKey("ProfessionalSlot") || _currentMousedOverClickables.ContainsKey("LockRecalButton"))
        {
            if(_currentMousedOverClickables.ContainsKey("ProfessionalSlot"))
            {
                _currentMousedOverClickables["ProfessionalSlot"].GetComponent<ProfessionalSlot>().RemoveProfessional();
            }
            else if(_currentMousedOverClickables.ContainsKey("LockRecalButton"))
            {
                _currentMousedOverClickables["LockRacalButton"].transform.parent.parent.GetComponent<TargetLocation>().SendMHU();
            }
        }
        else if (_currentMousedOverClickables.ContainsKey("Ash Park") ||
            _currentMousedOverClickables.ContainsKey("Freemason") ||
            _currentMousedOverClickables.ContainsKey("Philmont") ||
            _currentMousedOverClickables.ContainsKey("Quinn Square") ||
            _currentMousedOverClickables.ContainsKey("East Bea Heights"))
        {
            if(_currentMousedOverClickables.ContainsKey("Ash Park"))
            {
                _currentMousedOverClickables["Ash Park"].GetComponent<TargetLocation>().Activate();
            }
            else if (_currentMousedOverClickables.ContainsKey("Freemason"))
            {
                _currentMousedOverClickables["Freemason"].GetComponent<TargetLocation>().Activate();
            }
            else if (_currentMousedOverClickables.ContainsKey("Philmont"))
            {
                _currentMousedOverClickables["Philmont"].GetComponent<TargetLocation>().Activate();
            }
            else if (_currentMousedOverClickables.ContainsKey("Quinn Square"))
            {
                _currentMousedOverClickables["Quinn Square"].GetComponent<TargetLocation>().Activate();
            }
            else if (_currentMousedOverClickables.ContainsKey("East Bea Heights"))
            {
                _currentMousedOverClickables["East Bea Heights"].GetComponent<TargetLocation>().Activate();
            }
        }
    }
}