using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class VCSet : ScriptableObject
{
    public List<VictoryCondition> MyVictoryConditions = new List<VictoryCondition>();
}

//#if UNITY_EDITOR
//public class MakeVCSet
//{
//    [MenuItem("Assets/Create/VCSet")]
//    public static void CreateVCSet()
//    {
//        VCSet theVCSet = ScriptableObject.CreateInstance<VCSet>();

//        AssetDatabase.CreateAsset(theVCSet, "Assets/Resources/VCSets/NewVCSet.asset");
//        AssetDatabase.SaveAssets();

//        Selection.activeObject = theVCSet;
//    }
//}
//#endif