using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using System.Xml;
using System.Xml.Serialization;

public class LevelLoader : MonoBehaviour 
{
    private static LevelLoader instance;
    public static LevelLoader Instance
    {
        get
        {
            return instance;
        }
    }

    void Awake()
    {
        instance = this;
        //DontDestroyOnLoad(this);
    }

    public void LoadLevel(int level)
    {
        Application.LoadLevel(level);
    }

    public void LoadLevel(string level)
    {
        Application.LoadLevel(level);
    }
}
