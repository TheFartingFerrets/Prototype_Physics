using UnityEngine;
using System.Collections;

public class Roller : MonoBehaviour 
{
    [SerializeField]
    Vector2 StartPosition;

    void Awake()
    {
        StartPosition = this.rigidbody2D.position;
        Sleep();

    }
	void Start () 
    {
	
	}
	
	void Update ()
    {
	
	}

    public void Sleep()
    {
        rigidbody2D.velocity = Vector2.zero;
        rigidbody2D.isKinematic = true;
    }

    public void WakeUp()
    {
        rigidbody2D.velocity = Vector2.zero;
        rigidbody2D.position = StartPosition;
        rigidbody2D.isKinematic = false;

    }
    public void Reset()
    {
        rigidbody2D.isKinematic = true;

        rigidbody2D.position = StartPosition;
        rigidbody2D.velocity = Vector3.zero;

    }
}
