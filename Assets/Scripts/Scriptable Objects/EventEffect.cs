using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventEffect : ScriptableObject
{
    public List<Locations> LocationToAffect;
    public List<Stats> StatToChange;
    public List<int> StatChange;
}