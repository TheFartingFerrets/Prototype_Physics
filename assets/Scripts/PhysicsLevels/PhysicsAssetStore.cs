using UnityEngine;
using System.Collections;

public class PhysicsAssetStore : MonoBehaviour 
{
    public GameObject[] Store = new GameObject[9];
    public int[] Limit = new int[9];
    public Transform Container;


    public void GrabAsset(int id)
    {
        if(Limit[id] > 0)
        {
            Limit[id]--;
            GameObject a = (GameObject)Instantiate(Store[id], Container.position, Quaternion.identity);
            Container.GetComponent<PhysicsLevelAssets>().GiveAsset(a);
        }
    }
}
