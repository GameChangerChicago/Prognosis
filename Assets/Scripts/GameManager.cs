using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public ProfessionalStack SelectedProfessional;
    public VictoryCondition CurrentVC;
    public float Finance,
                 Education;
    public bool DragObjectInstantiated;
	public bool winning;
	private AudioSource audioSource;
    private MessageManager _theMessageManager;


    #region World Health Rates
    public float WorldSTIRate
    {
        get
        {
            float totalSTIRate = 0;
            int targetLocationCount = 0;

            foreach (TargetLocation tl in FindObjectsOfType<TargetLocation>())
            {
                totalSTIRate += tl.STIRate;
                targetLocationCount++;
            }

            _worldSTIRate = totalSTIRate / targetLocationCount;

            return _worldSTIRate;
        }

        set
        {
            Debug.Log("This property shouldn't be being set");
        }
    }
    private float _worldSTIRate;
    public float WorldTeenPregRate
    {
        get
        {
            float totalTeenPregRate = 0;
            int targetLocationCount = 0;

            foreach (TargetLocation tl in FindObjectsOfType<TargetLocation>())
            {
                totalTeenPregRate += tl.TeenPregRate;
                targetLocationCount++;
            }

            _worldTeenPregRate = totalTeenPregRate / targetLocationCount;

            return _worldTeenPregRate;
        }

        set
        {
            Debug.Log("This property shouldn't be being set");
        }
    }
    private float _worldTeenPregRate;
    public float WorldCrimeRate
    {
        get
        {
            float totalCrimeRate = 0;
            int targetLocationCount = 0;

            foreach (TargetLocation tl in FindObjectsOfType<TargetLocation>())
            {
                totalCrimeRate += tl.CrimeRate;
                targetLocationCount++;
            }

            _worldCrimeRate = totalCrimeRate / targetLocationCount;

            return _worldCrimeRate;
        }

        set
        {
            Debug.Log("This property shouldn't be being set");
        }
    }
    private float _worldCrimeRate;
    #endregion

    public int CurrentTurn
    {
        get
        {
            return _currentTurn;
        }

        set
        {
            if (_currentTurn != value && value != 0)
            {
				foreach (TargetLocation tl in FindObjectsOfType<TargetLocation>())
                {
                    tl.UpdateValues();
					tl._currentTurn = _currentTurn;

                }

                if (WorldTeenPregRate < 20)
                {
                    _goalTurnCount++;


                    if (_goalTurnCount > 2)
                    {
						winning = true;
                        Debug.Log("YOU WIN!!!!!");

                    }
                }
                else
                {
                    _goalTurnCount = 0;

                }

                if(_theMessageManager)
                {
                    //This whole bit is going to have to be hardcoded to a certain degree.
                    //We could make a random version of this but for now I believe we'll want this to be a tailored experience
                    switch(value)
                    {
                        case 1:
                            _theMessageManager.ShowMessage(Resources.Load<EventInfo>("Events/Event1"));
                            break;
                        case 2:
                            _theMessageManager.ShowMessage(Resources.Load<EventInfo>("Events/Event2"));
                            break;
                        default:
                            Debug.LogWarning("That isn't a valid month value to be changing to.");
                            break;
                    }
                }
            }
            _currentTurn = value;
        }
    }
    private int _currentTurn;

    private int _goalTurnCount;

    private void Start()
    {
        _theMessageManager = this.GetComponent<MessageManager>();
    }

    void Update()
    {
		//Debug.Log (_currentTurn);
		//Debug.Log ("Goal Turn Count: "+ _goalTurnCount);
		//Debug.Log ("World Teen Preg: " + WorldTeenPregRate);
    }
}