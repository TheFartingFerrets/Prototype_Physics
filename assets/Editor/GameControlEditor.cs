using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(GameControl))]
public class GameControlEditor : Editor 
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        GameControl script = (GameControl)target;

        if( GUILayout.Button("SaveTest"))
        {
            script.ForceSave();
        }
        if( GUILayout.Button("Force Objective"))
        {
            script.ForceLevel();
        }
        if( GUILayout.Button("Delete data"))
        {
            script.ForceDelete();
        }
    }
}
