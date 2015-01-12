using UnityEngine;
using System.Collections;
using System.IO;

public enum GameState
{
    loading,
    inMain,
    inLevelSelect,
    inLevel,
    inOptions,
}
public class GameControl : MonoBehaviour 
{
    public static GameControl control;

    GameState GameState = GameState.loading;

    public LevelData LevelData;
    
    string[] Worlds = {"Menu", "Maths", "Physics", "Collect", "Reflex" };
    public int World = 0;
    public int Level = 0;

    public GameObject MenuCanvas;
    public GameObject WorldCanvas;
    public GameObject LevelCanvas;
    
    [ExecuteInEditMode]
    void Awake()
    {
        control = this;
        DontDestroyOnLoad(this);
        MenuCanvas = GameObject.Find("MenuCanvas");
    }

    public void ControlUISleep()
    {
        transform.GetChild(1).gameObject.SetActive(false);
    }
    public void ControlUIWake()
    {
        transform.GetChild(1).gameObject.SetActive(true);
    }
    public void CameraSleep()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }
    public void CameraWake()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }
    void Start()
    {
        LoadData();
    }
    void Update()
    {
        //Bind Android buttons
#if UNITY_ANDROID
        if( GameState != GameState.loading || GameState != GameState.inOptions)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                ApplicationQuit();
            if (Input.GetKeyDown(KeyCode.Menu))
                ApplicationOptions();
        }
        
        
#endif
    }
    //Hardware Button Events
    public void ApplicationOptions()
    {
        Debug.Log("Options");
        MenuCanvas.transform.GetChild(1).GetComponent<CanvasControl>().Toggle();
    }
    void ApplicationQuit()
    {
        if (GameState == GameState.inLevel)
        {
            ControlUIWake();
            CameraWake();
            LoadToLevelSelect();
        }
        if (GameState == GameState.inLevelSelect)
        {
            ControlUIWake();
            CameraWake();
            LoadMain();
        }
        if( GameState == GameState.inMain)
            Application.Quit();
    }
    //Load data from persistent Data
    public void LoadData()
    {
        StopAllCoroutines();
        StartCoroutine("_LoadData");
    }
    //Save data from persistent Data
    public void SaveData()
    {
        StopAllCoroutines();
        StartCoroutine("_SaveData");
    }
    public void DeleteData()
    {
        StopAllCoroutines();
        StartCoroutine("_DeleteData");
    }
    public void LoadingFinished()
    {
        LoadMain();
    }
    public void LoadMain()
    {
        GameState = GameState.loading;
        World = 0;
        Level = 0;
        StopAllCoroutines();
        StartCoroutine("_LoadMain");
    }
    public void LoadToLevelSelect()
    {
        GameState = GameState.loading;
        Level = 0;
        StopAllCoroutines();
        StartCoroutine("_LoadToLevelSelect");
    }
    public void LoadWorld( int worldID )
    {
        GameState = GameState.loading;
        World = worldID;
        Level = 0;
        StopAllCoroutines();
        StartCoroutine("_LoadWorld");
    }
    public void LoadLevel( int levelID )
    {
        GameState = GameState.loading;
        Level = levelID;
        StopAllCoroutines();
        StartCoroutine("_LoadLevel");
    }

    //Loads the data from persistent data
    IEnumerator _LoadData()
    {
        Handheld.StartActivityIndicator();

        //LevelData.Delete( false );
        LevelData = LevelData.Load();

        yield return null;
        yield return null;

        Handheld.StopActivityIndicator();
        MenuCanvas.transform.GetChild(1).GetComponent<CanvasControl>().Invisible();
        LoadingFinished();     
    }

    IEnumerator _SaveData()
    {
        Handheld.StartActivityIndicator();

        LevelData.Save( LevelData );

        yield return null;
        yield return null;

        Handheld.StopActivityIndicator();
        MenuCanvas.transform.GetChild(1).GetComponent<CanvasControl>().Invisible();
        LoadingFinished();  
    }
    IEnumerator _DeleteData()
    {
        Handheld.StartActivityIndicator();

        LevelData.Delete();
        LevelData = new LevelData();

        yield return null;
        yield return null;

        Handheld.StopActivityIndicator();
        ApplicationOptions();
    }
    //Load MainMenu
    IEnumerator _LoadMain()
    {
        Handheld.StartActivityIndicator();

        Application.LoadLevel("Main");

        yield return null;
        yield return null;

        MenuCanvas = GameObject.FindGameObjectWithTag("Menu");
        WorldCanvas = GameObject.FindGameObjectWithTag("World");
        LevelCanvas = GameObject.FindGameObjectWithTag("Level");

        WorldCanvas.GetComponent<CanvasControl>().Visible();
        LevelCanvas.GetComponent<CanvasControl>().Invisible();
        LevelCanvas.GetComponent<LevelCanvas>().EditLevelInfo(LevelData.Maths, 0);
        LevelCanvas.GetComponent<LevelCanvas>().EditLevelInfo(LevelData.Physics, 1);
        LevelCanvas.GetComponent<LevelCanvas>().EditLevelInfo(LevelData.Collect, 2);
        LevelCanvas.GetComponent<LevelCanvas>().EditLevelInfo(LevelData.Reflex, 3);

        Handheld.StopActivityIndicator();

        GameState = GameState.inMain;
    }
    //Load World Level Select
    IEnumerator _LoadWorld( )
    {
        Handheld.StartActivityIndicator();

        WorldCanvas.GetComponent<CanvasControl>().Invisible();
        LevelCanvas.GetComponent<CanvasControl>().Visible();
        LevelCanvas.GetComponent<LevelCanvas>().ShowWorldLevel();
        
        yield return null;
        yield return null;

        Handheld.StopActivityIndicator();
        GameState = GameState.inLevelSelect;
    }
    //Load level
    IEnumerator _LoadLevel()
    {
        Handheld.StartActivityIndicator();
            
        string LevelName = Worlds[World] + "_" + Level;

        Application.LoadLevel(LevelName);

        yield return null;
        yield return null;

        Handheld.StopActivityIndicator();

        GameState = GameState.inLevel;
    }
    IEnumerator _LoadToLevelSelect()
    {
        Handheld.StartActivityIndicator();

        Application.LoadLevel("Main");

        yield return null;
        yield return null;

        MenuCanvas = GameObject.FindGameObjectWithTag("Menu");
        WorldCanvas = GameObject.FindGameObjectWithTag("World");
        LevelCanvas = GameObject.FindGameObjectWithTag("Level");

        WorldCanvas.GetComponent<CanvasControl>().Invisible();
        LevelCanvas.GetComponent<CanvasControl>().Visible();
        LevelCanvas.GetComponent<LevelCanvas>().EditLevelInfo(LevelData.Maths, 0);
        LevelCanvas.GetComponent<LevelCanvas>().EditLevelInfo(LevelData.Physics, 1);
        LevelCanvas.GetComponent<LevelCanvas>().EditLevelInfo(LevelData.Collect, 2);
        LevelCanvas.GetComponent<LevelCanvas>().EditLevelInfo(LevelData.Reflex, 3);

        LevelCanvas.GetComponent<LevelCanvas>().ShowWorldLevel();

        Handheld.StopActivityIndicator();
        GameState = GameState.inLevelSelect;
    }
    IEnumerator _LoadLevel(int levelPrefix)
    {
        Handheld.StartActivityIndicator();

        Application.LoadLevel(levelPrefix);

        yield return null;
        yield return null;

        Handheld.StopActivityIndicator();
    }

    public void OnGUI()
    {
        GUILayout.Label(LevelData.Maths.Length.ToString());
        GUILayout.Label(LevelData.Physics.Length.ToString());
        GUILayout.Label(LevelData.Reflex.Length.ToString());
        GUILayout.Label(LevelData.Collect.Length.ToString());
    }






    //Forced Events for testing
    //Will be removed

#if UNITY_EDITOR
    public void ForceSave()
    {
        LevelData.ForceSave(true);
    }
    public void ForceLevel()
    {
        LevelData.Maths[0].Objectives[0] = true;
        LevelData.Maths[2].Objectives[0] = true;
        LevelData.Maths[2].Objectives[1] = true;
        LevelData.Maths[4].Objectives[2] = true;
        LevelData.Maths[8].Objectives[2] = true;

        SaveData();
    }
    public void ForceDelete()
    {
        //LevelData.Delete(true);
        //LevelData.Delete(false);
    }
#endif

    public void ObjectiveStatus(int num, bool status)
    {
        CurrentLevel().ObjectiveStatus(num-1, status);
    }



    private Level CurrentLevel()
    {
        Level currLevel = new Level();
        Debug.Log(World);
        switch( World)
        {
            case 1:
                currLevel = LevelData.Maths[Level-1];
                break;
            case 2:
                currLevel = LevelData.Physics[Level-1];
                break;
            case 3:
                currLevel = LevelData.Collect[Level-1];
                break;
            case 4:
                currLevel = LevelData.Reflex[Level-1];
                break;
        }
        return currLevel;
    }
}
