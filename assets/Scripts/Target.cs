using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour 
{

    public void OnTriggerStay2D(Collider2D other)
    {
        if( other.tag == "Roller")
        {
            Debug.DrawRay(rigidbody2D.position, other.rigidbody2D.position - rigidbody2D.position);
            other.SendMessage("Sleep");
            LevelMaster.instance.CompleteLevel();
        }
    }
}
