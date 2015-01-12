using UnityEngine;
using System.Collections;

public class PhysicsSpring : MonoBehaviour
{
    float SpringForce = 1200f;

    public void OnCollisionEnter2D(Collision2D coll)
    {
        if( coll.gameObject.tag == "PhysicsRoller")
        {
            coll.gameObject.rigidbody2D.AddForce(transform.up * SpringForce);
        }

    }
}