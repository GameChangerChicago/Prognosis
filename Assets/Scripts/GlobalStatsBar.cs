using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GlobalStatsBar : MonoBehaviour {

	public Image WorldTeenPregRate, WorldSTIRate, WorldCrimeRate, BudgetBarBack, BudgetBarFront, EducationBar;
	private GameManager gameManager;
	private float changeOverTime = 15.0f,
                  potentialBudget;
	private TimerController timer;
    private bool[] _budgetBarsUpdated = new bool[2];


    // Use this for initialization
    void Start()
    {
        gameManager = this.gameObject.GetComponent<GameManager>();
        timer = FindObjectOfType<TimerController>();
        WorldSTIRate.fillAmount = (gameManager.WorldSTIRate + 10) / 100f;
        WorldTeenPregRate.fillAmount = (gameManager.WorldTeenPregRate + 10) / 100f;
        WorldCrimeRate.fillAmount = (gameManager.WorldCrimeRate + 10) / 100f;
        BudgetBarBack.fillAmount = gameManager.Budget / 100f;
        BudgetBarFront.fillAmount = gameManager.Budget / 100f;
        EducationBar.fillAmount = gameManager.Education / 100f;
        potentialBudget = gameManager.Budget;
    }

    // Update is called once per frame
    void Update()
    {
        if (WorldSTIRate.fillAmount < (gameManager.WorldSTIRate / 100f) - 0.01f)
        {
            WorldSTIRate.fillAmount += changeOverTime / timer.TimeLimit * Time.deltaTime;
            UpdateColor(WorldSTIRate.fillAmount, Stats.STIRATE);
        }
        else if (WorldSTIRate.fillAmount > (gameManager.WorldSTIRate / 100f) + 0.01f)
        {
            WorldSTIRate.fillAmount -= changeOverTime / timer.TimeLimit * Time.deltaTime;
            UpdateColor(WorldSTIRate.fillAmount, Stats.STIRATE);
        }

        if (WorldCrimeRate.fillAmount < (gameManager.WorldCrimeRate / 100f) - 0.01f)
        {
            WorldCrimeRate.fillAmount += changeOverTime / timer.TimeLimit * Time.deltaTime;
            UpdateColor(WorldCrimeRate.fillAmount, Stats.CRIMERATE);
        }
        else if (WorldCrimeRate.fillAmount > (gameManager.WorldCrimeRate / 100f) + 0.01f)
        {
            WorldCrimeRate.fillAmount -= changeOverTime / timer.TimeLimit * Time.deltaTime;
            UpdateColor(WorldCrimeRate.fillAmount, Stats.CRIMERATE);
        }

        if (WorldTeenPregRate.fillAmount < (gameManager.WorldTeenPregRate / 100f) - 0.01f)
        {
            WorldTeenPregRate.fillAmount += changeOverTime / timer.TimeLimit * Time.deltaTime;
            UpdateColor(WorldTeenPregRate.fillAmount, Stats.TEENPREGRATE);
        }
        else if (WorldTeenPregRate.fillAmount > (gameManager.WorldTeenPregRate / 100f) + 0.01f)
        {
            WorldTeenPregRate.fillAmount -= changeOverTime / timer.TimeLimit * Time.deltaTime;
            UpdateColor(WorldTeenPregRate.fillAmount, Stats.TEENPREGRATE);
        }

        if (EducationBar.fillAmount < (gameManager.Education / 100f) - 0.01f)
        {
            EducationBar.fillAmount += changeOverTime / timer.TimeLimit * Time.deltaTime;
        }
        if (EducationBar.fillAmount > (gameManager.Education / 100f) + 0.01f)
        {
            EducationBar.fillAmount -= changeOverTime / timer.TimeLimit * Time.deltaTime;
        }

        if (!_budgetBarsUpdated[0] || !_budgetBarsUpdated[1])
            UpdateBudget();
    }

    public bool BudgetBarChange(TargetLocation tl, ProfessionalType profType, bool addingProf)
    {
        if (addingProf)
        {
            float lastBudget = potentialBudget;

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
                    potentialBudget += 5;
                else if (polCount == 1)
                    potentialBudget += 15;
                else if (polCount == 2)
                    potentialBudget += 30;
            }
            else
            {
                if (profType == ProfessionalType.Doctor)
                    potentialBudget -= 6;
                else
                    potentialBudget -= 3;

                if(potentialBudget < 0)
                {
                    potentialBudget = lastBudget;
                    return false;
                }
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
                    potentialBudget -= 5;
                else if (polCount == 1)
                    potentialBudget -= 15;
                else if (polCount == 2)
                    potentialBudget -= 30;
            }
            else
            {
                if (profType == ProfessionalType.Doctor)
                    potentialBudget += 6;
                else
                    potentialBudget += 3;
            }
        }

        if (potentialBudget > gameManager.Budget)
        {
            BudgetBarFront.fillAmount = gameManager.Budget / 100;
            BudgetBarBack.fillAmount = potentialBudget / 100;
        }
        else
        {
            BudgetBarFront.fillAmount = potentialBudget / 100;
            BudgetBarBack.fillAmount = gameManager.Budget / 100;
        }

        return true;
    }

    public void SetBudget()
    {
        _budgetBarsUpdated[0] = false;
        _budgetBarsUpdated[1] = false;
    }

    private void UpdateBudget()
    {
        if (BudgetBarBack.fillAmount < (gameManager.Budget / 100f) - 0.01f)
        {
            BudgetBarBack.fillAmount += changeOverTime / timer.TimeLimit * Time.deltaTime;
        }
        else if (BudgetBarBack.fillAmount > (gameManager.Budget / 100f) + 0.01f)
        {
            BudgetBarBack.fillAmount -= changeOverTime / timer.TimeLimit * Time.deltaTime;
        }
        else
            _budgetBarsUpdated[0] = true;

        if (BudgetBarFront.fillAmount < (gameManager.Budget / 100f) - 0.01f)
        {
            BudgetBarFront.fillAmount += changeOverTime / timer.TimeLimit * Time.deltaTime;
        }
        else if (BudgetBarFront.fillAmount > (gameManager.Budget / 100f) + 0.01f)
        {
            BudgetBarFront.fillAmount -= changeOverTime / timer.TimeLimit * Time.deltaTime;
        }
        else
            _budgetBarsUpdated[1] = true;
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
                WorldCrimeRate.color = currentColor;
                break;
            case Stats.STIRATE:
                WorldSTIRate.color = currentColor;
                break;
            case Stats.TEENPREGRATE:
                WorldTeenPregRate.color = currentColor;
                break;
            default:
                Debug.LogWarning("This Stat does not exist");
                break;
        }
    }
}
