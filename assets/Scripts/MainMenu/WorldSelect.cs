using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using TouchScript.Gestures;

[ExecuteInEditMode]
public class WorldSelect : MonoBehaviour
{
    [SerializeField]
    int WorldID = 0;
    public string WorldName = "World1";
    
    void Awake()
    {
        this.GetComponentInParent<CanvasControl>().Invisible();
    }
    [ExecuteInEditMode]
    void Update()
    {
        WorldID = transform.GetSiblingIndex() + 1;
        transform.GetChild(0).GetComponentInChildren<Text>().text = WorldName;
    }
    public void LoadWorld()
    {
        this.GetComponentInParent<CanvasControl>().Invisible();
        GameControl.control.LoadWorld(WorldID);
        //GameControl.control.LoadWorld(WorldName);
    }
}
