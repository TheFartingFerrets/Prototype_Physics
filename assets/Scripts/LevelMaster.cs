using UnityEngine;
//using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public enum State
{
    loaded = 0,
    start = 1,
    playing = 2,
    restart = 3,
    completed = 4,
}

public class LevelMaster : MonoBehaviour 
{

    private static LevelMaster instance;
    public static LevelMaster Instance
    {
        get
        {
            return instance;
        }
    }

    public GameObject CanvasObject;

    public int LevelState;
    //public Vector2 RollerPosition;
    //public Vector2 TargetPosition;
    
    public Transform RollerPosition;
    public Transform TargetPosition;

    public GameObject Roller;
    public GameObject Target;
    public GameObject Bonus;
    public GameObject[] Statics;
    
    public Dictionary<string, int> Placeables = new Dictionary<string, int>();

	private bool BonusCollected = false;

    public List<GameObject> customObjects = new List<GameObject>();

    public bool showBoundary = true;

    void Awake()
    {
        instance = this;
        this.transform.position = Camera.main.transform.position;
    }
    void Start()
    {
        LevelState = (int)State.loaded;
    }
    void Update()
    {
        switch (LevelState)
        {
            case 0:
                CreateLevel();
                //CanvasObject.transform.GetChild(0).gameObject.SetActive(true);
                //CanvasObject.transform.GetChild(1).gameObject.SetActive(false);
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                GameObject.FindGameObjectWithTag("Roller").SendMessage("Stop");
                //CanvasObject.transform.GetChild(0).gameObject.SetActive(false);
                //CanvasObject.transform.GetChild(1).gameObject.SetActive(true);
                break;
            default:
                Debug.Log("Not defined");
                break;
        }
    }

	void OnGUI()
	{
		switch (LevelState) 
		{
		case 1:
			GUILayout.BeginHorizontal();
			if(GUILayout.Button("Start"))
				PlayScene();
			if( GUILayout.Button("Reset Level"))
				HardRest();
			GUILayout.EndHorizontal();
			GUILayout.Space(Screen.height-50f	);
			
			GUILayout.BeginHorizontal();
			if( GUILayout.Button("[===]"))
				GetPlaceable(0);
			
			if( GUILayout.Button("||"))
				GetPlaceable(1);
			
			if( GUILayout.Button("//"))
				GetPlaceable(2);
			
			if( GUILayout.Button("'\\'"))
				GetPlaceable(3);
			
			if( GUILayout.Button("->()"))
				GetPlaceable(4);
			
			if( GUILayout.Button("()->"))
				GetPlaceable(5);
			
			
			
			GUILayout.EndHorizontal();
			break;
		case 2:
			GUILayout.BeginHorizontal();
			if( GUILayout.Button("Retry"))
				StartCoroutine(SoftReset());
			
			if( GUILayout.Button("Reset Level"))
				HardRest();
			GUILayout.EndHorizontal();
			break;
		case 3:


			break;
		case 4:
			GUI.color = Color.black;
			GUILayout.BeginArea( new Rect( Screen.width/2 - 100f, Screen.height/2, 200f, 400f));
			GUILayout.Label("Congratulations, You've done it!");
			GUILayout.Space(20f);
			GUILayout.Label("You used " + customObjects.Count + " objects!");
			GUILayout.Space(20f);
			if( BonusCollected == true )
			{
				GUILayout.Label("You collected the bonus star!");
			}
			else
			{
				GUILayout.Label("You didn't collect the bonus star!");
			}
			GUILayout.EndArea();
			
			break;
		default:
			break;
		}
	}

	public void BonusCollect()
	{
		Debug.Log ("Collected");
		BonusCollected = true;
	}

    private void CreateLevel()
    {
        SpawnRoller(RollerPosition.position);
        SpawnTarget(TargetPosition.position);
        SpawnStatics(Vector2.zero);
        SpawnPlaceables(Vector2.zero);
        
        LevelState = (int)State.start;
    }
    public void PlayScene()
    {

        LockCustom();
        LevelState = (int)State.playing;
        GameObject.FindGameObjectWithTag("Roller").SendMessage("Play");
        DisableButtons();
    }
    public void RestartScene()
    {
        StartCoroutine(SoftReset());
    }
    public void HardRest()
    {
        Application.LoadLevel( Application.loadedLevel );
    }
    public void BackToMain()
    {
        Application.LoadLevel(0);
    }
    private void EnableButtons()
    {
        /*foreach (Transform c in CanvasObject.transform.GetChild(0).GetChild(1).transform)
        {
          c.GetComponent<Button>().interactable = true;
        }*/
    }
    private void DisableButtons()
    {
        /*foreach (Transform c in CanvasObject.transform.GetChild(0).GetChild(1).transform)
        {
            //c.GetComponent<Button>().interactable = false;
        }*/
    }
    private void LockCustom()
    {
        for (int i = 0; i < customObjects.Count; i++)
        {
            customObjects[i].SendMessage("Lock");
        }
    }
    private void UnlockCustom()
    {
        for (int i = 0; i < customObjects.Count; i++)
        {
            customObjects[i].SendMessage("Unlock");
        }
    }
    IEnumerator SoftReset()
    {
        LevelState = (int)State.start;
        GameObject.FindGameObjectWithTag("Roller").SendMessage("Restart");
        UnlockCustom();
        EnableButtons();
        yield return new WaitForSeconds(0.1f);
    }

    IEnumerator CompleteLevel()
    {
        yield return new WaitForSeconds(0.2f);
        LevelState = (int)State.completed;
    }


    void SpawnRoller(Vector2 pos)
    {
        Instantiate(Roller, pos, Quaternion.identity);
    }
    void SpawnTarget(Vector2 pos)
    {
        Instantiate(Target, pos+Vector2.up*0.5f, Quaternion.identity);
    }
    void SpawnBonus(Vector2 pos) { }
    void SpawnStatics(Vector2 pos) { }
    void SpawnPlaceables( Vector2 pos)
    {
        Placeables.Add("floorH", 4);
        Placeables.Add("floorV", 4);
        Placeables.Add("floor45", 4);
        Placeables.Add("floor45i", 4);

        Placeables.Add("portalIn", 1);
        Placeables.Add("portalOut", 1);

    }
    public void GetPlaceable(int i)
    {
        
        switch( i )
        {
            case 0:
                if (Placeables["floorH"] > 0)
                {
                    Placeables["floorH"] -= 1;
                    GameObject g = Instantiate(Resources.Load("Floor_H"), Vector2.zero, Quaternion.identity) as GameObject;
                    customObjects.Add(g);
                }
                break;
            case 1:
                if (Placeables["floorV"] > 0)
                {
                    Placeables["floorV"] -= 1;
                    GameObject g = Instantiate(Resources.Load("Floor_H"), Vector2.zero, Quaternion.Euler(0, 0, 90)) as GameObject;
                    customObjects.Add(g);
                }
                break;
            case 2:
                if (Placeables["floor45"] > 0)
                {
                    Placeables["floor45"] -= 1;
                    GameObject g = Instantiate(Resources.Load("Floor_H"), Vector2.zero, Quaternion.Euler(0, 0, 45)) as GameObject;
                    customObjects.Add(g);
                }
                break;
            case 3:
                if (Placeables["floor45i"] > 0)
                {
                    Placeables["floor45i"] -= 1;
                    GameObject g = Instantiate(Resources.Load("Floor_H"), Vector2.zero, Quaternion.Euler(0, 0, -45)) as GameObject;
                    customObjects.Add(g);
                }
                break;
            case 4:
                if (Placeables["portalIn"] > 0)
                {
                    Placeables["portalIn"] -= 1;
                    GameObject g = Instantiate(Resources.Load("PortalIn"), Vector2.zero, Quaternion.Euler(0, 0, -90)) as GameObject;
                    customObjects.Add(g);
                }
                break;
            case 5:
                if (Placeables["portalOut"] > 0)
                {
                    Placeables["portalOut"] -= 1;
                    GameObject g = Instantiate(Resources.Load("PortalOut"), Vector2.zero, Quaternion.Euler(0, 0, 135)) as GameObject;
                    customObjects.Add(g);
                }
                break;
            case 6:
                break;
            case 7:
                break;
            default:
                break;
        }

    }




    [ExecuteInEditMode]
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        if ( showBoundary )
            Gizmos.DrawWireCube(transform.position + Vector3.forward * Camera.main.farClipPlane / 2, new Vector3(Camera.main.ViewportToWorldPoint(Vector3.zero).x * 2, Camera.main.ViewportToWorldPoint(Vector3.zero).y * 2, Camera.main.farClipPlane));
    }
}
