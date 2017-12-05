using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryCondition : ScriptableObject
{
    public VictoryType MyVictoryType;
    public List<Stats> StatsToTrack;
    public List<int> GoalAmounts;
    public bool Achieved;
}

public enum VictoryType
{
    MAINTAIN,
    ACHIEVE
}

public enum Stats
{
    STIRATE,
    TEENPREGRATE,
    CRIMERATE
}