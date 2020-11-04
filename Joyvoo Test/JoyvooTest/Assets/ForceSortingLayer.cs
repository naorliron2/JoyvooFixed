using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
[ExecuteInEditMode]
public class ForceSortingLayer : MonoBehaviour
{
    [SerializeField] MeshRenderer myRenderer;
    [SerializeField] int sortingLayer;
    // Start is called before the first frame update
    
    public void Sort()
    {
        myRenderer.sortingOrder = sortingLayer;
    }
    public void GetRenderer()
    {
        myRenderer = GetComponent<MeshRenderer>();
    }
    
}
