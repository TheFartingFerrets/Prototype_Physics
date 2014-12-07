using UnityEngine;
using System.Collections;

public class Dragable : MonoBehaviour 
{
    public bool isLocked = false;
    public bool isDragging = false;

    void Update()
    {
        if (!isLocked)
        {
            rigidbody2D.isKinematic = !isDragging;
            if (isDragging)
                rigidbody2D.MovePosition(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
        
    }


    public void Lock()
    {
        isLocked = true;
    }
    public void Unlock()
    {
        isLocked = false;
    }
    public void OnMouseDown()
    {
        if (!isLocked)
            isDragging = true;
    }

    public void OnMouseUp()
    {
        if (!isLocked)
            isDragging = false;
    }

    public void OnCollisionEnter2D(Collision2D coll)
    {
    }
    
}
