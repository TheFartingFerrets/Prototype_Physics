using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class UIButton : MonoBehaviour 
{
    [SerializeField]
    bool locked = true;

    int stars = 0;

    void Awake()
    {
        this.GetComponent<Button>().interactable = !locked;
        AlphaStars();
    }
    public void Unlock()
    {
        locked = false;
        this.GetComponent<Button>().interactable = !locked;
    }
    public void Lock()
    {   
        locked = true;
        this.GetComponent<Button>().interactable = !locked;
    }
    public void AlphaStars()
    {
        Transform StarContainer = this.transform.GetChild(1).gameObject.transform;
        for(int i = 0; i < 3; i++)
        {
            StarContainer.GetChild(i).GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.2f);
        }
    }
    public void UpdateStars()
    {
        Transform StarContainer = this.transform.GetChild(1).gameObject.transform;
     
        for(int i = 0; i < stars; i++)
        {
            Debug.Log(StarContainer.GetChild(i));
            StarContainer.GetChild(i).GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
        }
    }
}
