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

    public void CloseToolTip()
    {
        if (NextTTT)
        {
            _theTTTManager.ShowPopUp(NextTTT.name, 1);
        }

        GameObject.Destroy(this.gameObject);
    }
}