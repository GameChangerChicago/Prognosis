using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class VictoryCondition : ScriptableObject
{
    public VictoryType MyVictoryType;
    public VictoryCondition NextVC;
    public List<Stats> StatsToTrack;
    public List<Locations> StatLocation;
    public List<int> GoalAmounts;
    public bool Achieved;
}

#if UNITY_EDITOR
public class MakeVicotryCondition
{
    [MenuItem("Assets/Create/VictoryCondition")]
    public static void CreateVictoryCondition()
    {
        VictoryCondition theVC = ScriptableObject.CreateInstance<VictoryCondition>();

        AssetDatabase.CreateAsset(theVC, "Assets/Resources/VictoryConditions/NewVC.asset");
        AssetDatabase.SaveAssets();

        Selection.activeObject = theVC;
    }
}
#endif