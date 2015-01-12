using UnityEngine;
using System.Collections;

public class PhysicsPortalIn : MonoBehaviour 
{
    [SerializeField]
    Transform PortalOut;

    void SetPortalOut( Transform portalOut )
    {
        PortalOut = portalOut;
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if( other.tag == "PhysicsRoller")
        {
            other.rigidbody2D.position = PortalOut.position + Vector3.right *0.2f;
            other.rigidbody2D.velocity = PortalOut.right * other.rigidbody2D.velocity.magnitude + Vector3.one * 1.0f;
        }
    }
	


    
}
