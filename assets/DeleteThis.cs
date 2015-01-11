using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[ExecuteInEditMode]
public class DeleteThis : MonoBehaviour 
{
    void Update()
    {
        
        this.GetComponent<Text>().text = Application.loadedLevelName;
    }

    public void OnGUI()
    {
        if( GUILayout.Button("Complete Obj1!"))
        {
            CompleteObj1();
        }
        if (GUILayout.Button("Complete Obj2!"))
        {
            CompleteObj2();
        }
        if (GUILayout.Button("Complete Obj3!"))
        {
            CompleteObj3();
        }
    }

    void CompleteObj1()
    {
        GameControl.control.ObjectiveStatus(1, true);
    }
    void CompleteObj2()
    {
        GameControl.control.ObjectiveStatus(2, true);
    }
    void CompleteObj3()
    {
        GameControl.control.ObjectiveStatus(3, true);
    }


}
