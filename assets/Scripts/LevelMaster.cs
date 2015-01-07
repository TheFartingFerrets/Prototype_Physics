using UnityEngine;
using System.Collections;

public enum LevelState
{
    building,
    playing,
    completed
}

public class LevelMaster : MonoBehaviour 
{
    public static LevelMaster instance;
    public LevelState LevelState = LevelState.building;

    [SerializeField]
    GameObject Roller;
    [SerializeField]
    GameObject Target;
    [SerializeField]
    GameObject Bonus;

    void Awake()
    {
        instance = this;
        if (!Roller) Roller = GameObject.FindGameObjectWithTag("Roller");
        if (!Target) Target = GameObject.FindGameObjectWithTag("Target");
        //if (!Bonus) Roller = GameObject.FindGameObjectWithTag("Bonus");
    }
    [ExecuteInEditMode]
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position + Vector3.forward * Camera.main.farClipPlane / 2, new Vector3(Camera.main.ViewportToWorldPoint(Vector3.zero).x * 2, Camera.main.ViewportToWorldPoint(Vector3.zero).y * 2, Camera.main.farClipPlane));
    }
    public void PlayLevel()
    {
        if (LevelState == LevelState.playing)
        {
            ResetLevel();
        }
        else
        {
            LockAssets();
            LevelState = LevelState.playing;
            Roller.GetComponent<Roller>().WakeUp();
        }
        
    }
    public void ResetLevel()
    {
        UnlockAssets();
        LevelState = LevelState.building;
        Roller.GetComponent<Roller>().Reset();
    }
    public void Settings()
    {

    }
    public void OpenAssetDraw()
    {
        
    }
    public void CloseAssetDraw()
    {

    }

    void LockAssets()
    {
        GameObject[] LevelAsset = GameObject.FindGameObjectsWithTag("LevelAsset");
        foreach(GameObject Asset in LevelAsset)
        {
            Asset.GetComponent<LevelAsset>().Lock();
        }
    }
    void UnlockAssets()
    {
        GameObject[] LevelAsset = GameObject.FindGameObjectsWithTag("LevelAsset");
        foreach (GameObject Asset in LevelAsset)
        {
            Asset.GetComponent<LevelAsset>().Unlock();
        }
    }

    public void CompleteLevel()
    {
        LevelUI.instance.ShowComplete();
    }
}
