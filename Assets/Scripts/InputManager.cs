using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private List<GameObject> _currenMousedOverClickables;

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
        if(!_currenMousedOverClickables.Contains(clickableObj))
        {
            _currenMousedOverClickables.Add(clickableObj);
        }
    }

    public void ClickableMousedOff(GameObject clickableObj)
    {
        if (_currenMousedOverClickables.Contains(clickableObj))
        {
            _currenMousedOverClickables.Remove(clickableObj);
        }
    }

    private void MouseUpHandler()
    {
        for (int i = 0; i < _currenMousedOverClickables.Count; i++)
        {
            if (_currenMousedOverClickables[i].name == "Pause" || _currenMousedOverClickables[i].name == "Skip")
            {
                if(_currenMousedOverClickables[i].name == "PausePlay")
                {
                    _currenMousedOverClickables[i].transform.parent.GetComponent<TimerController>().ToggglePauseTimer();
                }

                if(_currenMousedOverClickables[i].name == "Skip")
                {
                    _currenMousedOverClickables[i].transform.parent.GetComponent<TimerController>().SkipToNextDay();
                }
                break;
            }
            else if (_currenMousedOverClickables[i].name == "Professional" || _currenMousedOverClickables[i].name == "upArrow" || _currenMousedOverClickables[i].name == "downArrow")
            {
                if(_currenMousedOverClickables[i].name == "Professional")

                break;
            }
            else if (_currenMousedOverClickables[i].name == "ProfSlot" || _currenMousedOverClickables[i].name == "SendMHU" || _currenMousedOverClickables[i].name == "RecallMHU")
            {

                break;
            }
            else if (_currenMousedOverClickables[i].name == "LocationNames")
            {

                break;
            }
        }
    }

    private void MouseDownHandler()
    {

    }
}