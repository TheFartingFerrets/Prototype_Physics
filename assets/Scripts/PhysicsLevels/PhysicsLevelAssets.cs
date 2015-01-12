using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PhysicsLevelAssets : MonoBehaviour 
{
    [SerializeField]
    List<GameObject> Assets = new List<GameObject>();

    public void GiveAsset( GameObject g)
    {
        PhysicsEditor.instance.Hide();
        g.transform.SetParent(this.transform);
        Assets.Add(g);
    }

    public void RemoveGameObject( Transform g)
    {

        Destroy(g.gameObject);
        Assets.Remove(g.gameObject);

    }
}

