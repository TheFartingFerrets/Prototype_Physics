using UnityEngine;
using System.Collections;

public class PortalIn : MonoBehaviour 
{



    public void OnTriggerExit2D(Collider2D other)
    {
        if (LevelMaster.Instance.LevelState == (int)State.playing)
        {
            if (other.tag == "Roller")
            {
                GameObject PortalOut = GameObject.FindGameObjectWithTag("PortalOut");
                other.transform.position = PortalOut.transform.position;
                Vector2 entryVel = other.rigidbody2D.velocity;
                other.rigidbody2D.velocity = PortalOut.transform.right * entryVel.magnitude + Vector3.one * 1.5f;
            }
        }
    }


    void Update()
    {

        Debug.DrawRay( transform.position, transform.right * 1.0f, Color.red);
    }
}
