using UnityEngine;
using System.Collections;

public class OptionsControl : MonoBehaviour 
{
    void Awake()
    {
        GetComponent<CanvasControl>().Invisible();
    }
}
