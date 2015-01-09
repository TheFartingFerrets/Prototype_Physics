using UnityEngine;
using System.Collections;

public enum GameState
{
    loading,
    inMain,
    inLevelSelect,
    inLevel,
}

public class GameControl : MonoBehaviour 
{
    public static GameControl control;

    GameState GameState = GameState.loading;

    string[] Worlds = {"Menu", "Maths", "Physics", "Collect", "Reflex" };

    public string World = "Menu";
    public int Level = 0;

    [SerializeField]
    GameObject MenuCanvas;
    [SerializeField]
    GameObject WorldCanvas;
    [SerializeField]
    GameObject LevelCanvas;


    void Awake()
    {
        control = this;
        DontDestroyOnLoad(this);

    }
    void Start()
    {
        LoadData();
    }
    void Update()
    {
        //Bind Android buttons
#if UNITY_ANDROID
        if (Input.GetKey(KeyCode.Escape))
            ApplicationQuit();
        if (Input.GetKey(KeyCode.Menu))
            ApplicationOptions();
#endif
    }

    //Hardware Button Events
    void ApplicationOptions()
    {

    }
    void ApplicationQuit()
    {
        if (GameState == GameState.inLevel)
            LoadMain();
        if (GameState == GameState.inLevelSelect)
            LoadMain();
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

    }
    public void LoadingFinished()
    {
        LoadMain();
    }

    public void LoadMain()
    {
        World = Worlds[0];
        Level = 0;
        StopAllCoroutines();
        StartCoroutine("_LoadMain");
    }
    public void LoadWorld( int worldID )
    {
        World = Worlds[worldID];
        Level = 0;
        StopAllCoroutines();
        StartCoroutine("_LoadWorld");
    }
    public void LoadLevel( int levelID )
    {
        Level = levelID;
        StopAllCoroutines();
        StartCoroutine("_LoadLevel");
    }
    public void LoadLevel(string LevelName)
    {
        StopAllCoroutines();
        StartCoroutine("_LoadLevel", LevelName);
    }


    //Loads the data from persistent data
    IEnumerator _LoadData()
    {
        Handheld.StartActivityIndicator();
        
        yield return null;
        yield return null;

        Handheld.StopActivityIndicator();
        LoadingFinished();     
    }
    //Load MainMenu
    IEnumerator _LoadMain()
    {
        Handheld.StartActivityIndicator();

        Application.LoadLevel("Main");

        yield return null;
        yield return null;

        MenuCanvas = GameObject.Find("MenuCanvas");
        WorldCanvas = GameObject.Find("WorldCanvas");
        LevelCanvas = GameObject.Find("LevelCanvas");

        WorldCanvas.GetComponent<CanvasControl>().Visible();

        Handheld.StopActivityIndicator();

        GameState = GameState.inMain;
    }
    //Load World Level Select
    IEnumerator _LoadWorld( )
    {
        Handheld.StartActivityIndicator();
        
        LevelCanvas.GetComponent<CanvasControl>().Visible();
        
        yield return null;
        yield return null;

        Handheld.StopActivityIndicator();
        GameState = GameState.inLevelSelect;
    }
    //Load level
    IEnumerator _LoadLevel()
    {
        Handheld.StartActivityIndicator();

        string LevelName = World + "_" + Level;

        Application.LoadLevel(LevelName);

        yield return null;
        yield return null;

        Handheld.StopActivityIndicator();

        GameState = GameState.inLevel;
    }
    IEnumerator _LoadLevel(int levelPrefix)
    {
        Handheld.StartActivityIndicator();

        Application.LoadLevel(levelPrefix);

        yield return null;
        yield return null;

        Handheld.StopActivityIndicator();
    }
}

