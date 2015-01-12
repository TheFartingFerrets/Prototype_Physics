using UnityEngine;
using System.Collections;

public class PhysicsEditor : MonoBehaviour
{
    public static PhysicsEditor instance;

    [SerializeField]
    Transform RotateHandle;
    Vector2 RotateHandleReset = Vector2.zero;
    public Transform EditTarget;
    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        if (!RotateHandle) Debug.LogError("No Rotate handler");
        RotateHandleReset = RotateHandle.localPosition;
        Hide();
    }
    void Update()
    {
        if( EditTarget )
        {
            Vector3 position = EditTarget.position;
            position.z = -1f;
            transform.position = position;
        }
    }
    void Reset()
    {
        EditTarget = null;
        RotateHandle.localPosition = RotateHandleReset;
        RotateHandle.SendMessage("Reset");
    }
    public void DeleteTarget()
    {
        Debug.Log("Delete");
        GameObject.FindGameObjectWithTag("PhysicsLevelControl").GetComponent<PhysicsAssetStore>().Container.GetComponent<PhysicsLevelAssets>().RemoveGameObject(EditTarget);
        Hide();

    }
    public void FlipX()
    {
        EditTarget.localScale = new Vector3(-EditTarget.localScale.x, EditTarget.localScale.y, 1);
    }
    public void FlipY()
    {
        EditTarget.localScale = new Vector3(EditTarget.localScale.x, -EditTarget.localScale.y, 1);
    }

    public void Hide()
    {
        Reset();
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(-0, -1, 0)) + Vector3.down * 10f;
        GetComponent<CanvasControl>().Invisible();
    }
    public void Show()
    {
        GetComponent<CanvasControl>().Visible();
    }

    public void SetTarget( Transform target )
    {
        Show();
        EditTarget = target;
    }

    void RotatePhysicsAsset()
    {
        Vector3 RotationPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RotationPosition.z = transform.position.z;
        RotateHandle.position = RotationPosition;

        if( EditTarget )
        {
            Vector3 dir = EditTarget.position - RotationPosition;
            float angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
            angle = Mathf.Round(angle / 10f) * 10f;

            EditTarget.rotation = Quaternion.AngleAxis(-(angle + 90f), Vector3.forward);
        }
    }
}