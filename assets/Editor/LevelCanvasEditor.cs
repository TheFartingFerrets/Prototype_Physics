using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(LevelCanvas))]
public class LevelCanvasEditor : Editor 
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        LevelCanvas script = (LevelCanvas)target;

    }
}
