using UnityEngine;
using System.Collections;

public class AssetEditRotate : MonoBehaviour 
{

    public void OnMouseDrag()
    {
        SendMessageUpwards("RotateAsset");
    }


}
