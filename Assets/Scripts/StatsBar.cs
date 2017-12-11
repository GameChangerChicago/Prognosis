using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StatsBar : MonoBehaviour {

	public Image stiRateBar, teenPregRateBar, crimeRateBar;
    public Color CurrentColor = new Color();
	private float changeOverTime = 15.0f;
	private TargetLocation location;
	private TimerController timer;

    void Start()
    {
        location = this.GetComponent<TargetLocation>();
        timer = FindObjectOfType<TimerController>();
        stiRateBar.fillAmount = (location.STIRate + 10) / 100f;
        teenPregRateBar.fillAmount = (location.TeenPregRate + 10) / 100f;
        crimeRateBar.fillAmount = (location.CrimeRate + 10) / 100f;
    }
    
    void Update()
    {
        if (stiRateBar.fillAmount < (location.STIRate / 100f) - 0.01f)
        {
            stiRateBar.fillAmount += changeOverTime / timer.TimeLimit * Time.deltaTime;
            UpdateColor(stiRateBar.fillAmount, Stats.STIRATE);
        }
        else if (stiRateBar.fillAmount > (location.STIRate / 100f) + 0.01f)
        {
            stiRateBar.fillAmount -= changeOverTime / timer.TimeLimit * Time.deltaTime;
            UpdateColor(stiRateBar.fillAmount, Stats.STIRATE);
        }

        if (teenPregRateBar.fillAmount < (location.TeenPregRate / 100f) - 0.01f)
        {
            teenPregRateBar.fillAmount += changeOverTime / timer.TimeLimit * Time.deltaTime;
            UpdateColor(teenPregRateBar.fillAmount, Stats.TEENPREGRATE);
        }
        else if (teenPregRateBar.fillAmount > (location.TeenPregRate / 100f) + 0.01f)
        {
            teenPregRateBar.fillAmount -= changeOverTime / timer.TimeLimit * Time.deltaTime;
            UpdateColor(teenPregRateBar.fillAmount, Stats.TEENPREGRATE);
        }

        if (crimeRateBar.fillAmount < (location.CrimeRate / 100f) - 0.01f)
        {
            crimeRateBar.fillAmount += changeOverTime / timer.TimeLimit * Time.deltaTime;
            UpdateColor(crimeRateBar.fillAmount, Stats.CRIMERATE);
        }
        else if (crimeRateBar.fillAmount > (location.CrimeRate / 100f) + 0.01f)
        {
            crimeRateBar.fillAmount -= changeOverTime / timer.TimeLimit * Time.deltaTime;
            UpdateColor(crimeRateBar.fillAmount, Stats.CRIMERATE);
        }
        //Debug.Log(crimeRateBar.fillAmount);
    }

    private void UpdateColor(float healthAverage, Stats relevantStat)
    {
        Color currentColor = new Color();

        if (healthAverage < 0.5f)
        {
            currentColor = new Color(healthAverage * 2, 1, 0);
        }
        else if (healthAverage == 0.5f)
        {
            currentColor = new Color(1, 1, 0);
        }
        else if (healthAverage > 0.5f)
        {
            currentColor = new Color(1, (1 - healthAverage) * 2, 0);
        }

        switch (relevantStat)
        {
            case Stats.CRIMERATE:
                crimeRateBar.color = currentColor;
                break;
            case Stats.STIRATE:
                stiRateBar.color = currentColor;
                break;
            case Stats.TEENPREGRATE:
                teenPregRateBar.color = currentColor;
                break;
            default:
                Debug.LogWarning("This Stat does not exist");
                break;
        }
    }
}
