using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialToolTipManager : MonoBehaviour
{
    public List<GameObject> InstantiationPoints;
    public TutorialToolTip CurrentToolTip;

    //Instantiation Logic

    //Make this an event listener
    private void CloseTTTHandler()
    {
        switch(CurrentToolTip.name)
        {
            case "TryLocation":
                break;
            case "CheckProfInfo":
                break;
            default:
                Debug.Log("This tool tip doesn't exist... yet?");
                break;
        }
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
                break;
            default:
                break;
        }
    }
}