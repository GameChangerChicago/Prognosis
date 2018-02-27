using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshRendererOverride : MonoBehaviour
{
    private void Start()
    {
        foreach (Renderer r in GetComponentsInChildren<SkinnedMeshRenderer>())
        {
            r.sortingLayerName = "Default";
            r.sortingOrder = 13;
        }
    }
}