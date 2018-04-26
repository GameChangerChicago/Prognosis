using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrognosisButton : MonoBehaviour
{
    public MonoBehaviour ButtonScript;
    private InputManager _theInputManager;
    private Collider2D _theCollider;
    private bool _mousedOn;

    private void Start()
    {
        _theInputManager = FindObjectOfType<InputManager>();
        _theCollider = this.GetComponent<Collider2D>();
    }

    private void Update()
    {
        if(!_mousedOn && _theCollider.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
        {
            _theInputManager.ClickableMousedEnter(this);
            _mousedOn = true;
        }
        else if(_mousedOn && !_theCollider.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
        {
            _theInputManager.ClickableMousedExit(this);
            _mousedOn = false;
        }
    }

    public void HighlightButton()
    {
        if(this.ButtonScript.GetType() == typeof(TutorialToolTip))
        {
            (ButtonScript as TutorialToolTip).HighlightOn();
        }
        else if (this.ButtonScript.GetType() == typeof(TimerController))
        {
            if (this.name == "PausePlay")
                (ButtonScript as TimerController).HighlightPausePlayOn();
            else if(this.name == "FastForward")
                (ButtonScript as TimerController).HighlightFastForwardOn();
        }
        else if(this.ButtonScript.GetType() == typeof(GoalMenuController))
        {
            if (this.name == "GoalButton")
                (ButtonScript as GoalMenuController).HighlightGoalOn();
            else if (this.name == "Close Button")
                (ButtonScript as GoalMenuController).HighlightCloseOn();
        }
        else if (this.ButtonScript.GetType() == typeof(MessageManager))
        {
            (ButtonScript as MessageManager).HighlightOn();
        }
        else if(this.ButtonScript.GetType() == typeof(ProfessionalStack))
        {
            (ButtonScript as ProfessionalStack).OnHoverTool.HighlightOn();
        }
        else if (this.ButtonScript.GetType() == typeof(ProfessionalsMenu))
        {
            if (this.name == "upArrow")
                (ButtonScript as ProfessionalsMenu).HighlightUpArrowOn();
            else if(this.name == "downArrow")
                (ButtonScript as ProfessionalsMenu).HighlightDownArrowOn();
        }
        else if (this.ButtonScript.GetType() == typeof(ProfessionalSlot))
        {
            (ButtonScript as ProfessionalSlot).OnHoverTool.HighlightOn();
        }
        else if (this.ButtonScript.GetType() == typeof(TargetLocation))
        {
            (ButtonScript as TargetLocation).HighlightOn();
        }
    }

    public void UnhighlightButton()
    {
        if (this.ButtonScript.GetType() == typeof(TutorialToolTip))
        {
            (ButtonScript as TutorialToolTip).HighlightOff();
        }
        else if (this.ButtonScript.GetType() == typeof(TimerController))
        {
            if (this.name == "PausePlay")
                (ButtonScript as TimerController).HighlightPausePlayOff();
            else if (this.name == "FastForward")
                (ButtonScript as TimerController).HighlightFastForwardOff();
        }
        else if (this.ButtonScript.GetType() == typeof(GoalMenuController))
        {
            if (this.name == "GoalButton")
                (ButtonScript as GoalMenuController).HighlightGoalOff();
            else if (this.name == "Close Button")
                (ButtonScript as GoalMenuController).HighlightCloseOff();
        }
        else if(this.ButtonScript.GetType() == typeof(MessageManager))
        {
            (ButtonScript as MessageManager).HighlightOff();
        }
        else if (this.ButtonScript.GetType() == typeof(ProfessionalStack))
        {
            (ButtonScript as ProfessionalStack).OnHoverTool.HighlightOff();
        }
        else if (this.ButtonScript.GetType() == typeof(ProfessionalsMenu))
        {
            if (this.name == "upArrow")
                (ButtonScript as ProfessionalsMenu).HighlightUpArrowOff();
            else if (this.name == "downArrow")
                (ButtonScript as ProfessionalsMenu).HighlightDownArrowOff();
        }
        else if (this.ButtonScript.GetType() == typeof(ProfessionalSlot))
        {
            (ButtonScript as ProfessionalSlot).OnHoverTool.HighlightOff();
        }
        else if (this.ButtonScript.GetType() == typeof(TargetLocation))
        {
            (ButtonScript as TargetLocation).HighlightOff();
        }
    }

    public void ButtonAction()
    {
        if (this.ButtonScript.GetType() == typeof(TutorialToolTip))
        {
            (ButtonScript as TutorialToolTip).CloseToolTip();
        }
        else if (this.ButtonScript.GetType() == typeof(TimerController))
        {
            if (this.name == "PausePlay")
                (ButtonScript as TimerController).ToggglePauseTimer();
            else if (this.name == "FastForward")
                (ButtonScript as TimerController).SkipToNextDay();
        }
        else if (this.ButtonScript.GetType() == typeof(GoalMenuController))
        {
            if (this.name == "GoalButton")
                (ButtonScript as GoalMenuController).ShowGoalInfo();
            else if (this.name == "Close Button")
            {
                (ButtonScript as GoalMenuController).HideGoalInfo();
                _theInputManager.ClickableMousedExit(this);
                _mousedOn = false;
            }
        }
        else if (this.ButtonScript.GetType() == typeof(MessageManager))
        {
            (ButtonScript as MessageManager).HideMessage();
            _theInputManager.ClickableMousedExit(this);
            _mousedOn = false;
        }
        else if (this.ButtonScript.GetType() == typeof(ProfessionalStack))
        {
            (ButtonScript as ProfessionalStack).TakeProfessional();
        }
        else if (this.ButtonScript.GetType() == typeof(ProfessionalsMenu))
        {
            if (this.name == "upArrow")
                (ButtonScript as ProfessionalsMenu).MoveUp();
            else if (this.name == "downArrow")
                (ButtonScript as ProfessionalsMenu).MoveDown();
        }
        else if (this.ButtonScript.GetType() == typeof(ProfessionalSlot))
        {
            (ButtonScript as ProfessionalSlot).RemoveProfessional();
        }
        else if (this.ButtonScript.GetType() == typeof(TargetLocation))
        {
            (ButtonScript as TargetLocation).Activate();
        }
    }
}