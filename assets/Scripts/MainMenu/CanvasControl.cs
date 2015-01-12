using UnityEngine;
using System.Collections;

public class CanvasControl : MonoBehaviour 
{
    [SerializeField]
    bool visible = false;

    public void Toggle()
    {
        if (!visible)
        {
            Visible();
        }
        else
        {
            Invisible();
        }
    }
    public void Visible()
    {
        visible = true;
        this.GetComponent<CanvasGroup>().alpha = 1;
        this.GetComponent<CanvasGroup>().interactable = true;
        this.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
    public void Invisible()
    {
        visible = false;
        this.GetComponent<CanvasGroup>().alpha = 0;
        this.GetComponent<CanvasGroup>().interactable = false;
        this.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
    public void DisableInteraction()
    {
        this.GetComponent<CanvasGroup>().interactable = false;
    }
    public void EnableInteraction()
    {
        this.GetComponent<CanvasGroup>().interactable = true;
    }
}
