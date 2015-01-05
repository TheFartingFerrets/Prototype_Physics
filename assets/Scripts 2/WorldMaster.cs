using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public enum SaveState
{
    loading,
    saving,
    loaded,
    saved,
    idle,
}
public enum WorldState
{
    LoadingLevel,
    LoadedLevel,
    Waiting,
}
public enum LevelState
{
    building,
    running,
    complete,
    idle,
}

public class WorldMaster : MonoBehaviour 
{
    private static WorldMaster instance;
    public static WorldMaster Instance
    {
        get
        {
            return instance;
        }
    }
    private GameObject MainCamera;
    public World WorldData = new World();
    public WorldState WorldState;
    public SaveState SaveState;
    public LevelState LevelState = LevelState.building;
    void Awake()
    {
        DontDestroyOnLoad(this);
        if (!instance) instance = this;
        if (!MainCamera) MainCamera = Camera.main.gameObject;
    }
    void Start()
    {
        StartCoroutine(Load());
    }
    public void LoadLevelFromButton(int i)
    {
        StopAllCoroutines();
        StartCoroutine(LoadLevel(i));
    }
    IEnumerator LoadLevel(int i)
    {
        WorldState = WorldState.LoadingLevel;
        Application.LoadLevel(i);
        yield return null;
        yield return null;
        WorldState = WorldState.LoadedLevel;
    }
    IEnumerator Load()
    {
        GUILevel.Instance.ShowLoading();
        WorldData.Load();
        yield return new WaitForSeconds(1f);
        if (SaveState == SaveState.loaded)
        {
            WorldLoaded();
            GUILevel.Instance.HideLoading();
        }
    }
    IEnumerator Save()
    {
        GUILevel.Instance.ShowSaving();
        WorldData.Save();
        yield return new WaitForSeconds(1f);
        if (SaveState == SaveState.saved)
        {
            WorldSaved();
            GUILevel.Instance.HideSaving();
        }
    }
    public void WorldLoaded()
    {
        SaveState = SaveState.idle;
        Debug.Log("Do stuff after loaded");
    }
    public void WorldSaved()
    {
        SaveState = SaveState.idle;
        Debug.Log("World Saved");
    }
    void UpdateLevelSelectUI()
    {
        for(int i = 0; i < WorldData.levelData.Count; i++)
        {

        }
    }

    [ExecuteInEditMode]
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position + Vector3.forward * Camera.main.farClipPlane / 2, new Vector3(Camera.main.ViewportToWorldPoint(Vector3.zero).x * 2, Camera.main.ViewportToWorldPoint(Vector3.zero).y * 2, Camera.main.farClipPlane));
    }
}