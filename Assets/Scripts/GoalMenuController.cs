using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalMenuController : MonoBehaviour
{
    public GameObject HighlightSprite,
                      GoalCanvas;
    public ScrollRect MyScrollRect;
    public List<RectTransform> GoalTexts;

    private GameManager _theGameManager;

    private void Start()
    {
        _theGameManager = FindObjectOfType<GameManager>();
    }

    public void ShowGoalInfo()
    {
        GoalCanvas.SetActive(true);

        MyScrollRect.content = GoalTexts[_theGameManager.CurrentVC.GoalIndex];

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

    private void OnMouseOver()
    {
        HighlightSprite.SetActive(true);
    }

    private void OnMouseExit()
    {
        HighlightSprite.SetActive(false);
    }
}