using UnityEngine;
using System.Collections;

public class GUILevel : MonoBehaviour 
{
    private static GUILevel instance;
    public static GUILevel Instance
    {
        get
        {
            return instance;
        }
    }

    public GameObject Save;
    public GameObject Load;
    public GameObject LevelLoad;
    public GameObject LevelSelectParent;

    void Awake()
    {
        if (!instance) instance = this;
        //EnableBuild();
        HideSaving();
        HideLoading();
    }
    public void EnableBuild()
    {
        foreach (Transform child in transform)
            child.gameObject.SetActive(false);
        transform.GetChild(0).gameObject.SetActive(true);
    }
    public void EnableRunning()
    {
        foreach (Transform child in transform)
            child.gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(true);
    }
    public void EnableComplete()
    {
        foreach (Transform child in transform)
            child.gameObject.SetActive(false);
        transform.GetChild(2).gameObject.SetActive(true);
    }
    public void ShowOptions()
    {
    }
    public void HideOptions()
    {
    }
    public void ShowSaving()
    {
        Save.SetActive(true);
    }
    public void HideSaving()
    {
        Save.SetActive(false);
    }
    public void ShowLoading()
    {
        Load.SetActive(true);
    }
    public void HideLoading()
    {
        Load.SetActive(false);
    }
    public void ShowLevelLoading()
    {
        LevelLoad.SetActive(true);
    }
    public void HideLevelLoading()
    {
        LevelLoad.SetActive(false);
    }
}
