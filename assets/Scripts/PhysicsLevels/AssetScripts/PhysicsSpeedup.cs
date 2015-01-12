using UnityEngine;
using System.Collections;

public class PhysicsSpeedup : MonoBehaviour 
{

    Vector2 Direction;
    float StayForce = 40f;

    void Start()
    {
        Direction = transform.right;
    }
    void Update()
    {
        Debug.DrawRay(transform.position, transform.right * transform.parent.localScale.x, Color.blue);
    }
    public void ChangeDirection()
    {
        transform.localScale = new Vector3(-transform.localScale.x, 1, 1);
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "PhysicsRoller")
        {
            other.rigidbody2D.AddForce(transform.right * transform.parent.localScale.x * StayForce);
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PhysicsRoller")
        {
            //Rotate the roller to face the same rotation
        }
    }




}
