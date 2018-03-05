using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    //Dictionary for these two
    //DUh!
    private Dictionary<string, PrognosisButton> _currentMousedOverClickables = new Dictionary<string, PrognosisButton>();

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

    public void ClickableMousedEnter(PrognosisButton progButton)
    {
        string newButton = "";

        if(!_currentMousedOverClickables.ContainsValue(progButton))
        {
            _currentMousedOverClickables.Add(progButton.name, progButton);
        }

        //Top UI Level
        if(_currentMousedOverClickables.ContainsKey("PausePlay") || _currentMousedOverClickables.ContainsKey("FastForward") || _currentMousedOverClickables.ContainsKey("GoalButton"))
        {
            if (_currentMousedOverClickables.ContainsKey("PausePlay"))
            {
                newButton = "PausePlay";
                _currentMousedOverClickables["PausePlay"].HighlightButton();//.transform.parent.GetComponent<TimerController>().HighlightOn();
            }

            if (_currentMousedOverClickables.ContainsKey("FastForward"))
            {
                newButton = "FastForward";
                _currentMousedOverClickables["FastForward"].HighlightButton();
                //_currentMousedOverClickables["FastForward"].transform.parent.GetComponent<TimerController>().TurnOn
            }

            if (_currentMousedOverClickables.ContainsKey("GoalButton"))
            {
                newButton = "GoalButton";
                _currentMousedOverClickables["GoalButton"].HighlightButton();
                //_currentMousedOverClickables["GoalButton"].GetComponent<GoalMenuController>().TurnOn
            }
        }//Professional Menu
        else if (_currentMousedOverClickables.ContainsKey("Professional") || _currentMousedOverClickables.ContainsKey("upArrow") || _currentMousedOverClickables.ContainsKey("downArrow"))
        {
            if (_currentMousedOverClickables.ContainsKey("upArrow"))
            {
                newButton = "upArrow";
                _currentMousedOverClickables["upArrow"].HighlightButton();
                //_currentMousedOverClickables["upArrow"].transform.parent.GetComponent<ProfessionalsMenu>().TurnOn
            }
            else if (_currentMousedOverClickables.ContainsKey("downArrow"))
            {
                newButton = "downArrow";
                _currentMousedOverClickables["downArrow"].HighlightButton();
                //_currentMousedOverClickables["downArrow"].transform.parent.GetComponent<ProfessionalsMenu>().TurnOn
            }
            else if (_currentMousedOverClickables.ContainsKey("Professional"))
            {
                newButton = "Professional";
                _currentMousedOverClickables["Professional"].HighlightButton();
                //ProfessionalStack.OnHoverTool.TurnOn
            }
        }//Location Menus
        else if (_currentMousedOverClickables.ContainsKey("ProfessionalSlot") || _currentMousedOverClickables.ContainsKey("LockRecalButton"))
        {
            if (_currentMousedOverClickables.ContainsKey("ProfessionalSlot"))
            {
                newButton = "ProfessionalSlot";
                _currentMousedOverClickables["ProfessionalSlot"].HighlightButton();
                //_currentMousedOverClickables["ProfessionalSlot"].GetComponent<ProfessionalSlot>().OnHoverTool.TurnOn
            }
        }//Locations
        else if (_currentMousedOverClickables.ContainsKey("Ash Park") ||
                 _currentMousedOverClickables.ContainsKey("Freemason") ||
                 _currentMousedOverClickables.ContainsKey("Philmont") ||
                 _currentMousedOverClickables.ContainsKey("Quinn Square") ||
                 _currentMousedOverClickables.ContainsKey("East Bea Heights"))
        {
            if (_currentMousedOverClickables.ContainsKey("Ash Park"))
            {
                newButton = "Ash Park";
                _currentMousedOverClickables["Ash Park"].HighlightButton();
                //_currentMousedOverClickables["Ash Park"].GetComponent<TargetLocation>().TurnOn
            }
            else if (_currentMousedOverClickables.ContainsKey("Freemason"))
            {
                newButton = "Freemason";
                _currentMousedOverClickables["Freemason"].HighlightButton();
                //_currentMousedOverClickables["Freemason"].GetComponent<TargetLocation>().TurnOn
            }
            else if (_currentMousedOverClickables.ContainsKey("Philmont"))
            {
                newButton = "Philmont";
                _currentMousedOverClickables["Philmont"].HighlightButton();
                //_currentMousedOverClickables["Philmont"].GetComponent<TargetLocation>().TurnOn
            }
            else if (_currentMousedOverClickables.ContainsKey("Quinn Square"))
            {
                newButton = "Quinn Square";
                _currentMousedOverClickables["Quinn Square"].HighlightButton();
                //_currentMousedOverClickables["Quinn Square"].GetComponent<TargetLocation>().TurnOn
            }
            else if (_currentMousedOverClickables.ContainsKey("East Bea Heights"))
            {
                newButton = "East Bea Heights";
                _currentMousedOverClickables["East Bea Heights"].HighlightButton();
                //_currentMousedOverClickables["East Bea Heights"].GetComponent<TargetLocation>().TurnOn
            }
        }

        if(newButton != "")
        {
            foreach (PrognosisButton button in _currentMousedOverClickables.Values)
            {
                if (button.name != newButton)
                    button.UnhighlightButton();
            }
        }
    }

    public void ClickableMousedExit(PrognosisButton progButton)
    {
        if (_currentMousedOverClickables.ContainsValue(progButton))
        {
            _currentMousedOverClickables.Remove(progButton.name);
        }

        progButton.UnhighlightButton();

        foreach (PrognosisButton button in _currentMousedOverClickables.Values)
        {
            ClickableMousedEnter(button);
        }
    }

    private void MouseDownHandler()
    {
        if (_currentMousedOverClickables.ContainsKey("Professional") || _currentMousedOverClickables.ContainsKey("upArrow") || _currentMousedOverClickables.ContainsKey("downArrow"))
        {
            if (_currentMousedOverClickables.ContainsKey("Professional"))
            {
                _currentMousedOverClickables["Professional"].ButtonAction();//.GetComponent<ProfessionalStack>().TakeProfessional();
            }
        }
    }

    private void MouseUpHandler()
    {
        if (_currentMousedOverClickables.ContainsKey("PausePlay") || _currentMousedOverClickables.ContainsKey("FastForward") || _currentMousedOverClickables.ContainsKey("GoalButton"))
        {
            if (_currentMousedOverClickables.ContainsKey("PausePlay"))
            {
                _currentMousedOverClickables["PausePlay"].ButtonAction();//.transform.parent.GetComponent<TimerController>().ToggglePauseTimer();
            }

            if (_currentMousedOverClickables.ContainsKey("FastForward"))
            {
                _currentMousedOverClickables["FastForward"].ButtonAction();//.transform.parent.GetComponent<TimerController>().SkipToNextDay();
            }

            if(_currentMousedOverClickables.ContainsKey("GoalButton"))
            {
                _currentMousedOverClickables["GoalButton"].ButtonAction();//.GetComponent<GoalMenuController>().ShowGoalInfo();
            }
        }
        else if (_currentMousedOverClickables.ContainsKey("Professional") || _currentMousedOverClickables.ContainsKey("upArrow") || _currentMousedOverClickables.ContainsKey("downArrow"))
        {
            if (_currentMousedOverClickables.ContainsKey("upArrow"))
            {
                _currentMousedOverClickables["upArrow"].ButtonAction();//.transform.parent.GetComponent<ProfessionalsMenu>().MoveUp();
            }
            else if (_currentMousedOverClickables.ContainsKey("downArrow"))
            {
                _currentMousedOverClickables["downArrow"].ButtonAction();//.transform.parent.GetComponent<ProfessionalsMenu>().MoveDown();
            }
        }
        else if (_currentMousedOverClickables.ContainsKey("ProfessionalSlot") || _currentMousedOverClickables.ContainsKey("LockRecalButton"))
        {
            if(_currentMousedOverClickables.ContainsKey("ProfessionalSlot"))
            {
                _currentMousedOverClickables["ProfessionalSlot"].ButtonAction();//.GetComponent<ProfessionalSlot>().RemoveProfessional();
            }
            //else if(_currentMousedOverClickables.ContainsKey("LockRecalButton"))
            //{
            //    _currentMousedOverClickables["LockRacalButton"].ButtonAction();//.transform.parent.parent.GetComponent<TargetLocation>().SendMHU();
            //}
        }
        else if (_currentMousedOverClickables.ContainsKey("Ash Park") ||
                 _currentMousedOverClickables.ContainsKey("Freemason") ||
                 _currentMousedOverClickables.ContainsKey("Philmont") ||
                 _currentMousedOverClickables.ContainsKey("Quinn Square") ||
                 _currentMousedOverClickables.ContainsKey("East Bea Heights"))
        {
            if(_currentMousedOverClickables.ContainsKey("Ash Park"))
            {
                _currentMousedOverClickables["Ash Park"].ButtonAction();//.GetComponent<TargetLocation>().Activate();
            }
            else if (_currentMousedOverClickables.ContainsKey("Freemason"))
            {
                _currentMousedOverClickables["Freemason"].ButtonAction();//.GetComponent<TargetLocation>().Activate();
            }
            else if (_currentMousedOverClickables.ContainsKey("Philmont"))
            {
                _currentMousedOverClickables["Philmont"].ButtonAction();//.GetComponent<TargetLocation>().Activate();
            }
            else if (_currentMousedOverClickables.ContainsKey("Quinn Square"))
            {
                _currentMousedOverClickables["Quinn Square"].ButtonAction();//.GetComponent<TargetLocation>().Activate();
            }
            else if (_currentMousedOverClickables.ContainsKey("East Bea Heights"))
            {
                _currentMousedOverClickables["East Bea Heights"].ButtonAction();//.GetComponent<TargetLocation>().Activate();
            }
        }
    }
}