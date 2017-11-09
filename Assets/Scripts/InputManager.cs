using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    //Dictionary for these two
    //DUh!
    private List<GameObject> _currentMousedOverClickables;
    private List<string> _currentClickableNames;

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

    public void ClickableMousedOver(GameObject clickableObj)
    {
        if(!_currentMousedOverClickables.Contains(clickableObj))
        {
            _currentMousedOverClickables.Add(clickableObj);
            _currentClickableNames.Add(clickableObj.name);
        }
    }

    public void ClickableMousedOff(GameObject clickableObj)
    {
        if (_currentMousedOverClickables.Contains(clickableObj))
        {
            _currentMousedOverClickables.Remove(clickableObj);
            _currentClickableNames.Add(clickableObj.name);
        }
    }

    private void MouseDownHandler()
    {
        if (_currentClickableNames.Contains("Pause") || _currentClickableNames.Contains("Skip"))
        {

        }
        else if (_currentClickableNames.Contains("Professional") || _currentClickableNames.Contains("upArrow") || _currentClickableNames.Contains("downArrow"))
        {
            if (_currentClickableNames.Contains("Professional"))
            {
                //get prof
            }
        }
        else if (_currentClickableNames.Contains("ProfSlot") || _currentClickableNames.Contains("SendMHU") || _currentClickableNames.Contains("RecallMHU"))
        {

        }
        else if (_currentClickableNames.Contains("LocationNames"))
        {

        }
    }

    private void MouseUpHandler()
    {
        if (_currentClickableNames.Contains("Pause") || _currentClickableNames.Contains("Skip"))
        {
            if (_currentClickableNames.Contains("PausePlay"))
            {
                _currentMousedOverClickables//[i].transform.parent.GetComponent<TimerController>().ToggglePauseTimer();
            }

            if (_currentMousedOverClickables[i].name == "Skip")
            {
                _currentMousedOverClickables[i].transform.parent.GetComponent<TimerController>().SkipToNextDay();
            }
        }
        else if (_currentMousedOverClickables[i].name == "Professional" || _currentMousedOverClickables[i].name == "upArrow" || _currentMousedOverClickables[i].name == "downArrow")
        {
            if (_currentMousedOverClickables[i].name == "upArrow")
            {

            }
            else if (_currentMousedOverClickables[i].name == "upArrow")
            {

            }
        }
        else if (_currentMousedOverClickables[i].name == "ProfSlot" || _currentMousedOverClickables[i].name == "SendMHU" || _currentMousedOverClickables[i].name == "RecallMHU")
        {

        }
        else if (_currentMousedOverClickables[i].name == "LocationNames")
        {

        }
    }
}