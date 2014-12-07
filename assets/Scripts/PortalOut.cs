using UnityEngine;
using System.Collections;

public class PortalOut : MonoBehaviour 
{


    void Update()
    {
        Debug.DrawRay(transform.position, transform.right * 1.0f, Color.red);
    }


}
