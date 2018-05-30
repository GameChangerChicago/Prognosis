using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private Dictionary<string, PrognosisButton> _currentMousedOverClickables = new Dictionary<string, PrognosisButton>();
    private List<string> _buttonStringsLayer0 = new List<string>();
    private List<string> _buttonStringsLayer1 = new List<string>();
    private List<string> _buttonStringsLayer2 = new List<string>();
    private List<string> _buttonStringsLayer3 = new List<string>();
    private List<string> _buttonStringsLayer4 = new List<string>();

    private void Start()
    {
        foreach (PrognosisButton pb in FindObjectsOfType<PrognosisButton>())
        {
            switch(pb.ButtonLayer)
            {
                case 0:
                    if (!_buttonStringsLayer0.Contains(pb.name))
                        _buttonStringsLayer0.Add(pb.name);
                    break;
                case 1:
                    if (!_buttonStringsLayer1.Contains(pb.name))
                        _buttonStringsLayer1.Add(pb.name);
                    break;
                case 2:
                    if (!_buttonStringsLayer2.Contains(pb.name))
                        _buttonStringsLayer2.Add(pb.name);
                    break;
                case 3:
                    if (!_buttonStringsLayer3.Contains(pb.name))
                        _buttonStringsLayer3.Add(pb.name);
                    break;
                case 4:
                    if (!_buttonStringsLayer4.Contains(pb.name))
                        _buttonStringsLayer4.Add(pb.name);
                    break;
                default:
                    break;
            }
        }
    }

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

        if(Input.GetKeyUp(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    
    private string GetButtonLayer()
    {
        foreach (string layerString in _buttonStringsLayer0)
        {
            if (_currentMousedOverClickables.ContainsKey(layerString))
            {
                return layerString;
            }
        }

        foreach (string layerString in _buttonStringsLayer1)
        {
            if (_currentMousedOverClickables.ContainsKey(layerString))
            {
                return layerString;
            }
        }

        foreach (string layerString in _buttonStringsLayer2)
        {
            if (_currentMousedOverClickables.ContainsKey(layerString))
            {
                return layerString;
            }
        }

        foreach (string layerString in _buttonStringsLayer3)
        {
            if (_currentMousedOverClickables.ContainsKey(layerString))
            {
                return layerString;
            }
        }

        foreach (string layerString in _buttonStringsLayer4)
        {
            if (_currentMousedOverClickables.ContainsKey(layerString))
            {
                return layerString;
            }
        }

        return "error";
    }

    public void ClickableMousedEnter(PrognosisButton progButton)
    {
        //string newButton = "";

        if(!_currentMousedOverClickables.ContainsValue(progButton))
        {
            if (_currentMousedOverClickables.ContainsKey(progButton.name))
                _currentMousedOverClickables.Remove(progButton.name);

            _currentMousedOverClickables.Add(progButton.name, progButton);
        }

        string currentButton = GetButtonLayer();

        _currentMousedOverClickables[currentButton].HighlightButton();

        //if(_currentMousedOverClickables.ContainsKey("ToolTip"))
        //{
        //    newButton = "ToolTip";
        //    _currentMousedOverClickables["ToolTip"].HighlightButton();
        //}//Top UI Level
        //else if (_currentMousedOverClickables.ContainsKey("PausePlay") ||
        //        _currentMousedOverClickables.ContainsKey("FastForward") ||
        //        _currentMousedOverClickables.ContainsKey("GoalButton") ||
        //        _currentMousedOverClickables.ContainsKey("Close Button"))
        //{
        //    if (_currentMousedOverClickables.ContainsKey("PausePlay"))
        //    {
        //        newButton = "PausePlay";
        //        _currentMousedOverClickables["PausePlay"].HighlightButton();
        //    }

        //    if (_currentMousedOverClickables.ContainsKey("FastForward"))
        //    {
        //        newButton = "FastForward";
        //        _currentMousedOverClickables["FastForward"].HighlightButton();
        //    }

        //    if (_currentMousedOverClickables.ContainsKey("GoalButton"))
        //    {
        //        newButton = "GoalButton";
        //        _currentMousedOverClickables["GoalButton"].HighlightButton();
        //    }

        //    if(_currentMousedOverClickables.ContainsKey("Close Button"))
        //    {
        //        newButton = "Close Button";
        //        _currentMousedOverClickables["Close Button"].HighlightButton();
        //    }
        //}//Professional Menu
        //else if (_currentMousedOverClickables.ContainsKey("Professional") || _currentMousedOverClickables.ContainsKey("upArrow") || _currentMousedOverClickables.ContainsKey("downArrow"))
        //{
        //    if (_currentMousedOverClickables.ContainsKey("upArrow"))
        //    {
        //        newButton = "upArrow";
        //        _currentMousedOverClickables["upArrow"].HighlightButton();
        //    }
        //    else if (_currentMousedOverClickables.ContainsKey("downArrow"))
        //    {
        //        newButton = "downArrow";
        //        _currentMousedOverClickables["downArrow"].HighlightButton();
        //    }
        //    else if (_currentMousedOverClickables.ContainsKey("Professional"))
        //    {
        //        newButton = "Professional";
        //        _currentMousedOverClickables["Professional"].HighlightButton();
        //    }
        //}//Location Menus
        //else if (_currentMousedOverClickables.ContainsKey("ProfessionalSlot") || _currentMousedOverClickables.ContainsKey("LockRecalButton"))
        //{
        //    if (_currentMousedOverClickables.ContainsKey("ProfessionalSlot"))
        //    {
        //        newButton = "ProfessionalSlot";
        //        _currentMousedOverClickables["ProfessionalSlot"].HighlightButton();
        //    }
        //}//Locations
        //else if (_currentMousedOverClickables.ContainsKey("Ash Park") ||
        //         _currentMousedOverClickables.ContainsKey("Freemason") ||
        //         _currentMousedOverClickables.ContainsKey("Philmont") ||
        //         _currentMousedOverClickables.ContainsKey("Quinn Square") ||
        //         _currentMousedOverClickables.ContainsKey("East Bea Heights"))
        //{
        //    if (_currentMousedOverClickables.ContainsKey("Ash Park"))
        //    {
        //        newButton = "Ash Park";
        //        _currentMousedOverClickables["Ash Park"].HighlightButton();
        //    }
        //    else if (_currentMousedOverClickables.ContainsKey("Freemason"))
        //    {
        //        newButton = "Freemason";
        //        _currentMousedOverClickables["Freemason"].HighlightButton();
        //    }
        //    else if (_currentMousedOverClickables.ContainsKey("Philmont"))
        //    {
        //        newButton = "Philmont";
        //        _currentMousedOverClickables["Philmont"].HighlightButton();
        //    }
        //    else if (_currentMousedOverClickables.ContainsKey("Quinn Square"))
        //    {
        //        newButton = "Quinn Square";
        //        _currentMousedOverClickables["Quinn Square"].HighlightButton();
        //    }
        //    else if (_currentMousedOverClickables.ContainsKey("East Bea Heights"))
        //    {
        //        newButton = "East Bea Heights";
        //        _currentMousedOverClickables["East Bea Heights"].HighlightButton();
        //    }
        //}

        if(currentButton != "error")
        {
            foreach (PrognosisButton button in _currentMousedOverClickables.Values)
            {
                if (button.name != currentButton)
                    button.UnhighlightButton();
            }
        }
        else
        {
            Debug.LogWarning("This button isn't part of any known layer...");
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
        string currentButton = GetButtonLayer();

        if (currentButton == "Professional")
            _currentMousedOverClickables[currentButton].ButtonAction();

        //if (_currentMousedOverClickables.ContainsKey("Professional") || _currentMousedOverClickables.ContainsKey("upArrow") || _currentMousedOverClickables.ContainsKey("downArrow"))
        //{
        //    if (_currentMousedOverClickables.ContainsKey("Professional"))
        //    {
        //        _currentMousedOverClickables["Professional"].ButtonAction();
        //    }
        //}
    }

    private void MouseUpHandler()
    {
        string currentButton = GetButtonLayer();

        if (currentButton == "ToolTip")
        {
            _currentMousedOverClickables[currentButton].ButtonAction();
            _currentMousedOverClickables.Remove(currentButton);
        }
        else
            _currentMousedOverClickables[currentButton].ButtonAction();

        //Top UI Level
        //if (_currentMousedOverClickables.ContainsKey("ToolTip"))
        //{
        //    _currentMousedOverClickables["ToolTip"].ButtonAction();
        //    _currentMousedOverClickables.Remove("ToolTip");
        //}
        //else if (_currentMousedOverClickables.ContainsKey("PausePlay") ||
        //        _currentMousedOverClickables.ContainsKey("FastForward") ||
        //        _currentMousedOverClickables.ContainsKey("GoalButton") ||
        //        _currentMousedOverClickables.ContainsKey("Close Button"))
        //{
        //    if (_currentMousedOverClickables.ContainsKey("PausePlay"))
        //    {
        //        _currentMousedOverClickables["PausePlay"].ButtonAction();
        //    }

        //    if (_currentMousedOverClickables.ContainsKey("FastForward"))
        //    {
        //        _currentMousedOverClickables["FastForward"].ButtonAction();
        //    }

        //    if(_currentMousedOverClickables.ContainsKey("GoalButton"))
        //    {
        //        _currentMousedOverClickables["GoalButton"].ButtonAction();
        //    }

        //    if(_currentMousedOverClickables.ContainsKey("Close Button"))
        //    {
        //        _currentMousedOverClickables["Close Button"].ButtonAction();
        //    }
        //}//Professional Menu
        //else if (_currentMousedOverClickables.ContainsKey("Professional") || _currentMousedOverClickables.ContainsKey("upArrow") || _currentMousedOverClickables.ContainsKey("downArrow"))
        //{
        //    if (_currentMousedOverClickables.ContainsKey("upArrow"))
        //    {
        //        _currentMousedOverClickables["upArrow"].ButtonAction();
        //    }
        //    else if (_currentMousedOverClickables.ContainsKey("downArrow"))
        //    {
        //        _currentMousedOverClickables["downArrow"].ButtonAction();
        //    }
        //}//Location Menus
        //else if (_currentMousedOverClickables.ContainsKey("ProfessionalSlot") || _currentMousedOverClickables.ContainsKey("LockRecalButton"))
        //{
        //    if(_currentMousedOverClickables.ContainsKey("ProfessionalSlot"))
        //    {
        //        _currentMousedOverClickables["ProfessionalSlot"].ButtonAction();
        //    }
        //}//Locations
        //else if (_currentMousedOverClickables.ContainsKey("Ash Park") ||
        //         _currentMousedOverClickables.ContainsKey("Freemason") ||
        //         _currentMousedOverClickables.ContainsKey("Philmont") ||
        //         _currentMousedOverClickables.ContainsKey("Quinn Square") ||
        //         _currentMousedOverClickables.ContainsKey("East Bea Heights"))
        //{
        //    if(_currentMousedOverClickables.ContainsKey("Ash Park"))
        //    {
        //        _currentMousedOverClickables["Ash Park"].ButtonAction();
        //    }
        //    else if (_currentMousedOverClickables.ContainsKey("Freemason"))
        //    {
        //        _currentMousedOverClickables["Freemason"].ButtonAction();
        //    }
        //    else if (_currentMousedOverClickables.ContainsKey("Philmont"))
        //    {
        //        _currentMousedOverClickables["Philmont"].ButtonAction();
        //    }
        //    else if (_currentMousedOverClickables.ContainsKey("Quinn Square"))
        //    {
        //        _currentMousedOverClickables["Quinn Square"].ButtonAction();
        //    }
        //    else if (_currentMousedOverClickables.ContainsKey("East Bea Heights"))
        //    {
        //        _currentMousedOverClickables["East Bea Heights"].ButtonAction();
        //    }
        //}
    }
}