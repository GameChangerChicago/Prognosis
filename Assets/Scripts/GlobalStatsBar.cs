using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GlobalStatsBar : MonoBehaviour {

	public Image worldTeenPregRate, worldSTIRate, worldCrimeRate, financeBar, educationBar;
	private GameManager gameManager;
	private float changeOverTime = 15.0f;
	private TimerController timer;


    // Use this for initialization
    void Start()
    {
        gameManager = this.gameObject.GetComponent<GameManager>();
        timer = FindObjectOfType<TimerController>();
        worldSTIRate.fillAmount = (gameManager.WorldSTIRate + 10) / 100f;
        worldTeenPregRate.fillAmount = (gameManager.WorldTeenPregRate + 10) / 100f;
        worldCrimeRate.fillAmount = (gameManager.WorldCrimeRate + 10) / 100f;
        financeBar.fillAmount = (gameManager.Finance + 10) / 100f;
        educationBar.fillAmount = (gameManager.Education + 10) / 100f;
    }

    // Update is called once per frame
    void Update()
    {
        if (worldSTIRate.fillAmount < (gameManager.WorldSTIRate / 100f) - 0.01f)
        {
            worldSTIRate.fillAmount += changeOverTime / timer.TimeLimit * Time.deltaTime;
            UpdateColor(worldSTIRate.fillAmount, Stats.STIRATE);
        }
        else if (worldSTIRate.fillAmount > (gameManager.WorldSTIRate / 100f) + 0.01f)
        {
            worldSTIRate.fillAmount -= changeOverTime / timer.TimeLimit * Time.deltaTime;
            UpdateColor(worldSTIRate.fillAmount, Stats.STIRATE);
        }

        if (worldCrimeRate.fillAmount < (gameManager.WorldCrimeRate / 100f) - 0.01f)
        {
            worldCrimeRate.fillAmount += changeOverTime / timer.TimeLimit * Time.deltaTime;
            UpdateColor(worldCrimeRate.fillAmount, Stats.CRIMERATE);
        }
        else if (worldCrimeRate.fillAmount > (gameManager.WorldCrimeRate / 100f) + 0.01f)
        {
            worldCrimeRate.fillAmount -= changeOverTime / timer.TimeLimit * Time.deltaTime;
            UpdateColor(worldCrimeRate.fillAmount, Stats.CRIMERATE);
        }

        if (worldTeenPregRate.fillAmount < (gameManager.WorldTeenPregRate / 100f) - 0.01f)
        {
            worldTeenPregRate.fillAmount += changeOverTime / timer.TimeLimit * Time.deltaTime;
            UpdateColor(worldTeenPregRate.fillAmount, Stats.TEENPREGRATE);
        }
        else if (worldTeenPregRate.fillAmount > (gameManager.WorldTeenPregRate / 100f) + 0.01f)
        {
            worldTeenPregRate.fillAmount -= changeOverTime / timer.TimeLimit * Time.deltaTime;
            UpdateColor(worldTeenPregRate.fillAmount, Stats.TEENPREGRATE);
        }

        if (financeBar.fillAmount < (gameManager.Finance / 100f) - 0.01f)
        {
            financeBar.fillAmount += changeOverTime / timer.TimeLimit * Time.deltaTime;
        }
        if (financeBar.fillAmount > (gameManager.Finance / 100f) + 0.01f)
        {
            financeBar.fillAmount -= changeOverTime / timer.TimeLimit * Time.deltaTime;
        }

        if (educationBar.fillAmount < (gameManager.Education / 100f) - 0.01f)
        {
            educationBar.fillAmount += changeOverTime / timer.TimeLimit * Time.deltaTime;
        }
        if (educationBar.fillAmount > (gameManager.Education / 100f) + 0.01f)
        {
            educationBar.fillAmount -= changeOverTime / timer.TimeLimit * Time.deltaTime;
        }
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
                worldCrimeRate.color = currentColor;
                break;
            case Stats.STIRATE:
                worldSTIRate.color = currentColor;
                break;
            case Stats.TEENPREGRATE:
                worldTeenPregRate.color = currentColor;
                break;
            default:
                Debug.LogWarning("This Stat does not exist");
                break;
        }
    }
}
