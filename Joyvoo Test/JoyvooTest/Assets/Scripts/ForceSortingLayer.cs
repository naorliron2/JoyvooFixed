using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
[ExecuteInEditMode]

public class ForceSortingLayer : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] int sortingLayer;
    [Header("References")]
    [SerializeField] MeshRenderer myRenderer;

    /*
     *this whole script exist because text was hidden behind objects and I couldn't find the sorting order in TMP_Text.
     *However a day later I discovered the same effect is possible by changing the z axis of the text, since it is a little finicky I still prefer this
     * */

    /// <summary>
    /// Forces a sorting order
    /// </summary>
    public void Sort()
    {
        myRenderer.sortingOrder = sortingLayer;
    }
    /// <summary>
    /// Gets the renderer component
    /// </summary>
    public void GetRenderer()
    {
        myRenderer = GetComponent<MeshRenderer>();
    }
    
}
