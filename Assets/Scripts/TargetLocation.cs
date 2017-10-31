using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TargetLocation : MonoBehaviour
{
    public GameObject TargetMenu;
   	public BoxCollider2D LockRecallButton;
	public GameObject spriteHighlight;
	public AudioClip mhuRecall, mhuLock, clickDisabled;
	private AudioSource audioSource;

	public SpriteRenderer spriteRenderer;
	public GameObject lockButtonRenderer, recallButtonRenderer;
    public ProfessionalsMenu TheProfMenu;
	public ProfessionalSlot[] ProSlots;
    public float STIRate,
                 TeenPregRate,
                 CrimeRate,
                 STIEffectPerTurn,
                 TeenPregEffectPerTurn,
                 CrimeRateEffectPerTurn;
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
					spriteHighlight.SetActive (value);
                    PM.Active = true;
                }
                else
                {
                    TargetMenu.SetActive(value);
					spriteHighlight.SetActive (value);

                }

                _active = value;
            }
        }
    }
    private bool _active;

    private List<TargetLocation> _otherTargetLocs = new List<TargetLocation>();
    private ProfessionalsMenu PM;
    private GameManager _gameManager;
    public int _currentTurn;


	private Color defaultColor;
	public Color color;

    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        TheProfMenu = FindObjectOfType<ProfessionalsMenu>();
        PM = FindObjectOfType<ProfessionalsMenu>();
        _otherTargetLocs.AddRange(FindObjectsOfType<TargetLocation>());
        _otherTargetLocs.Remove(this);
		defaultColor = spriteRenderer.color;
		audioSource = gameObject.AddComponent<AudioSource>();
		audioSource.clip = Resources.Load(name) as AudioClip;
		audioSource.Play();
    }

    void Update()
    {
		if (_currentTurn != _gameManager.CurrentTurn) {
			//_currentTurn = _gameManager.CurrentTurn;

			if(Locked)
				recallButtonRenderer.GetComponent<SpriteRenderer>().color = Color.white;
		}
        
        if (LockRecallButton.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)) && Input.GetKeyDown(KeyCode.Mouse0))
        {
            //recallButtonRenderer.GetComponent<SpriteRenderer>().color = lockButtonRenderer.GetComponent<SpriteRenderer>().color = Color.grey;



            if (!Locked && _currentTurn != _gameManager.CurrentTurn)
            {
                _currentTurn = _gameManager.CurrentTurn;
                Locked = !Locked;
                audioSource.clip = mhuLock;
                audioSource.Play();
                lockButtonRenderer.SetActive(false);
                recallButtonRenderer.SetActive(true);
                recallButtonRenderer.GetComponent<SpriteRenderer>().color = Color.white;

            }
            else if (Locked && _currentTurn == _gameManager.CurrentTurn)
            {


                audioSource.clip = clickDisabled;
                audioSource.Play();

            }
            else if (Locked && _currentTurn != _gameManager.CurrentTurn)
            {
                _currentTurn = _gameManager.CurrentTurn;
                Locked = !Locked;
                lockButtonRenderer.SetActive(true);
                recallButtonRenderer.SetActive(false);
                audioSource.clip = mhuRecall;
                audioSource.Play();

            }
            else
            { //if location is not locked and the current turn is  equal to the game manager's current turn
                _currentTurn = _gameManager.CurrentTurn;
                Locked = !Locked;
                audioSource.clip = mhuLock;
                audioSource.Play();
                lockButtonRenderer.SetActive(false);
                recallButtonRenderer.SetActive(true);
                recallButtonRenderer.GetComponent<SpriteRenderer>().color = new Color(.6f, .6f, .6f);
            }

            if (_currentTurn != _gameManager.CurrentTurn)
                recallButtonRenderer.GetComponent<SpriteRenderer>().color = Color.white;



        }
//        if (LockRecallButton.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)) && Input.GetKeyUp(KeyCode.Mouse0) && _currentTurn != _gameManager.CurrentTurn)
//        {
//            if (!Locked)
//                _currentTurn = _gameManager.CurrentTurn;
//
//            Locked = !Locked;
//
//        }
    }

	void OnMouseOver(){
		spriteRenderer.color = color;
	}

	void OnMouseExit(){
		spriteRenderer.color = defaultColor;
	}

    public void Activate()
    {
        Active = true;
        //spriteHighlight.SetActive (true);
        foreach (TargetLocation tl in _otherTargetLocs)
        {
            tl.Active = false;
            //tl.spriteHighlight.SetActive (false);
        }
    }

    void OnMouseDown()
    {
    }

    public void UpdateValues()
    {
        //Initialization of local fields
        float AmbientBoost = 0,
              HealthBoost = 0,
              STIChange = 0,
              TeenPregChange = 0,
              CrimeRateChange = 0,
              FinanceChange = 0,
              EducationChange = 0,
              FinancialModifier = 0,
              EducationModifier = 0;
        int STIChangeCount = 0,
            TeenPregChangeCount = 0,
            CrimeRateChangeCount = 0,
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
                        STIChange -= 10 + FinancialModifier;
                        STIChangeCount++;
                        TeenPregChangeCount++;
                        break;
                    case ProfessionalType.CommOrg:
                        CrimeRateChange -= 10 + FinancialModifier;
                        FinanceChange -= 5;
                        EducationChange += 5 + FinancialModifier;
                        CrimeRateChangeCount++;
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
        STIChange = Mathf.Clamp(STIChange, -100, 0);
        TeenPregChange = Mathf.Clamp(TeenPregChange, -100, 0);
        CrimeRateChange = Mathf.Clamp(CrimeRateChange, -100, 0);
        FinanceChange = Mathf.Clamp(FinanceChange, 0, 100);
        EducationChange = Mathf.Clamp(EducationChange, 0, 100);

        //I dont feel like explaining what this does and why. Suffice to say it's important.
        //EDIT: It must be possible, somehow, to get either of these values over 2 so this keeps it at 2 since that should be the max
        Mathf.Clamp(FinanceChangeCount, 0, 2);
        Mathf.Clamp(EducationChangeCount, 0, 2);

        //This debug log is useful for finding any problems with the professional effects
        //Debug.Log(STIChange + " - " + "(" + HealthBoost + " * " + STIChangeCount + ")");

        //Apply professional effects
        STIRate += STIChange - (HealthBoost * STIChangeCount);
        TeenPregRate += TeenPregChange - (HealthBoost * TeenPregChangeCount);
        CrimeRate += CrimeRateChange - (HealthBoost * CrimeRateChangeCount);
        _gameManager.Education += EducationChange + (AmbientBoost * EducationChangeCount);
        if (FinanceChangeCount != 1)
            _gameManager.Finance += FinanceChange + (AmbientBoost * FinanceChangeCount);
        else
            _gameManager.Finance += FinanceChange;

        //Apply per turn effects
        STIRate += Mathf.Clamp(STIEffectPerTurn + EducationModifier, 0, 100);
        TeenPregRate += Mathf.Clamp(TeenPregEffectPerTurn + EducationModifier, 0, 100);
        CrimeRate += Mathf.Clamp(CrimeRateEffectPerTurn + EducationModifier, 0, 100);

        //Clamping final values
        STIRate = Mathf.Clamp(STIRate, 0, 100);
        TeenPregRate = Mathf.Clamp(TeenPregRate, 0, 100);
        CrimeRate = Mathf.Clamp(CrimeRate, 0, 100);
        _gameManager.Finance = Mathf.Clamp(_gameManager.Finance, 0, 100);
        _gameManager.Education = Mathf.Clamp(_gameManager.Education, 0, 100);
    }
}