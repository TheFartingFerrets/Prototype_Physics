using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelUI : MonoBehaviour 
{
    public static LevelUI instance;

    [SerializeField]
    GameObject DrawTogButton;
    [SerializeField]
    GameObject Complete;
    [SerializeField]
    GameObject Options;

    void Start()
    {
        instance = this;
        DrawTogButton.GetComponent<Toggle>().isOn = false;
        HideComplete();
    }
    
    public void ShowComplete()
    {
        DrawTogButton.GetComponent<Toggle>().isOn = false;
        Complete.SetActive(true);
    }
    public void HideComplete()
    {
        Complete.SetActive(false);
    }
}
