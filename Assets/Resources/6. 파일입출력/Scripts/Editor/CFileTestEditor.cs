using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using FileTestProject;

[CustomEditor(typeof(CFileTest))]
public class CFileTestEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        CFileTest fileTest = target as CFileTest;

        if (GUILayout.Button("Save"))
        {
            fileTest.Save();
        }

        if (GUILayout.Button("Load"))
        {
            fileTest.Load();
        }
    }
}
