using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GlobalStatsBar : MonoBehaviour {

	public Image worldTeenPregRate, worldSTIRate, worldCrimeRate, financeBarBack, financeBarFront, educationBar;
	private GameManager gameManager;
	private float changeOverTime = 15.0f,
                  potentialFinance;
	private TimerController timer;
    private bool[] _financeBarsUpdated = new bool[2];


    // Use this for initialization
    void Start()
    {
        gameManager = this.gameObject.GetComponent<GameManager>();
        timer = FindObjectOfType<TimerController>();
        worldSTIRate.fillAmount = (gameManager.WorldSTIRate + 10) / 100f;
        worldTeenPregRate.fillAmount = (gameManager.WorldTeenPregRate + 10) / 100f;
        worldCrimeRate.fillAmount = (gameManager.WorldCrimeRate + 10) / 100f;
        financeBarBack.fillAmount = gameManager.Finance / 100f;
        financeBarFront.fillAmount = gameManager.Finance / 100f;
        educationBar.fillAmount = gameManager.Education / 100f;
        potentialFinance = gameManager.Finance;
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

        if (educationBar.fillAmount < (gameManager.Education / 100f) - 0.01f)
        {
            educationBar.fillAmount += changeOverTime / timer.TimeLimit * Time.deltaTime;
        }
        if (educationBar.fillAmount > (gameManager.Education / 100f) + 0.01f)
        {
            educationBar.fillAmount -= changeOverTime / timer.TimeLimit * Time.deltaTime;
        }

        if (!_financeBarsUpdated[0] || !_financeBarsUpdated[1])
            UpdateFinance();
    }

    public void FinanceBarChange(TargetLocation tl, ProfessionalType profType, bool addingProf)
    {
        if (addingProf)
        {
            if (profType == ProfessionalType.Politician)
            {
                int polCount = 0;

                for (int i = 0; i < tl.ProSlots.Length; i++)
                {
                    if (tl.ProSlots[i].CurrentProfesional != null)
                        if (tl.ProSlots[i].CurrentProfesional.MyProfessionalType == ProfessionalType.Politician)
                            polCount++;
                }

                if (polCount == 1)
                    potentialFinance += 5;
                else if (polCount == 2)
                    potentialFinance += 15;
                else if (polCount == 3)
                    potentialFinance += 30;
            }
            else
            {
                if (profType == ProfessionalType.Doctor)
                    potentialFinance -= 6;
                else
                    potentialFinance -= 3;
            }
        }
        else
        {
            if (profType == ProfessionalType.Politician)
            {
                int polCount = 0;

                for (int i = 0; i < tl.ProSlots.Length; i++)
                {
                    if (tl.ProSlots[i].CurrentProfesional != null)
                        if (tl.ProSlots[i].CurrentProfesional.MyProfessionalType == ProfessionalType.Politician)
                            polCount++;
                }

                if (polCount == 0)
                    potentialFinance -= 5;
                else if (polCount == 1)
                    potentialFinance -= 15;
                else if (polCount == 2)
                    potentialFinance -= 30;
            }
            else
            {
                if (profType == ProfessionalType.Doctor)
                    potentialFinance += 6;
                else
                    potentialFinance += 3;
            }
        }

        if (potentialFinance > gameManager.Finance)
        {
            financeBarFront.fillAmount = gameManager.Finance / 100;
            financeBarBack.fillAmount = potentialFinance / 100;
        }
        else
        {
            financeBarFront.fillAmount = potentialFinance / 100;
            financeBarBack.fillAmount = gameManager.Finance / 100;
        }
    }

    public void SetFinance()
    {
        _financeBarsUpdated[0] = false;
        _financeBarsUpdated[1] = false;
    }

    private void UpdateFinance()
    {
        if (financeBarBack.fillAmount < (gameManager.Finance / 100f) - 0.01f)
        {
            financeBarBack.fillAmount += changeOverTime / timer.TimeLimit * Time.deltaTime;
        }
        else if (financeBarBack.fillAmount > (gameManager.Finance / 100f) + 0.01f)
        {
            financeBarBack.fillAmount -= changeOverTime / timer.TimeLimit * Time.deltaTime;
        }
        else
            _financeBarsUpdated[0] = true;

        if (financeBarFront.fillAmount < (gameManager.Finance / 100f) - 0.01f)
        {
            financeBarFront.fillAmount += changeOverTime / timer.TimeLimit * Time.deltaTime;
        }
        else if (financeBarFront.fillAmount > (gameManager.Finance / 100f) + 0.01f)
        {
            financeBarFront.fillAmount -= changeOverTime / timer.TimeLimit * Time.deltaTime;
        }
        else
            _financeBarsUpdated[1] = true;
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
