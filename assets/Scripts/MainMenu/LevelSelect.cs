using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using TouchScript.Gestures;

[ExecuteInEditMode]
public class LevelSelect : MonoBehaviour 
{
    int LevelID = 0;
    Transform[] stars = new Transform[3];

    void Awake()
    {
        stars[0] = transform.GetChild(1).GetChild(0);
        stars[1] = transform.GetChild(1).GetChild(1);
        stars[2] = transform.GetChild(1).GetChild(2);
        Objectives(false, false, false);
    }
    void Update()
    {
        LevelID = transform.GetSiblingIndex() + 1;
        transform.GetChild(0).GetComponent<Text>().text = LevelID.ToString();
    }

    //Set Objectives manually
    public void ObjectiveOne(bool obj)
    {
        stars[0].GetComponent<Selectable>().enabled = obj;
    }
    public void ObjectivesTwo(bool obj)
    {
        stars[1].GetComponent<Selectable>().enabled = obj;
    }
    public void ObjectivesThree(bool obj)
    {
        stars[2].GetComponent<Selectable>().enabled = obj;
    }

    //Set all Objectives
    public void Objectives(bool obj1, bool obj2, bool obj3)
    {
        stars[0].GetComponent<Selectable>().enabled = obj1;
        stars[1].GetComponent<Selectable>().enabled = obj1;
        stars[2].GetComponent<Selectable>().enabled = obj1;
    }
    public void Objectives(bool[] obj)
    {
        for (int i = 0; i < 3; i++)
        {
            stars[i].GetComponent<Selectable>().enabled = obj[i];
        }
    }

    public void LoadLevel()
    {
        this.GetComponentInParent<CanvasControl>().Invisible();
        GameControl.control.LoadLevel(LevelID);
        //GameControl.control.LoadLevel(levelName);
    }
}
