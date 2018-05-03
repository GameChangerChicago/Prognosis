using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrognosisButton : MonoBehaviour
{
    public GameObject ButtonHighlight;
    public MonoBehaviour ButtonScript;
    private InputManager _theInputManager;
    private Collider2D _theCollider;
    private bool _mousedOn;
    private AudioManager _audioManager;

    private void Start()
    {
        _theInputManager = FindObjectOfType<InputManager>();
        _theCollider = this.GetComponent<Collider2D>();
        _audioManager = AudioManager.instance;
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
            {
                (ButtonScript as TimerController).HighlightPausePlayOn();
                _audioManager.PlaySound("Mouse Over");
            }
            else if (this.name == "FastForward")
            {
                (ButtonScript as TimerController).HighlightFastForwardOn();
                _audioManager.PlaySound("Mouse Over");
            }
        }
        else if(this.ButtonScript.GetType() == typeof(GoalMenuController))
        {
            if (this.name == "GoalButton")
            {
                (ButtonScript as GoalMenuController).HighlightGoalOn();
                _audioManager.PlaySound("Mouse Over");
            }
            else if (this.name == "Close Button")
            {
                (ButtonScript as GoalMenuController).HighlightCloseOn();
                _audioManager.PlaySound("Mouse Over");
            }
        }
        else if (this.ButtonScript.GetType() == typeof(MessageManager))
        {
            (ButtonScript as MessageManager).HighlightOn();
            _audioManager.PlaySound("Mouse Over");
        }
        else if(this.ButtonScript.GetType() == typeof(ProfessionalStack))
        {
            (ButtonScript as ProfessionalStack).OnHoverTool.HighlightOn();
            _audioManager.PlaySound("Mouse Over");
        }
        else if (this.ButtonScript.GetType() == typeof(ProfessionalsMenu))
        {
            if (this.name == "upArrow")
            {
                (ButtonScript as ProfessionalsMenu).HighlightUpArrowOn();
                _audioManager.PlaySound("Mouse Over");
            }
            else if (this.name == "downArrow")
            {
                (ButtonScript as ProfessionalsMenu).HighlightDownArrowOn();
                _audioManager.PlaySound("Mouse Over");
            }
        }
        else if (this.ButtonScript.GetType() == typeof(ProfessionalSlot))
        {
            (ButtonScript as ProfessionalSlot).OnHoverTool.HighlightOn();
            _audioManager.PlaySound("Mouse Over");
        }
        else if (this.ButtonScript.GetType() == typeof(TargetLocation))
        {
            (ButtonScript as TargetLocation).HighlightOn();
            _audioManager.PlaySound("Mouse Over");
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
            _audioManager.PlaySound("Button Pressed");
        }
        else if (this.ButtonScript.GetType() == typeof(TimerController))
        {
            if (this.name == "PausePlay")
            {
                (ButtonScript as TimerController).ToggglePauseTimer();
                _audioManager.PlaySound("Button Pressed");
            }
            else if (this.name == "FastForward")
            {
                (ButtonScript as TimerController).SkipToNextDay();
                _audioManager.PlaySound("Button Pressed");
            }
        }
        else if (this.ButtonScript.GetType() == typeof(GoalMenuController))
        {
            if (this.name == "GoalButton")
            {
                (ButtonScript as GoalMenuController).ShowGoalInfo();
                _audioManager.PlaySound("Button Pressed");
            }
            else if (this.name == "Close Button")
            {
                (ButtonScript as GoalMenuController).HideGoalInfo();
                _theInputManager.ClickableMousedExit(this);
                _mousedOn = false;
                _audioManager.PlaySound("Button Pressed");
            }
        }
        else if (this.ButtonScript.GetType() == typeof(MessageManager))
        {
            (ButtonScript as MessageManager).HideMessage();
            _theInputManager.ClickableMousedExit(this);
            _mousedOn = false;
            _audioManager.PlaySound("Button Pressed");
        }
        else if (this.ButtonScript.GetType() == typeof(ProfessionalStack))
        {
            (ButtonScript as ProfessionalStack).TakeProfessional();
        }
        else if (this.ButtonScript.GetType() == typeof(ProfessionalsMenu))
        {
            if (this.name == "upArrow")
            {
                (ButtonScript as ProfessionalsMenu).MoveUp();
                _audioManager.PlaySound("Button Pressed");
            }
            else if (this.name == "downArrow")
            {
                (ButtonScript as ProfessionalsMenu).MoveDown();
                _audioManager.PlaySound("Button Pressed");
            }
        }
        else if (this.ButtonScript.GetType() == typeof(ProfessionalSlot))
        {
            (ButtonScript as ProfessionalSlot).RemoveProfessional();
        }
        else if (this.ButtonScript.GetType() == typeof(TargetLocation))
        {
            (ButtonScript as TargetLocation).Activate();
            _audioManager.PlaySound("Button Pressed");
        }
    }
}