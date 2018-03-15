using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalMenuController : MonoBehaviour
{
    public GameObject HighlightSprite,
                      GoalCanvas;
    public SpriteRenderer CloseButtonSprite;
    public List<RectTransform> GoalTexts;
    public int GoalIndex;

    private GameManager _theGameManager;

    private void Start()
    {
        _theGameManager = FindObjectOfType<GameManager>();
    }

    public void ShowGoalInfo()
    {
        GoalCanvas.SetActive(true);

        //GoalTexts[_theGameManager.CurrentVC.GoalIndex - 1].gameObject.SetActive(false);
        //GoalTexts[_theGameManager.CurrentVC.GoalIndex].gameObject.SetActive(true);
        //MyScrollRect.content = GoalTexts[_theGameManager.CurrentVC.GoalIndex];

        foreach(RectTransform rt in GoalTexts)
        {
            if (rt != GoalTexts[_theGameManager.CurrentVC.GoalIndex])
                rt.gameObject.SetActive(false);
            else
                rt.gameObject.SetActive(true);
        }
    }

    public void HideGoalInfo()
    {
        GoalCanvas.SetActive(false);
    }

    public void HighlightGoalOn()
    {
        HighlightSprite.SetActive(true);
    }

    public void HighlightGoalOff()
    {
        HighlightSprite.SetActive(false);
    }

    public void HighlightCloseOn()
    {
        CloseButtonSprite.color = new Color(CloseButtonSprite.color.r + 0.31f, CloseButtonSprite.color.g + 0.31f, CloseButtonSprite.color.b + 0.31f);
    }

    public void HighlightCloseOff()
    {
        CloseButtonSprite.color = new Color(CloseButtonSprite.color.r - 0.31f, CloseButtonSprite.color.g - 0.31f, CloseButtonSprite.color.b - 0.31f);
    }
}