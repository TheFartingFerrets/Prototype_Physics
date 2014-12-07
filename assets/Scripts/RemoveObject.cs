using UnityEngine;
using System.Collections;

public class RemoveObject : MonoBehaviour {


    public void OnMouseDown()
    {
        transform.parent.parent.GetComponent<TouchButton>().RemoveThis(this.transform.parent.gameObject);
    }
}
