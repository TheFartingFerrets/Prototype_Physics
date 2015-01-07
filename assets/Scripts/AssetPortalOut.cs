using UnityEngine;
using System.Collections;

public class AssetPortalOut : MonoBehaviour 
{
    [SerializeField]
    GameObject PortalIn;

    public float OutForce = 1.0f;

    public void SetPortalIn(GameObject portIn)
    {
        PortalIn = portIn;
    }


    public void Portal(GameObject roller, Vector2 inVel, float InRot)
    {
        roller.rigidbody2D.position = transform.parent.rigidbody2D.position + Vector2.right * 0f;
        roller.rigidbody2D.velocity = transform.right * inVel.magnitude + Vector3.one * OutForce;
    }

}
