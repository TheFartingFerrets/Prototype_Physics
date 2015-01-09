using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AssetEdit : MonoBehaviour 
{
    public static AssetEdit instance;

    public Transform Target;
    public Transform Rotate;
    public Vector2 RotateReset = Vector2.zero;
    public Button Delete;
    public Button Hide;

    LineRenderer LR;


    void Awake()
    {
        instance = this;
        LR = this.GetComponent<LineRenderer>();
        RotateReset = Rotate.transform.localPosition;
        HideEdit();
    }
    void Update()
    {
        if( Target )
            transform.position = Target.position;
        LR.SetPosition(0, transform.position);
        LR.SetPosition(1, Rotate.position);

    }

    public void HideEdit()
    {
        Target = null;
        Vector3 pos = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, -0.4f, 0));
        pos.z = 0;
        Rotate.localPosition = RotateReset;
        transform.position = pos;
        
    }

    public void Reset()
    {
        Rotate.localPosition = RotateReset;
    }
    
    public void DeleteAsset()
    {
        Debug.Log("Na i dont feel like it");
    }

    public void RotateAsset()
    {
        Vector3 RotPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RotPos.z = 0;
        Rotate.position = RotPos;

        Vector3 dir = Target.position - RotPos;
        float angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
        angle = Mathf.Round(angle / 10.0f) * 10.0f;

        Target.rotation = Quaternion.AngleAxis(-(angle + 90f), Vector3.forward);

    }
}

