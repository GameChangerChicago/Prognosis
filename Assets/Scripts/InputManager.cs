using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private List<string> _recentClicks;

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Mouse0))
        {
            ClickHandler();
            _recentClicks.Clear();
        }
    }

    public void ClickTry(string clickableName)
    {
        _recentClicks.Add(clickableName);
    }

    private void ClickHandler()
    {
        if(_recentClicks.Contains("Pause") || _recentClicks.Contains("Skip"))
        {

        }
        else if(_recentClicks.Contains("ProfWindow") || _recentClicks.Contains("Up") || _recentClicks.Contains("Down"))
        {

        }
    }
}