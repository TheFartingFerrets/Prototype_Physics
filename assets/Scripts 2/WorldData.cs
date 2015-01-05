using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

public class WorldData : MonoBehaviour
{
//    public static void MoveWorldData()
//    {
//        //if (!System.IO.File.Exists(Application.persistentDataPath + "/LevelData.xml"))
//            System.IO.File.WriteAllText(Application.persistentDataPath + "/LevelData.xml", Resources.Load<TextAsset>("LevelData").text);
//            Debug.Log("File Moved");
//#endif
//    }

    public void Load()
    {
        if (!File.Exists(Application.persistentDataPath + "/PhysicsWorld.xml"))
        {
        }
    }

    public void Save()
    {
        if (!File.Exists(Application.persistentDataPath + "/PhysicsWorld.xml"))
        {

        }
    }
}
