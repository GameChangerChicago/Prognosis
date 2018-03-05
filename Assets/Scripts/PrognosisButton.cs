using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrognosisButton : MonoBehaviour
{
    public GameObject ButtonHighlight;
    public MonoBehaviour ButtonScript;
    private InputManager _theInputManager;

    private void Start()
    {
        _theInputManager = FindObjectOfType<InputManager>();
    }

    private void OnMouseEnter()
    {
        _theInputManager.ClickableMousedEnter(this);

        if (ButtonHighlight)
        {
            ButtonHighlight.SetActive(true);
        }
    }

    private void OnMouseExit()
    {
        _theInputManager.ClickableMousedExit(this);

        if (ButtonHighlight)
        {
            ButtonHighlight.SetActive(false);
        }
    }

    public void HighlightButton()
    {
        if (this.ButtonScript.GetType() == typeof(TimerController))
        {
            if (this.name == "PausePlay")
                (ButtonScript as TimerController).HighlightPausePlayOn();
            else if(this.name == "FastForward")
                (ButtonScript as TimerController).HighlightFastForwardOn();
        }
        else if(this.ButtonScript.GetType() == typeof(GoalMenuController))
        {
            (ButtonScript as GoalMenuController).HighlightOn();
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
        if (this.ButtonScript.GetType() == typeof(TimerController))
        {
            if (this.name == "PausePlay")
                (ButtonScript as TimerController).HighlightPausePlayOff();
            else if (this.name == "FastForward")
                (ButtonScript as TimerController).HighlightFastForwardOff();
        }
        else if (this.ButtonScript.GetType() == typeof(GoalMenuController))
        {
            (ButtonScript as GoalMenuController).HighlightOff();
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
        if (this.ButtonScript.GetType() == typeof(TimerController))
        {
            if (this.name == "PausePlay")
                (ButtonScript as TimerController).ToggglePauseTimer();
            else if (this.name == "FastForward")
                (ButtonScript as TimerController).SkipToNextDay();
        }
        else if (this.ButtonScript.GetType() == typeof(GoalMenuController))
        {
            (ButtonScript as GoalMenuController).ShowGoalInfo();
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