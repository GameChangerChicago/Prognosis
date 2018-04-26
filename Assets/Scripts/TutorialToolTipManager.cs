using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialToolTipManager : MonoBehaviour
{
    private ProfessionalsMenu ProfMenu;
    public List<GameObject> InstantiationPoints;
    public TutorialToolTip CurrentToolTip;
    public bool PlacedFirstPro;
    public Dictionary<string, bool> ToolTipsShown = new Dictionary<string, bool>();

    //Instantiation Logic
    private void Start()
    {
        //if GameManager.DoTutorial
        ShowPopUp("TryLocation", 1);
        PopulateTTSDictionary();
        ProfMenu = FindObjectOfType<ProfessionalsMenu>();
    }

    private void PopulateTTSDictionary()
    {
        ToolTipsShown.Add("TryLocation", false);
        ToolTipsShown.Add("CheckProfInfo", false);
        ToolTipsShown.Add("TryProfessional", false);
        ToolTipsShown.Add("PointOutBudget", false);
        ToolTipsShown.Add("PointOutTime", false);
        ToolTipsShown.Add("FirstEvent", false);
    }

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
        bool value;
        ToolTipsShown.TryGetValue(ToolTipName, out value);

        if (value)
        {
            // if prof menu is active and we trying to instantiate 
            string path = "ToolTips/" + ToolTipName;
            CurrentToolTip = Resources.Load<TutorialToolTip>(path);

            Invoke("TrueInstantiation", instDelay);
        }
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
                break;
            case "PointOutTime":
                CurrentToolTip = Instantiate(CurrentToolTip, InstantiationPoints[4].transform.position, Quaternion.identity);
                CurrentToolTip.transform.parent = InstantiationPoints[4].transform;
                break;
            case "EventHappens":
                CurrentToolTip = Instantiate(CurrentToolTip, InstantiationPoints[5].transform.position, Quaternion.identity);
                CurrentToolTip.transform.parent = InstantiationPoints[5].transform;
                break;
            default:
                break;
        }
    }
}