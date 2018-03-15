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
            if (_currentMousedOverClickables.ContainsKey(progButton.name))
                _currentMousedOverClickables.Remove(progButton.name);

            _currentMousedOverClickables.Add(progButton.name, progButton);
        }

        //Top UI Level
        if(_currentMousedOverClickables.ContainsKey("PausePlay") ||
           _currentMousedOverClickables.ContainsKey("FastForward") ||
           _currentMousedOverClickables.ContainsKey("GoalButton") ||
           _currentMousedOverClickables.ContainsKey("Close Button"))
        {
            if (_currentMousedOverClickables.ContainsKey("PausePlay"))
            {
                newButton = "PausePlay";
                _currentMousedOverClickables["PausePlay"].HighlightButton();
            }

            if (_currentMousedOverClickables.ContainsKey("FastForward"))
            {
                newButton = "FastForward";
                _currentMousedOverClickables["FastForward"].HighlightButton();
            }

            if (_currentMousedOverClickables.ContainsKey("GoalButton"))
            {
                newButton = "GoalButton";
                _currentMousedOverClickables["GoalButton"].HighlightButton();
            }

            if(_currentMousedOverClickables.ContainsKey("Close Button"))
            {
                newButton = "Close Button";
                _currentMousedOverClickables["Close Button"].HighlightButton();
            }
        }//Professional Menu
        else if (_currentMousedOverClickables.ContainsKey("Professional") || _currentMousedOverClickables.ContainsKey("upArrow") || _currentMousedOverClickables.ContainsKey("downArrow"))
        {
            if (_currentMousedOverClickables.ContainsKey("upArrow"))
            {
                newButton = "upArrow";
                _currentMousedOverClickables["upArrow"].HighlightButton();
            }
            else if (_currentMousedOverClickables.ContainsKey("downArrow"))
            {
                newButton = "downArrow";
                _currentMousedOverClickables["downArrow"].HighlightButton();
            }
            else if (_currentMousedOverClickables.ContainsKey("Professional"))
            {
                newButton = "Professional";
                _currentMousedOverClickables["Professional"].HighlightButton();
            }
        }//Location Menus
        else if (_currentMousedOverClickables.ContainsKey("ProfessionalSlot") || _currentMousedOverClickables.ContainsKey("LockRecalButton"))
        {
            if (_currentMousedOverClickables.ContainsKey("ProfessionalSlot"))
            {
                newButton = "ProfessionalSlot";
                _currentMousedOverClickables["ProfessionalSlot"].HighlightButton();
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
            }
            else if (_currentMousedOverClickables.ContainsKey("Freemason"))
            {
                newButton = "Freemason";
                _currentMousedOverClickables["Freemason"].HighlightButton();
            }
            else if (_currentMousedOverClickables.ContainsKey("Philmont"))
            {
                newButton = "Philmont";
                _currentMousedOverClickables["Philmont"].HighlightButton();
            }
            else if (_currentMousedOverClickables.ContainsKey("Quinn Square"))
            {
                newButton = "Quinn Square";
                _currentMousedOverClickables["Quinn Square"].HighlightButton();
            }
            else if (_currentMousedOverClickables.ContainsKey("East Bea Heights"))
            {
                newButton = "East Bea Heights";
                _currentMousedOverClickables["East Bea Heights"].HighlightButton();
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
                _currentMousedOverClickables["Professional"].ButtonAction();
            }
        }
    }

    private void MouseUpHandler()
    {
        //Top UI Level
        if (_currentMousedOverClickables.ContainsKey("PausePlay") ||
           _currentMousedOverClickables.ContainsKey("FastForward") ||
           _currentMousedOverClickables.ContainsKey("GoalButton") ||
           _currentMousedOverClickables.ContainsKey("Close Button"))
        {
            if (_currentMousedOverClickables.ContainsKey("PausePlay"))
            {
                _currentMousedOverClickables["PausePlay"].ButtonAction();
            }

            if (_currentMousedOverClickables.ContainsKey("FastForward"))
            {
                _currentMousedOverClickables["FastForward"].ButtonAction();
            }

            if(_currentMousedOverClickables.ContainsKey("GoalButton"))
            {
                _currentMousedOverClickables["GoalButton"].ButtonAction();
            }

            if(_currentMousedOverClickables.ContainsKey("Close Button"))
            {
                _currentMousedOverClickables["Close Button"].ButtonAction();
            }
        }//Professional Menu
        else if (_currentMousedOverClickables.ContainsKey("Professional") || _currentMousedOverClickables.ContainsKey("upArrow") || _currentMousedOverClickables.ContainsKey("downArrow"))
        {
            if (_currentMousedOverClickables.ContainsKey("upArrow"))
            {
                _currentMousedOverClickables["upArrow"].ButtonAction();
            }
            else if (_currentMousedOverClickables.ContainsKey("downArrow"))
            {
                _currentMousedOverClickables["downArrow"].ButtonAction();
            }
        }//Location Menus
        else if (_currentMousedOverClickables.ContainsKey("ProfessionalSlot") || _currentMousedOverClickables.ContainsKey("LockRecalButton"))
        {
            if(_currentMousedOverClickables.ContainsKey("ProfessionalSlot"))
            {
                _currentMousedOverClickables["ProfessionalSlot"].ButtonAction();
            }
        }//Locations
        else if (_currentMousedOverClickables.ContainsKey("Ash Park") ||
                 _currentMousedOverClickables.ContainsKey("Freemason") ||
                 _currentMousedOverClickables.ContainsKey("Philmont") ||
                 _currentMousedOverClickables.ContainsKey("Quinn Square") ||
                 _currentMousedOverClickables.ContainsKey("East Bea Heights"))
        {
            if(_currentMousedOverClickables.ContainsKey("Ash Park"))
            {
                _currentMousedOverClickables["Ash Park"].ButtonAction();
            }
            else if (_currentMousedOverClickables.ContainsKey("Freemason"))
            {
                _currentMousedOverClickables["Freemason"].ButtonAction();
            }
            else if (_currentMousedOverClickables.ContainsKey("Philmont"))
            {
                _currentMousedOverClickables["Philmont"].ButtonAction();
            }
            else if (_currentMousedOverClickables.ContainsKey("Quinn Square"))
            {
                _currentMousedOverClickables["Quinn Square"].ButtonAction();
            }
            else if (_currentMousedOverClickables.ContainsKey("East Bea Heights"))
            {
                _currentMousedOverClickables["East Bea Heights"].ButtonAction();
            }
        }
    }
}