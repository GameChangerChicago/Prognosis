using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class EventInfo : ScriptableObject
{
    public string EventTitle,
                  EventText;
    public EventEffect TheEventEffect;
}

#if UNITY_EDITOR
public class MakeEventInfo
{
    [MenuItem("Assets/Create/EventInfo")]
    public static void CreateEventInfo()
    {
        EventInfo theEI = ScriptableObject.CreateInstance<EventInfo>();

        AssetDatabase.CreateAsset(theEI, "Assets/Resources/VictoryConditions/NewEventInfo.asset");
        AssetDatabase.SaveAssets();

        Selection.activeObject = theEI;
    }
}
#endif