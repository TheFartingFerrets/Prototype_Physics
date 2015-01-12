using UnityEngine;
using System.Collections;

public class PhysicsRotate : MonoBehaviour 
{
    Vector2 StartPivot;
    void Awake()
    {
        StartPivot = transform.parent.GetComponent<RectTransform>().pivot;
    }
    public void OnMouseDown()
    {
        transform.parent.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
    }
    public void OnMouseDrag()
    {
        SendMessageUpwards("RotatePhysicsAsset");
    }
    public void Reset()
    {
        transform.parent.GetComponent<RectTransform>().pivot = StartPivot;
    }
}
