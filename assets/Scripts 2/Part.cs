using UnityEngine;
using System.Collections;


public class Part : MonoBehaviour 
{

    public bool isLocked = false;
    public bool isDrag = false;
    public Vector2 dragOffset = Vector2.zero;

    public void OnMouseDown()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dragOffset.x = mousePos.x - transform.position.x;
        dragOffset.y = mousePos.y - transform.position.y;
    }

    public void OnMouseDrag()
    {
        isDrag = true;
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        rigidbody2D.MovePosition(mousePos - dragOffset);
    }

    public void OnMouseUp()
    {
        if(isDrag) isDrag = false;
        dragOffset = Vector2.zero;
    }



    public void Lock()
    {
        isLocked = true;
    }
    public void UnLock()
    {
        isLocked = false;
    }

}
