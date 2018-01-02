using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class EventEffect : ScriptableObject
{
    public List<Locations> LocationToAffect;
    public List<Stats> StatToChange;
    public List<int> StatChange;
}

#if UNITY_EDITOR
public class MakeEventEffect
{
    [MenuItem("Assets/Create/EventEffect")]
    public static void CreateEventEffect()
    {
        EventEffect theEE = ScriptableObject.CreateInstance<EventEffect>();

        AssetDatabase.CreateAsset(theEE, "Assets/Resources/VictoryConditions/NewEE.asset");
        AssetDatabase.SaveAssets();

        Selection.activeObject = theEE;
    }
}
#endif