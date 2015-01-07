using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BuildAssetSpawner : MonoBehaviour 
{
    public static BuildAssetSpawner instance;

    [SerializeField]
    List<int> Stock = new List<int>();
    [SerializeField]
    List<GameObject> Storage = new List<GameObject>();
        
    void Awake()
    {
        instance = this;
    }
    //0
    public void SpawnBlock()
    {
        if( Stock[0] > 0)
        {
            CreateItem(0);
        }
    }
    //1
    public void SpawnSpeedBlock()
    {
        if (Stock[1] > 0)
        {
            CreateItem(1);
        }
    }
    //2
    public void SpawnSpring()
    {
        if (Stock[2] > 0)
        {
            CreateItem(2);
        }
    }
    //3
    public void SpawnPortalIn()
    {
        if (Stock[3] > 0)
        {
            CreateItem(3);
        }
    }
    //4
    public void SpawnPortalOut()
    {
        if (Stock[4] > 0)
        {
            CreateItem(4);
        }
    }

    private void CreateItem( int i )
    {
        Stock[i]--;
        GameObject g = (GameObject)Instantiate(Storage[i], Vector2.zero, Quaternion.identity);
    }
}
