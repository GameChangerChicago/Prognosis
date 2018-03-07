using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseOverTool : MonoBehaviour
{
    public GameObject MouseOverObject;
    public MonoBehaviour DataSource;
    public string BarType;

    private Collider2D _lastCollider;
    private bool _overlapping;

    private void Update()
    {
        List<Collider2D> mouseOverCols = new List<Collider2D>();
        mouseOverCols.AddRange(Physics2D.OverlapPointAll(Camera.main.ScreenToWorldPoint(Input.mousePosition)));

        for (int i = 0; i < mouseOverCols.Count; i++)
        {
            if(mouseOverCols[i].GetComponent<MouseOverTool>() == null)
            {
                mouseOverCols.Remove(mouseOverCols[i]);
            }
        }

        if (mouseOverCols.Count > 0)
        {
            if (mouseOverCols[0].GetComponent<MouseOverTool>() == this)
            {
                ShowTool();
            }
            else
                HideTool();
        }
        else
        {
            HideTool();
        }
    }

    private void ShowTool()
    {
        if (!DataSource)
        {

        }
        else if (DataSource is GameManager)
        {
            if (BarType == "STI")
                MouseOverObject.transform.GetChild(0).GetComponent<Text>().text = (DataSource as GameManager).WorldSTIRate.ToString() + " per\n1000";
            else if (BarType == "Preg")
                MouseOverObject.transform.GetChild(0).GetComponent<Text>().text = ((DataSource as GameManager).WorldTeenPregRate * 8).ToString() + " per\n100,000";
            else if (BarType == "Crime")
                MouseOverObject.transform.GetChild(0).GetComponent<Text>().text = ((DataSource as GameManager).WorldCrimeRate * 5).ToString() + " per\n100,000";
            else if (BarType == "Budget")
                MouseOverObject.transform.GetChild(0).GetComponent<Text>().text = (DataSource as GameManager).Budget.ToString();
            else if (BarType == "Education")
                MouseOverObject.transform.GetChild(0).GetComponent<Text>().text = Mathf.Round(((DataSource as GameManager).Education * 0.45f) + 50).ToString() + "% Grad Rate";
        }
        else if (DataSource is TargetLocation)
        {
            if (BarType == "STI")
                MouseOverObject.transform.GetChild(0).GetComponent<Text>().text = (DataSource as TargetLocation).STIRate.ToString() + " per\n1000";
            else if (BarType == "Preg")
                MouseOverObject.transform.GetChild(0).GetComponent<Text>().text = ((DataSource as TargetLocation).TeenPregRate * 8).ToString() + " per\n100,000";
            else if (BarType == "Crime")
                MouseOverObject.transform.GetChild(0).GetComponent<Text>().text = ((DataSource as TargetLocation).CrimeRate * 5).ToString() + " per\n100,000";
        }

        MouseOverObject.SetActive(true);
    }

    private void HideTool()
    {
        MouseOverObject.SetActive(false);
    }
}