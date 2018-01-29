using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

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
    private Text _goalText;
    private TargetLocation _ashPark,
                           _freemason,
                           _philmont,
                           _quinnSquare,
                           _eastBeaHeights;

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

                CheckCurrentStats();

                //          if (WorldTeenPregRate < 20)
                //          {
                //              _goalTurnCount++;

                //              if (_goalTurnCount > 2)
                //              {
                //winning = true;
                //                  Debug.Log("YOU WIN!!!!!");
                //              }
                //          }
                //          else
                //          {
                //              _goalTurnCount = 0;
                //          }

                if (_theMessageManager)
                {
                    //This whole bit is going to have to be hardcoded to a certain degree.
                    //We could make a random version of this but for now I believe we'll want this to be a tailored experience
                    switch (value)
                    {
                        case 1:
                            _theMessageManager.ShowMessage(Resources.Load<EventInfo>("Events/Event1"));
                            break;
                        case 2:
                            _theMessageManager.ShowMessage(Resources.Load<EventInfo>("Events/Event1"));
                            break;
                        case 3:
                            _theMessageManager.ShowMessage(Resources.Load<EventInfo>("Events/Event1"));
                            break;
                        case 4:
                            _theMessageManager.ShowMessage(Resources.Load<EventInfo>("Events/Event1"));
                            break;
                        case 5:
                            _theMessageManager.ShowMessage(Resources.Load<EventInfo>("Events/Event1"));
                            break;
                        case 6:
                            _theMessageManager.ShowMessage(Resources.Load<EventInfo>("Events/Event1"));
                            break;
                        case 7:
                            _theMessageManager.ShowMessage(Resources.Load<EventInfo>("Events/Event1"));
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

    private int[] _turnsMaintained;
    private int _goalTurnCount;

    private void Start()
    {
        _theMessageManager = this.GetComponent<MessageManager>();
        _goalText = GameObject.Find("Canvas/GoalText").GetComponent<Text>();
        UpdateGoalDisplay();

        _ashPark = GameObject.Find("World Map/Ash Park").GetComponent<TargetLocation>();
        _freemason = GameObject.Find("World Map/Freemason").GetComponent<TargetLocation>();
        _philmont = GameObject.Find("World Map/Philmont").GetComponent<TargetLocation>();
        _quinnSquare = GameObject.Find("World Map/Quinn Square").GetComponent<TargetLocation>();
        _eastBeaHeights = GameObject.Find("World Map/East Bea Heights").GetComponent<TargetLocation>();

        _turnsMaintained = new int[CurrentVC.StatsToTrack.Count];
    }


    private void CheckCurrentStats()
    {
        bool[] goalsReached = new bool[CurrentVC.StatsToTrack.Count];
        TargetLocation tl;

        for (int i = 0; i < CurrentVC.StatsToTrack.Count; i++)
        {
            switch (CurrentVC.StatLocation[i])
            {
                case Locations.ASHPARK:
                    tl = _ashPark;

                    switch (CurrentVC.StatsToTrack[i])
                    {
                        case Stats.CRIMERATE:
                            if (CurrentVC.MaintainTimes[i] > 0 && CurrentVC.GoalAmounts[i] <= tl.CrimeRate)
                            {
                                if (_turnsMaintained[i] >= CurrentVC.MaintainTimes[i])
                                    goalsReached[i] = true;
                                else
                                    _turnsMaintained[i]++;
                            }
                            else if (CurrentVC.GoalAmounts[i] <= tl.CrimeRate)
                                goalsReached[i] = true;
                            break;
                        case Stats.STIRATE:
                            if (CurrentVC.MaintainTimes[i] > 0 && CurrentVC.GoalAmounts[i] <= tl.CrimeRate)
                            {
                                if (_turnsMaintained[i] >= CurrentVC.MaintainTimes[i])
                                    goalsReached[i] = true;
                                else
                                    _turnsMaintained[i]++;
                            }
                            else if (CurrentVC.GoalAmounts[i] <= tl.STIRate)
                                goalsReached[i] = true;
                            break;
                        case Stats.TEENPREGRATE:
                            if (CurrentVC.MaintainTimes[i] > 0 && CurrentVC.GoalAmounts[i] <= tl.CrimeRate)
                            {
                                if (_turnsMaintained[i] >= CurrentVC.MaintainTimes[i])
                                    goalsReached[i] = true;
                                else
                                    _turnsMaintained[i]++;
                            }
                            else if (CurrentVC.GoalAmounts[i] <= tl.TeenPregRate)
                                goalsReached[i] = true;
                            break;
                        default:
                            break;
                    }
                    break;
                case Locations.EASTBEAHEIGHTS:
                    tl = _eastBeaHeights;

                    switch (CurrentVC.StatsToTrack[i])
                    {
                        case Stats.CRIMERATE:
                            if (CurrentVC.MaintainTimes[i] > 0 && CurrentVC.GoalAmounts[i] <= tl.CrimeRate)
                            {
                                if (_turnsMaintained[i] >= CurrentVC.MaintainTimes[i])
                                    goalsReached[i] = true;
                                else
                                    _turnsMaintained[i]++;
                            }
                            else if (CurrentVC.GoalAmounts[i] <= tl.CrimeRate)
                                goalsReached[i] = true;
                            break;
                        case Stats.STIRATE:
                            if (CurrentVC.MaintainTimes[i] > 0 && CurrentVC.GoalAmounts[i] <= tl.CrimeRate)
                            {
                                if (_turnsMaintained[i] >= CurrentVC.MaintainTimes[i])
                                    goalsReached[i] = true;
                                else
                                    _turnsMaintained[i]++;
                            }
                            else if (CurrentVC.GoalAmounts[i] <= tl.STIRate)
                                goalsReached[i] = true;
                            break;
                        case Stats.TEENPREGRATE:
                            if (CurrentVC.MaintainTimes[i] > 0 && CurrentVC.GoalAmounts[i] <= tl.CrimeRate)
                            {
                                if (_turnsMaintained[i] >= CurrentVC.MaintainTimes[i])
                                    goalsReached[i] = true;
                                else
                                    _turnsMaintained[i]++;
                            }
                            else if (CurrentVC.GoalAmounts[i] <= tl.TeenPregRate)
                                goalsReached[i] = true;
                            break;
                        default:
                            break;
                    }
                    break;
                case Locations.FREEMASON:
                    tl = _freemason;

                    switch (CurrentVC.StatsToTrack[i])
                    {
                        case Stats.CRIMERATE:
                            if (CurrentVC.MaintainTimes[i] > 0 && CurrentVC.GoalAmounts[i] <= tl.CrimeRate)
                            {
                                if (_turnsMaintained[i] >= CurrentVC.MaintainTimes[i])
                                    goalsReached[i] = true;
                                else
                                    _turnsMaintained[i]++;
                            }
                            else if (CurrentVC.GoalAmounts[i] <= tl.CrimeRate)
                                goalsReached[i] = true;
                            break;
                        case Stats.STIRATE:
                            if (CurrentVC.MaintainTimes[i] > 0 && CurrentVC.GoalAmounts[i] <= tl.CrimeRate)
                            {
                                if (_turnsMaintained[i] >= CurrentVC.MaintainTimes[i])
                                    goalsReached[i] = true;
                                else
                                    _turnsMaintained[i]++;
                            }
                            else if (CurrentVC.GoalAmounts[i] <= tl.STIRate)
                                goalsReached[i] = true;
                            break;
                        case Stats.TEENPREGRATE:
                            if (CurrentVC.MaintainTimes[i] > 0 && CurrentVC.GoalAmounts[i] <= tl.CrimeRate)
                            {
                                if (_turnsMaintained[i] >= CurrentVC.MaintainTimes[i])
                                    goalsReached[i] = true;
                                else
                                    _turnsMaintained[i]++;
                            }
                            else if (CurrentVC.GoalAmounts[i] <= tl.TeenPregRate)
                                goalsReached[i] = true;
                            break;
                        default:
                            break;
                    }
                    break;
                case Locations.GLOBAL:
                    switch (CurrentVC.StatsToTrack[i])
                    {
                        case Stats.CRIMERATE:
                            if (CurrentVC.MaintainTimes[i] > 0 && CurrentVC.GoalAmounts[i] <= WorldCrimeRate)
                            {
                                if (_turnsMaintained[i] >= CurrentVC.MaintainTimes[i])
                                    goalsReached[i] = true;
                                else
                                    _turnsMaintained[i]++;
                            }
                            else if(CurrentVC.GoalAmounts[i] <= WorldCrimeRate)
                                goalsReached[i] = true;
                            break;
                        case Stats.EDUCATION:
                            if (CurrentVC.MaintainTimes[i] > 0 && CurrentVC.GoalAmounts[i] <= Education)
                            {
                                if (_turnsMaintained[i] >= CurrentVC.MaintainTimes[i])
                                    goalsReached[i] = true;
                                else
                                    _turnsMaintained[i]++;
                            }
                            else if (CurrentVC.GoalAmounts[i] >= Education)
                                goalsReached[i] = true;
                            break;
                        case Stats.FINANCE:
                            if (CurrentVC.MaintainTimes[i] > 0 && CurrentVC.GoalAmounts[i] <= Finance)
                            {
                                if (_turnsMaintained[i] >= CurrentVC.MaintainTimes[i])
                                    goalsReached[i] = true;
                                else
                                    _turnsMaintained[i]++;
                            }
                            else if (CurrentVC.GoalAmounts[i] >= Finance)
                                goalsReached[i] = true;
                            break;
                        case Stats.STIRATE:
                            if (CurrentVC.MaintainTimes[i] > 0 && CurrentVC.GoalAmounts[i] <= WorldSTIRate)
                            {
                                if (_turnsMaintained[i] >= CurrentVC.MaintainTimes[i])
                                    goalsReached[i] = true;
                                else
                                    _turnsMaintained[i]++;
                            }
                            else if (CurrentVC.GoalAmounts[i] <= WorldSTIRate)
                                goalsReached[i] = true;
                            break;
                        case Stats.TEENPREGRATE:
                            if (CurrentVC.MaintainTimes[i] > 0 && CurrentVC.GoalAmounts[i] <= WorldTeenPregRate)
                            {
                                if (_turnsMaintained[i] >= CurrentVC.MaintainTimes[i])
                                    goalsReached[i] = true;
                                else
                                    _turnsMaintained[i]++;
                            }
                            else if (CurrentVC.GoalAmounts[i] <= WorldTeenPregRate)
                                goalsReached[i] = true;
                            break;
                        default:
                            break;
                    }
                    break;
                case Locations.PHILMONT:
                    tl = _philmont;

                    switch (CurrentVC.StatsToTrack[i])
                    {
                        case Stats.CRIMERATE:
                            if (CurrentVC.MaintainTimes[i] > 0 && CurrentVC.GoalAmounts[i] <= tl.CrimeRate)
                            {
                                if (_turnsMaintained[i] >= CurrentVC.MaintainTimes[i])
                                    goalsReached[i] = true;
                                else
                                    _turnsMaintained[i]++;
                            }
                            else if (CurrentVC.GoalAmounts[i] <= tl.CrimeRate)
                                goalsReached[i] = true;
                            break;
                        case Stats.STIRATE:
                            if (CurrentVC.MaintainTimes[i] > 0 && CurrentVC.GoalAmounts[i] <= tl.CrimeRate)
                            {
                                if (_turnsMaintained[i] >= CurrentVC.MaintainTimes[i])
                                    goalsReached[i] = true;
                                else
                                    _turnsMaintained[i]++;
                            }
                            else if (CurrentVC.GoalAmounts[i] <= tl.STIRate)
                                goalsReached[i] = true;
                            break;
                        case Stats.TEENPREGRATE:
                            if (CurrentVC.MaintainTimes[i] > 0 && CurrentVC.GoalAmounts[i] <= tl.CrimeRate)
                            {
                                if (_turnsMaintained[i] >= CurrentVC.MaintainTimes[i])
                                    goalsReached[i] = true;
                                else
                                    _turnsMaintained[i]++;
                            }
                            else if (CurrentVC.GoalAmounts[i] <= tl.TeenPregRate)
                                goalsReached[i] = true;
                            break;
                        default:
                            break;
                    }
                    break;
                case Locations.QUINNSQUARE:
                    tl = _quinnSquare;

                    switch (CurrentVC.StatsToTrack[i])
                    {
                        case Stats.CRIMERATE:
                            if (CurrentVC.MaintainTimes[i] > 0 && CurrentVC.GoalAmounts[i] <= tl.CrimeRate)
                            {
                                if (_turnsMaintained[i] >= CurrentVC.MaintainTimes[i])
                                    goalsReached[i] = true;
                                else
                                    _turnsMaintained[i]++;
                            }
                            else if (CurrentVC.GoalAmounts[i] <= tl.CrimeRate)
                                goalsReached[i] = true;
                            break;
                        case Stats.STIRATE:
                            if (CurrentVC.MaintainTimes[i] > 0 && CurrentVC.GoalAmounts[i] <= tl.CrimeRate)
                            {
                                if (_turnsMaintained[i] >= CurrentVC.MaintainTimes[i])
                                    goalsReached[i] = true;
                                else
                                    _turnsMaintained[i]++;
                            }
                            else if (CurrentVC.GoalAmounts[i] <= tl.STIRate)
                                goalsReached[i] = true;
                            break;
                        case Stats.TEENPREGRATE:
                            if (CurrentVC.MaintainTimes[i] > 0 && CurrentVC.GoalAmounts[i] <= tl.CrimeRate)
                            {
                                if (_turnsMaintained[i] >= CurrentVC.MaintainTimes[i])
                                    goalsReached[i] = true;
                                else
                                    _turnsMaintained[i]++;
                            }
                            else if (CurrentVC.GoalAmounts[i] <= tl.TeenPregRate)
                                goalsReached[i] = true;
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
        }

        bool allGoalsReached = true;

        for (int i = 0; i < goalsReached.Length; i++)
        {
            if (goalsReached[i] == false)
                allGoalsReached = false;
        }

        if (allGoalsReached)
        {
            Debug.Log("Thing happens!");

            if (CurrentVC.NextVC != null)
            {
                CurrentVC = CurrentVC.NextVC;
                _turnsMaintained = new int[CurrentVC.StatsToTrack.Count];
            }
        }
    }

    private void UpdateGoalDisplay()
    {
        string goalText = "";

        for (int i = 0; i < CurrentVC.GoalAmounts.Count; i++)
        {
            if (i > 0)
                goalText += "\n\n";

            if (CurrentVC.MaintainTimes[i] > 0)
                goalText += "Keep ";
            else
                goalText += "Get ";

            goalText += CurrentVC.StatLocation[i].ToString() + " " + CurrentVC.StatsToTrack[i];

            if (CurrentVC.MaintainTimes[i] > 0)
                goalText += " at.";
            else
                goalText += " to ";

            goalText += DataConverter(CurrentVC.StatsToTrack[i], CurrentVC.GoalAmounts[i]);

            if (CurrentVC.MaintainTimes[i] > 0)
                goalText += " for " + CurrentVC.MaintainTimes[i] + " month(s).";
        }

        _goalText.text = goalText;
    }

    private float DataConverter(Stats statType, float statValue)
    {
        float convertedData = 0;

        switch (statType)
        {
            case Stats.CRIMERATE:
                convertedData = statValue * 5;
                break;
            case Stats.EDUCATION:
                convertedData = (statValue * 0.45f) + 50;
                break;
            case Stats.FINANCE:
                double d = Math.Round(statValue * 2826403.94, 2);
                convertedData = (float)d;
                break;
            case Stats.STIRATE:
                convertedData = statValue;
                break;
            case Stats.TEENPREGRATE:
                convertedData = statValue * 8;
                break;
        }

        return convertedData;
    }

    void Update()
    {
        //Debug.Log (_currentTurn);
        //Debug.Log ("Goal Turn Count: "+ _goalTurnCount);
        //Debug.Log ("World Teen Preg: " + WorldTeenPregRate);
    }
}