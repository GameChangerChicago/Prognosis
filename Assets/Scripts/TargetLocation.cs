using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TargetLocation : MonoBehaviour
{
    public GameObject TargetMenu;
    public BoxCollider2D LockRecallButton;
    public ProfessionalSlot[] ProSlots;
    public float STIRate,
                 TeenPregRate,
                 CommunityHealth,
                 STIEffectPerTurn,
                 TeenPregEffectPerTurn,
                 CommHealthEffectPerTurn;
    public bool Locked;

    public bool Active
    {
        get
        {
            return _active;
        }

        set
        {
            if (_active != value)
            {
                if (value)
                {
                    TargetMenu.SetActive(value);
                    PM.Active = true;
                }
                else
                {
                    TargetMenu.SetActive(value);
                }

                _active = value;
            }
        }
    }
    private bool _active;

    private List<TargetLocation> _otherTargetLocs = new List<TargetLocation>();
    private ProfessionalsMenu PM;
    private GameManager _gameManager;
    private int _currentTurn;

    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        PM = FindObjectOfType<ProfessionalsMenu>();
        _otherTargetLocs.AddRange(FindObjectsOfType<TargetLocation>());
        _otherTargetLocs.Remove(this);
    }

    void Update()
    {
        if (LockRecallButton.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)) && Input.GetKeyDown(KeyCode.Mouse0))
        {
            //Possibly show butten being pressed
        }
        if (LockRecallButton.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)) && Input.GetKeyUp(KeyCode.Mouse0) && _currentTurn != _gameManager.CurrentTurn)
        {
            if (!Locked)
                _currentTurn = _gameManager.CurrentTurn;

            Locked = !Locked;
        }
    }

    void OnMouseDown()
    {
        Active = true;
        foreach (TargetLocation tl in _otherTargetLocs)
        {
            tl.Active = false;
        }
    }

    public void UpdateValues()
    {
        //Initialization of local fields
        float AmbientBoost = 0,
              HealthBoost = 0,
              STIChange = 0,
              TeenPregChange = 0,
              CommHealthChange = 0,
              FinanceChange = 0,
              EducationChange = 0,
              FinancialModifier = 0,
              EducationModifier = 0;
        int STIChangeCount = 0,
            TeenPregChangeCount = 0,
            CommHealthChangeCount = 0,
            FinanceChangeCount = 0,
            EducationChangeCount = 0;

        //Calculation of Financial Modifier
        if (_gameManager.Finance < 10)
            FinancialModifier = -10;
        else if (_gameManager.Finance < 40)
            FinancialModifier = -5;
        else if (_gameManager.Finance < 80)
            FinancialModifier = 0;
        else if (_gameManager.Finance < 99)
            FinancialModifier = 5;
        else
            FinancialModifier = 10;

        //Calculation of Education Modifier
        if (_gameManager.Education < 10)
            EducationModifier = 5;
        else if (_gameManager.Education < 30)
            EducationModifier = 0;
        else if (_gameManager.Education < 60)
            EducationModifier = -5;
        else if (_gameManager.Education < 99)
            EducationModifier = -10;
        else
            EducationModifier = -20;
        
        //Professional calculations
        for (int i = 0; i < ProSlots.Length; i++)
        {
            if (ProSlots[i].CurrentProfesional != null)
            {
                Debug.Log(ProSlots[i].CurrentProfesional.MyProfessionalType);
                switch (ProSlots[i].CurrentProfesional.MyProfessionalType)
                {
                    case ProfessionalType.Doctor:
                        STIChange -= 20 + FinancialModifier;
                        FinanceChange -= 5;
                        STIChangeCount++;
                        break;
                    case ProfessionalType.Nurse:
                        TeenPregChange -= 10 + FinancialModifier;
                        STIChange -= 5 + FinancialModifier;
                        STIChangeCount++;
                        TeenPregChangeCount++;
                        break;
                    case ProfessionalType.CommOrg:
                        CommHealthChange += 10 + FinancialModifier;
                        FinanceChange -= 5;
                        EducationChange += 5 + FinancialModifier;
                        CommHealthChangeCount++;
                        EducationChangeCount++;
                        break;
                    case ProfessionalType.Politician:
                        AmbientBoost += 5;
                        FinanceChange += 5 + FinancialModifier;
                        FinanceChangeCount++;
                        break;
                    case ProfessionalType.Advocate:
                        HealthBoost += 5;
                        EducationChange += 5 + FinancialModifier;
                        EducationChangeCount++;
                        break;
                }
            }
        }

        //Assures that the professionals never make things worse due to financial modifier
        //At worst they will do nothing
        Mathf.Clamp(STIChange, -100, 0);
        Mathf.Clamp(TeenPregChange, -100, 0);
        Mathf.Clamp(CommHealthChange, 0, 100);
        Mathf.Clamp(FinanceChange, 0, 100);
        Mathf.Clamp(EducationChange, 0, 100);

        //I dont feel like explaining what this does and why. Suffice to say it's important.
        Mathf.Clamp(FinanceChangeCount, 0, 2);
        Mathf.Clamp(EducationChangeCount, 0, 2);

        //This debug log is useful for finding any problems with the professional effects
        //Debug.Log(STIChange + " - " + "(" + HealthBoost + " * " + STIChangeCount + ")");

        //Apply professional effects
        STIRate += STIChange - (HealthBoost * STIChangeCount);
        TeenPregRate += TeenPregChange - (HealthBoost * TeenPregChangeCount);
        CommunityHealth += CommHealthChange + (HealthBoost * CommHealthChangeCount);
        _gameManager.Education += EducationChange + (AmbientBoost * EducationChangeCount);
        if (FinanceChangeCount != 1)
            _gameManager.Finance += FinanceChange + (AmbientBoost * FinanceChangeCount);
        else
            _gameManager.Finance += FinanceChange;

        //Apply per turn effects
        STIRate += Mathf.Clamp(STIEffectPerTurn + EducationModifier, 0, 100);
        TeenPregRate += Mathf.Clamp(TeenPregEffectPerTurn + EducationModifier, 0, 100);
        CommunityHealth -= Mathf.Clamp(CommHealthEffectPerTurn + EducationModifier, 0, 100);

        //Clamping final values
        STIRate = Mathf.Clamp(STIRate, 0, 100);
        TeenPregRate = Mathf.Clamp(TeenPregRate, 0, 100);
        CommunityHealth = Mathf.Clamp(CommunityHealth, 0, 100);
        _gameManager.Finance = Mathf.Clamp(_gameManager.Finance, 0, 100);
        _gameManager.Education = Mathf.Clamp(_gameManager.Education, 0, 100);
    }
}