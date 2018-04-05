using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialToolTip : MonoBehaviour
{
    public TutorialToolTip NextTTT;

    private TutorialToolTipManager _theTTTManager;

    private void Start()
    {
        _theTTTManager = FindObjectOfType<TutorialToolTipManager>();
    }

    private void OnEnable()
    {
        EventManager.StartListening("Close", CloseToolTip);
    }

    private void OnDisable()
    {
        EventManager.StopListening("Close", CloseToolTip);
    }

    public void CloseToolTip()
    {
        if (NextTTT)
        {
            _theTTTManager.ShowPopUp(NextTTT.name, 1);
        }

        EventManager.StopListening("Close", CloseToolTip);
        GameObject.Destroy(this.gameObject);
    }
}