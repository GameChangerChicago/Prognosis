﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialToolTipManager : MonoBehaviour
{
    private ProfessionalsMenu ProfMenu;
    public List<GameObject> InstantiationPoints;
    public TutorialToolTip CurrentToolTip;
    public bool PlacedFirstPro,
                FirstMessageShown;

    //Instantiation Logic
    private void Start()
    {
        //if GameManager.DoTutorial
        ShowPopUp("TryLocation", 1);
        ProfMenu = FindObjectOfType<ProfessionalsMenu>();
    }

    public void ShowPopUp(string ToolTipName, float instDelay)
    {
        string path = "ToolTips/" + ToolTipName;
        CurrentToolTip = Resources.Load<TutorialToolTip>(path);

        Invoke("TrueInstantiation", instDelay);
    }

    private void TrueInstantiation()
    {
        switch (CurrentToolTip.name)
        {
            case "TryLocation":
                CurrentToolTip = Instantiate(CurrentToolTip, InstantiationPoints[0].transform.position, Quaternion.identity);
                CurrentToolTip.transform.parent = InstantiationPoints[0].transform;
                break;
            case "CheckProfInfo":
                CurrentToolTip = Instantiate(CurrentToolTip, InstantiationPoints[1].transform.position, Quaternion.identity);
                CurrentToolTip.transform.parent = InstantiationPoints[1].transform;
                break;
            case "TryProfessional":
                CurrentToolTip = Instantiate(CurrentToolTip, InstantiationPoints[2].transform.position, Quaternion.identity);
                CurrentToolTip.transform.parent = InstantiationPoints[2].transform;
                break;
            case "PointOutBudget":
                CurrentToolTip = Instantiate(CurrentToolTip, InstantiationPoints[3].transform.position, Quaternion.identity);
                CurrentToolTip.transform.parent = InstantiationPoints[3].transform;
                PlacedFirstPro = true;
                break;
            case "PointOutTime":
                CurrentToolTip = Instantiate(CurrentToolTip, InstantiationPoints[4].transform.position, Quaternion.identity);
                CurrentToolTip.transform.parent = InstantiationPoints[4].transform;
                break;
            case "EventHappens":
                CurrentToolTip = Instantiate(CurrentToolTip, InstantiationPoints[5].transform.position, Quaternion.identity);
                CurrentToolTip.transform.parent = InstantiationPoints[5].transform;
                FirstMessageShown = true;
                break;
            default:
                break;
        }

        CurrentToolTip.GetComponentInChildren<Canvas>().overrideSorting = true;
    }
}