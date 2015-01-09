using UnityEngine;
using System;
using System.Collections;
using TouchScript.Gestures;

[RequireComponent(typeof(Rigidbody2D))]
public class LevelAsset : MonoBehaviour
{
    [SerializeField]
    bool isLocked = false;
    [SerializeField]
    Vector2 DragOffset = Vector2.zero;

    int touch;
    public void OnMouseDown()
    {
        if( !isLocked )
        {
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            DragOffset.x = touchPos.x - rigidbody2D.position.x;
            DragOffset.y = touchPos.y - rigidbody2D.position.y;
        }
    }

    public void OnMouseDrag()
    {
        if(!isLocked)
        {
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            rigidbody2D.MovePosition(touchPos - DragOffset);
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
        AssetEdit.instance.Reset();
        AssetEdit.instance.Target = this.transform;
    }

    
    public void Lock()
    {
        isLocked = true;
    }
    public void Unlock()
    {
        isLocked = false;
    }

}
