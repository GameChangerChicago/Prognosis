using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TargetLocation : MonoBehaviour
{
    public GameObject TargetMenu;
    public BoxCollider2D LockRecallButton;
    public float STIRate,
                 TeenPregRate,
                 CommunityHealth;
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
    private ProfessionalSlot[] proSlots;
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
        float AmbientBoost = 0,
              HealthBoost = 0,
              STIChange = 0,
              TeenPregChange = 0,
              CommHealthChange = 0,
              FinanceChange = 0,
              EducationChange = 0,
              FinancialModifier = 0;
        int STIChangeCount = 0,
            TeenPregChangeCount = 0,
            CommHealthChangeCount = 0,
            FinanceChangeCount = 0,
            EducationChangeCount = 0;

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

        for (int i = 0; i < proSlots.Length; i++)
        {
            switch (proSlots[i].CurrentProfesional.MyProfessionalType)
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
                    EducationChange += 5;
                    CommHealthChangeCount++;
                    EducationChangeCount++;
                    break;
                case ProfessionalType.Politician:
                    AmbientBoost += 5;
                    FinanceChange += 5;
                    FinanceChangeCount++;
                    break;
                case ProfessionalType.Advocate:
                    HealthBoost += 5;
                    EducationChange += 5;
                    EducationChangeCount++;
                    break;
            }
        }

        Mathf.Clamp(FinanceChangeCount, 0, 2);
        Mathf.Clamp(EducationChangeCount, 0, 2);

        STIRate += STIChange + (HealthBoost * STIChangeCount);
        TeenPregRate += TeenPregChange + (HealthBoost * TeenPregChangeCount);
        CommunityHealth += CommHealthChange + (HealthBoost * CommHealthChangeCount);
        _gameManager.Education += EducationChange + (AmbientBoost * EducationChange);
        if (FinanceChangeCount != 1)
            _gameManager.Finance += FinanceChange + (AmbientBoost * FinanceChangeCount);
        else
            _gameManager.Finance += FinanceChange;
    }
}