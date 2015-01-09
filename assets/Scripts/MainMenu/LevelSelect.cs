using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using TouchScript.Gestures;

[ExecuteInEditMode]
public class LevelSelect : MonoBehaviour 
{
    [SerializeField]
    int LevelID = 0;
    //public string levelName = "Level1";

    void Awake()
    {
        this.GetComponentInParent<CanvasControl>().Invisible();
    }
    [ExecuteInEditMode]
    void Update()
    {
        LevelID = transform.GetSiblingIndex() + 1;
        transform.GetChild(0).GetComponent<Text>().text = LevelID.ToString();
    }

    public void LoadLevel()
    {
        this.GetComponentInParent<CanvasControl>().Invisible();
        GameControl.control.LoadLevel(LevelID);
        //GameControl.control.LoadLevel(levelName);
    }
}
