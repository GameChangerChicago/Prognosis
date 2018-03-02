using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrognosisButton : MonoBehaviour
{
    public GameObject ButtonHighlight;
    private InputManager _theInputManager;

    private void Start()
    {
        _theInputManager = FindObjectOfType<InputManager>();
    }

    private void OnMouseEnter()
    {
        _theInputManager.ClickableMousedEnter(this.gameObject);

        if (ButtonHighlight)
        {
            ButtonHighlight.SetActive(true);
        }
    }

    private void OnMouseExit()
    {
        _theInputManager.ClickableMousedExit(this.gameObject);

        if (ButtonHighlight)
        {
            ButtonHighlight.SetActive(false);
        }
    }
}