using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif

[CustomEditor(typeof(ShadowCaster))]
public class shadowCreate : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        ShadowCaster myScript = (ShadowCaster)target;
        if (GUILayout.Button("Open File"))
        {
            myScript.Generate();
        }
    }

}