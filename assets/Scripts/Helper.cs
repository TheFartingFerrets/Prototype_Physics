//using UnityEngine;
//using System.Collections;


//[ExecuteInEditMode]
//public class Helper : MonoBehaviour {

//    public int gameState = (int)GameState.setup;


//    public void OnDrawGizmos()
//    {
//        Gizmos.color = Color.yellow;
//        Gizmos.DrawWireCube(transform.position + Vector3.forward* Camera.main.farClipPlane/2, new Vector3(Camera.main.ViewportToWorldPoint(Vector3.zero).x*2, Camera.main.ViewportToWorldPoint(Vector3.zero).y*2, Camera.main.farClipPlane));
//    }

//    public void OnGUI()
//    {
        
//        GUILayout.BeginHorizontal();

//        if (gameState == 0)
//        {
//            if (GUILayout.Button("Start"))
//            {
//                StartLevel();
//            }
//        }

//        if (gameState == 1)
//        {
//            if (GUILayout.Button("Reset Roller"))
//            {
//                ResetLevel();
//            }
//        }
//        GUILayout.EndHorizontal();
//    }



//    void StartLevel()
//    {
//        gameState = 1;
//        GameObject.Find("Roller").SendMessage("Wake");

//    }


//    void ResetLevel()
//    {
//        gameState = 0;
//        GameObject.Find("Roller").SendMessage("SetRoller");
//    }


//}
