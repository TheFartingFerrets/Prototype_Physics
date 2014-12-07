using UnityEngine;
using System.Collections;

public class Roller : MonoBehaviour 
{
    public Vector2 startPos = new Vector2();
    public Vector2 velocity;

    void Awake()
    {
        startPos = transform.position;
    }

    void Start()
    {
        transform.position = startPos;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        rigidbody2D.drag = 0;
    }


    void Update()
    {

        velocity = rigidbody2D.velocity;
    }
    public void Play()
    {
        rigidbody2D.isKinematic = false;
    }

    public void Restart()
    {
        rigidbody2D.isKinematic = true;
        Start();
    }

    public void Stop()
    {
        rigidbody2D.isKinematic = true;
    }

    public void DecreaseSpeed()
    {
        rigidbody2D.drag = rigidbody2D.velocity.magnitude * 2f;
    }

    public void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position, transform.up, Color.red);
    }

}
