using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private Dictionary<string, PrognosisButton> _currentMousedOverClickables = new Dictionary<string, PrognosisButton>();
    public List<string> ButtonStringsLayer0 = new List<string>();
    public List<string> ButtonStringsLayer1 = new List<string>();
    public List<string> ButtonStringsLayer2 = new List<string>();
    public List<string> ButtonStringsLayer3 = new List<string>();
    public List<string> ButtonStringsLayer4 = new List<string>();

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
        foreach (string layerString in ButtonStringsLayer0)
        {
            if (_currentMousedOverClickables.ContainsKey(layerString))
            {
                return layerString;
            }
        }

        foreach (string layerString in ButtonStringsLayer1)
        {
            if (_currentMousedOverClickables.ContainsKey(layerString))
            {
                return layerString;
            }
        }

        foreach (string layerString in ButtonStringsLayer2)
        {
            if (_currentMousedOverClickables.ContainsKey(layerString))
            {
                return layerString;
            }
        }

        foreach (string layerString in ButtonStringsLayer3)
        {
            if (_currentMousedOverClickables.ContainsKey(layerString))
            {
                return layerString;
            }
        }

        foreach (string layerString in ButtonStringsLayer4)
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
        if(!_currentMousedOverClickables.ContainsValue(progButton))
        {
            if (_currentMousedOverClickables.ContainsKey(progButton.name))
                _currentMousedOverClickables.Remove(progButton.name);

            _currentMousedOverClickables.Add(progButton.name, progButton);
        }

        string currentButton = GetButtonLayer();

        _currentMousedOverClickables[currentButton].HighlightButton();

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
    }

    private void MouseUpHandler()
    {
        string currentButton = GetButtonLayer();

        if (currentButton == "ToolTip")
        {
            _currentMousedOverClickables[currentButton].ButtonAction();
            _currentMousedOverClickables.Remove(currentButton);
        }
        else if(currentButton != "Professional")
            _currentMousedOverClickables[currentButton].ButtonAction();
    }
}