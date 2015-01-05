using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

[System.Serializable]
public class Level 
{
    [XmlAttribute("id")]
    public int id;
    public int status;
    public bool bonus;
}

[XmlRoot("worldData")]
[System.Serializable]
public class World
{
    [XmlArray("levels")]
    [XmlArrayItem("level")]
    public List<Level> levelData = new List<Level>();

    static string path = Application.persistentDataPath + "/PhysicsWorld.xml";

    public World Load()
    {
        WorldMaster.Instance.SaveState = SaveState.loading;
        if (!File.Exists(path))
            File.WriteAllText(path, Resources.Load<TextAsset>("PhysicsWorld").text);
        var serializer = new XmlSerializer(typeof(World));
        using (var stream = new FileStream(path, FileMode.Open))
        {
            WorldMaster.Instance.SaveState = SaveState.loaded;
            return serializer.Deserialize(stream) as World;
        }
    }

    public void Save( )
    {
        WorldMaster.Instance.SaveState = SaveState.saving;
        var serializer = new XmlSerializer(typeof(World));
        using (var stream = new FileStream(path, FileMode.Create))
        {
            serializer.Serialize(stream, this);
        }
        WorldMaster.Instance.SaveState = SaveState.saved;
    }
}