using UnityEngine;
using System.Collections;

public class AssetPortalIn : MonoBehaviour 
{
    [SerializeField]
    GameObject PortalOut;

    public void OnTriggerExit2D(Collider2D other)
    {
        if( other.tag == "Roller")
        {
            PortalOut.GetComponentInChildren<AssetPortalOut>().Portal(other.gameObject, other.gameObject.rigidbody2D.velocity, transform.parent.rigidbody2D.rotation);
        }
    }

    public void SetPortalOut( GameObject portOut)
    {
        PortalOut = portOut;
    }

}
