using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


[System.Serializable]
public class Level
{
    public int status;
    public bool[] Objectives = new bool[3];
    public int Bonus;

    public void ObjectiveStatus(int num, bool status)
    {
        Objectives[num] = status;
    }

    public void ObjectiveStatus(bool obj1, bool obj2, bool obj3)
    {
        Objectives[0] = obj1;
        Objectives[2] = obj2;
        Objectives[3] = obj3;
    }

    public Level()
    {
        status = 0;

        Objectives[0] = false;
        Objectives[1] = false;
        Objectives[2] = false;
        
        Bonus = 0;
    }
}

[System.Serializable]
public class LevelData
{
    public Level[] Maths = new Level[9];
    public Level[] Physics = new Level[9];
    public Level[] Collect = new Level[9];
    public Level[] Reflex = new Level[9];

    public LevelData Load()
    {
        if( !File.Exists(Application.persistentDataPath+"/data.dat"))
        {
            Debug.Log("File doesnt exist");
            CreateData();
        }
        BinaryFormatter bf = new BinaryFormatter();
        using (var file = new FileStream(Application.persistentDataPath + "/data.dat", FileMode.Open))
        {
            LevelData ld = (LevelData)bf.Deserialize(file);
            Debug.Log(ld.Maths[0].Objectives[0]);
            return ld;
        }
    }

    public void Save( LevelData toSave )
    {
        Debug.Log("Checking File");
        if( !File.Exists( Application.persistentDataPath+"/data.dat"))
        {
            Debug.Log("File doesnt exist");
            CreateData();
        }
        Debug.Log(toSave.Maths[0].Objectives[0]);
        BinaryFormatter bf = new BinaryFormatter();
        using (var file = new FileStream(Application.persistentDataPath + "/data.dat", FileMode.OpenOrCreate))
        {
            bf.Serialize(file, toSave);
        }
    }
    public void Delete()
    {
        if (File.Exists(Application.persistentDataPath + "/data.dat"))
        {
            Debug.Log("Deleting file");
            File.Delete(Application.persistentDataPath + "/data.dat");
            Debug.Log("File Deleted");
        }

    }

    //public void Delete(bool openLoc)
    //{
    //    if (openLoc)
    //        System.Diagnostics.Process.Start(@"" + Application.persistentDataPath+"");

    //    if (File.Exists(Application.persistentDataPath + "/data.dat"))
    //    {
    //        Debug.Log("Deleting file");
    //        File.Delete(Application.persistentDataPath + "/data.dat");
    //        Debug.Log("File Deleted");
    //    }
    //}

    



    //Add total levels to each world
    private void CreateData()
    {
        Debug.Log("Adding levels to Maths World");
        for (int i = 0; i < Maths.Length; i++)
            Maths[i] = new Level();
        Debug.Log("Adding levels to Physics World");
        for (int i = 0; i < Physics.Length; i++)
            Physics[i] = new Level();
        Debug.Log("Adding levels to Reflex World");
        for (int i = 0; i < Reflex.Length; i++)
            Reflex[i] = new Level();
        Debug.Log("Adding levels to Collect World");
        for (int i = 0; i < Collect.Length; i++)
            Collect[i] = new Level();

        Debug.Log("Creating File");
        BinaryFormatter bf = new BinaryFormatter();
        using (var file = new FileStream(Application.persistentDataPath + "/data.dat", FileMode.Create))
        {
            bf.Serialize(file, this);
        }
    }
    public void ForceSave(bool openLoc)
    {
        if (openLoc)
            System.Diagnostics.Process.Start(@"" + Application.persistentDataPath + "");
        LevelData t = new LevelData();

        Debug.Log("Adding levels to Maths World");
        for (int i = 0; i < Maths.Length; i++)
            Maths[i] = new Level();
        Debug.Log("Adding levels to Physics World");
        for (int i = 0; i < Physics.Length; i++)
            Physics[i] = new Level();
        Debug.Log("Adding levels to Reflex World");
        for (int i = 0; i < Reflex.Length; i++)
            Reflex[i] = new Level();
        Debug.Log("Adding levels to Collect World");
        for (int i = 0; i < Collect.Length; i++)
            Collect[i] = new Level();

        Debug.Log("Creating File");
        BinaryFormatter bf = new BinaryFormatter();
        using (var file = new FileStream(Application.persistentDataPath + "/data.dat", FileMode.Create))
        {
            bf.Serialize(file, t);
        }
    }
}
