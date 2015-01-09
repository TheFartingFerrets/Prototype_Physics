using UnityEngine;
using System.Collections;

public class AssetSpeedUp : MonoBehaviour 
{

    public float IncreaseForce = 10f;
    [SerializeField]
    private float multi = 1f;


    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Roller")
        {
            other.rigidbody2D.AddForce(transform.right * IncreaseForce * multi, ForceMode2D.Impulse);
            multi = 1.5f;
        }
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Roller")
        {
            multi += 0.5f;
            other.rigidbody2D.AddForce(transform.right * IncreaseForce * multi);
        }
    }
    
    public void OnTriggerExit2D(Collider2D other)
    {
        if ( other.tag == "Roller")
        {
            multi = 1f;
        }
    }

}

