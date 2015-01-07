using UnityEngine;
using System.Collections;

public class AssetSpring : MonoBehaviour 
{

    public float SpringForce = 600f;

    void Awake()
    {
        Reset();
    }

    public void OnCollisionEnter2D(Collision2D coll)
    {
        if( coll.gameObject.tag == "Roller")
        {
            Debug.Log(transform.up * (SpringForce) * coll.gameObject.rigidbody2D.mass);
            coll.gameObject.rigidbody2D.AddForce(transform.up * (SpringForce + coll.gameObject.rigidbody2D.velocity.y ) * coll.gameObject.rigidbody2D.mass);
        }
    }
    public void Reset()
    {
        //GetComponent<SpringJoint2D>().distance = 1;
        
    }
}
