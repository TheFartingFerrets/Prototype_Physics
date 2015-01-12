using UnityEngine;
using System;
using System.Collections;
using TouchScript.Gestures;

[RequireComponent(typeof(Rigidbody2D))]
public class PhysicsLevelAsset : MonoBehaviour 
{
    private bool isLocked = false;
    private Vector2 DragOffset = Vector2.zero;
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
        if(!isLocked)
        {
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            DragOffset = touchPosition - rigidbody2D.position;
        }
    }

    public void OnMouseDrag()
    {
        if( !isLocked )
        {
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            rigidbody2D.MovePosition(touchPosition - DragOffset);
        }
    }

    public void OnMouseUp()
    {
        DragOffset = Vector2.zero;
    }

    public void OnEnable()
    {
        GetComponent<TapGesture>().Tapped += tappedHandler;
    }

    public void OnDisable()
    {
        GetComponent<TapGesture>().Tapped -= tappedHandler;
    }


    public void tappedHandler(object sender, EventArgs e)
    {
        if( !isLocked )
        {
            if( PhysicsEditor.instance.EditTarget != null)
            {
                Debug.Log("Has edit target");
                if( PhysicsEditor.instance.EditTarget == this.transform)
                {
                    Debug.Log("Is Same");
                    PhysicsEditor.instance.Hide();
                }
                else
                {
                    PhysicsEditor.instance.SetTarget(this.transform);
                }
            }
            else
            {
                PhysicsEditor.instance.SetTarget(this.transform);
            }
            Debug.Log("Tapped");
        }
        
    }

}
