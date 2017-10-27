using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public ProfessionalStack SelectedProfessional;
    public float Finance,
                 Education;
    public bool DragObjectInstantiated;
	public bool winning;
	private AudioSource audioSource;


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
    public float WorldCommHealthRate
    {
        get
        {
            float totalCommHealthRate = 0;
            int targetLocationCount = 0;

            foreach (TargetLocation tl in FindObjectsOfType<TargetLocation>())
            {
                totalCommHealthRate += tl.CommunityHealth;
                targetLocationCount++;
            }

            _worldCommHealthRate = totalCommHealthRate / targetLocationCount;

            return _worldCommHealthRate;
        }

        set
        {
            Debug.Log("This property shouldn't be being set");
        }
    }
    private float _worldCommHealthRate;
    #endregion

    public int CurrentTurn
    {
        get
        {
            return _currentTurn;
        }

        set
        {
            if (_currentTurn != value)
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
            }
            _currentTurn = value;
        }
    }
    private int _currentTurn;

    private int _goalTurnCount;

    void Update()
    {
		Debug.Log (_currentTurn);
		Debug.Log ("Goal Turn Count: "+ _goalTurnCount);
		Debug.Log ("World Teen Preg: " + WorldTeenPregRate);
    }




}