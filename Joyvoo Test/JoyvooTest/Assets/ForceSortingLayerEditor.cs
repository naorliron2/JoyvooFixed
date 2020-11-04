using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ForceSortingLayer))]
public class ForceSortingLayerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        ForceSortingLayer forceLayerScript = (ForceSortingLayer)target;
        if (GUILayout.Button("Get Renderer"))
        {
            forceLayerScript.GetRenderer();
        }
        if (GUILayout.Button("Set Order"))
        {
            forceLayerScript.Sort();
        }
    }

}
