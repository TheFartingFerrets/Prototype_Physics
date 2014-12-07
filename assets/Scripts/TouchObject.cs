using UnityEngine;
using System.Collections;

public class TouchObject : MonoBehaviour {

    public void OnMouseDown()
    {
        
    }

    public void OnMouseDrag()
    {
        transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
    }

    public void OnMouseUp()
    {
    }

}
