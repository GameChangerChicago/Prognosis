using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshRendererOverride : MonoBehaviour
{
    public string LayerName;
    public int SortingOrder;

    private void Start()
    {
        foreach (Renderer r in GetComponentsInChildren<SkinnedMeshRenderer>())
        {
            r.sortingLayerName = LayerName;
            r.sortingOrder = SortingOrder;
        }
    }
}