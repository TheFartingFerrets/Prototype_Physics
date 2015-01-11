using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class LevelCanvas : MonoBehaviour 
{
    public Transform[] WorldLevels = new Transform[4];

    [SerializeField]
    GameObject LevelGraphicPrefab;
    
    [ExecuteInEditMode]
    void Awake()
    {
        //Maths
        WorldLevels[0] = transform.GetChild(0).GetChild(0);
        //Physics
        WorldLevels[1] = transform.GetChild(0).GetChild(1);
        //Reflex
        WorldLevels[2] = transform.GetChild(0).GetChild(2);
        //Collect
        WorldLevels[3] = transform.GetChild(0).GetChild(3);

        HideWorldLevels();
    }


    public void ShowWorldLevel()
    {
        HideWorldLevels();
        LevelVisible(WorldLevels[GameControl.control.World-1]);
    }
    private void HideWorldLevels()
    {
        LevelInvisible(WorldLevels[0]);
        LevelInvisible(WorldLevels[1]);
        LevelInvisible(WorldLevels[2]);
        LevelInvisible(WorldLevels[3]);
    }

    public void EditLevelInfo( Level[] World, int worldid)
    {
        List<Transform> children = new List<Transform>();
        foreach( Transform child in WorldLevels[worldid])
        {
            children.Add(child);
        }

        for (int i = 0; i < children.Count; i++)
        {
            children[i].GetComponent<LevelSelect>().Objectives(World[i].Objectives);
            //children[i].GetComponent<LevelSelect>().Objectives()
        }
    }



    private void LevelVisible(Transform p)
    {
        p.GetComponent<CanvasGroup>().alpha = 1;
        p.GetComponent<CanvasGroup>().interactable = true;
        p.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
    private void LevelInvisible(Transform p)
    {
        p.GetComponent<CanvasGroup>().alpha = 0;
        p.GetComponent<CanvasGroup>().interactable = false;
        p.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
}
