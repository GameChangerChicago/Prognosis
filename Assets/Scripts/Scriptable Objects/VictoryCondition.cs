using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryCondition : ScriptableObject
{
    public VictoryType myVictoryType;

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