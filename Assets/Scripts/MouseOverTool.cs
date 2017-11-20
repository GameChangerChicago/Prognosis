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

        if (mouseOverCols.Count > 0 && !_overlapping)
        {
            if (mouseOverCols[0].GetComponent<MouseOverTool>() == this)
            {
                _lastCollider = mouseOverCols[0];
                _overlapping = true;
                ShowTool();
            }
        }
        else if(_overlapping && mouseOverCols.Count < 1)
        {
            if (_lastCollider.GetComponent<MouseOverTool>() == this)
            {
                _lastCollider = null;
                _overlapping = false;
                HideTool();
            }
        }
    }

    private void ShowTool()
    {
        if (DataSource is GameManager)
        {
            if (BarType == "STI")
                MouseOverObject.transform.GetChild(0).GetComponent<Text>().text = (DataSource as GameManager).WorldSTIRate.ToString() + "%";
            else if (BarType == "Preg")
                MouseOverObject.transform.GetChild(0).GetComponent<Text>().text = (DataSource as GameManager).WorldTeenPregRate.ToString() + "%";
            else if (BarType == "Crime")
                MouseOverObject.transform.GetChild(0).GetComponent<Text>().text = (DataSource as GameManager).WorldCrimeRate.ToString() + "%";
        }
        else if (DataSource is TargetLocation)
        {
            if (BarType == "STI")
                MouseOverObject.transform.GetChild(0).GetComponent<Text>().text = (DataSource as TargetLocation).STIRate.ToString() + "%";
            else if (BarType == "Preg")
                MouseOverObject.transform.GetChild(0).GetComponent<Text>().text = (DataSource as TargetLocation).TeenPregRate.ToString() + "%";
            else if (BarType == "Crime")
                MouseOverObject.transform.GetChild(0).GetComponent<Text>().text = (DataSource as TargetLocation).CrimeRate.ToString() + "%";
        }

        MouseOverObject.SetActive(true);
    }

    private void HideTool()
    {
        MouseOverObject.SetActive(false);
    }
}