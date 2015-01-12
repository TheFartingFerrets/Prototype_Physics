using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public enum PhysicsLevelState
{
    building,
    playing,
    completed,
}
public class PhysicsLevelControl : MonoBehaviour 
{
    public PhysicsLevelState State = PhysicsLevelState.building;
    
    [SerializeField]
    GameObject Roller;
    [SerializeField]
    GameObject EndTarget;
    [SerializeField]
    Vector2 RollerStartPosition = Vector2.zero;


    [SerializeField]
    Transform LevelCanvas;
    
    public Objectives[] LevelObjectives = new Objectives[3];

    void Awake()
    {
        if (!Roller) Debug.LogError("No Roller");
        if (!EndTarget) Debug.LogError("No EndTarget");
        RollerStartPosition = Roller.rigidbody2D.position;
    }

    void Start()
    {
        if( GameControl.control)
        {
            GameControl.control.CameraSleep();
            GameControl.control.ControlUISleep();
        }
        
        RollerDisable();
        LevelCanvas.GetChild(1).GetComponent<CanvasControl>().Invisible();
    }

    void Update()
    {
        if( State == PhysicsLevelState.playing)
        {
            float DistanceToTarget = Vector2.Distance(EndTarget.rigidbody2D.position, Roller.rigidbody2D.position);

            if (DistanceToTarget < Mathf.Min(EndTarget.collider2D.bounds.extents.x, EndTarget.collider2D.bounds.extents.y))
            {
                CompleteLevel();
            }

        }
    }
    
    public void RunLevel()
    {
        switch( State)
        {
            case PhysicsLevelState.building:
                State = PhysicsLevelState.playing;
                Lock();
                RollerEnable();
                break;
            case PhysicsLevelState.playing:
                State = PhysicsLevelState.building;
                Unlock();
                RollerDisable();
                break;
            case PhysicsLevelState.completed:

                break;
        }
    }
    public void ResetLevel()
    {
        State = PhysicsLevelState.building;
        Unlock();
        RollerDisable();
    }

    public void CompleteLevel()
    {
        StopRoller();
        State = PhysicsLevelState.completed;
        LevelCanvas.GetChild(1).GetComponent<CanvasControl>().Visible();
        LevelCanvas.GetChild(2).GetComponent<CanvasControl>().DisableInteraction();
        LevelCanvas.GetChild(0).GetComponent<CanvasControl>().DisableInteraction();
    }


    public void BackToMain()
    {
        GameControl.control.LoadMain();
        GameControl.control.CameraWake();
        GameControl.control.ControlUIWake();
    }

    //Roller Functions
    private void RollerEnable()
    {
        Roller.rigidbody2D.velocity = Vector2.zero;
        Roller.rigidbody2D.isKinematic = false;
        Roller.rigidbody2D.position = RollerStartPosition;
        Roller.transform.rotation = Quaternion.Euler(Vector3.zero);
    }
    private void StopRoller()
    {
        Roller.rigidbody2D.velocity = Vector2.zero;
        Roller.rigidbody2D.isKinematic = true;
    }
    private void RollerDisable()
    {
        Roller.rigidbody2D.velocity = Vector2.zero;
        Roller.rigidbody2D.isKinematic = true;
        Roller.rigidbody2D.position = RollerStartPosition;
        Roller.transform.rotation = Quaternion.Euler(Vector3.zero);
    }
    
    private void Lock()
    {
        PhysicsEditor.instance.Hide();
        GameObject[] levelAssets = GameObject.FindGameObjectsWithTag("PhysicLevelAsset");
        foreach( GameObject g in levelAssets)
        {
            g.GetComponent<PhysicsLevelAsset>().Lock();
        }
    }

    private void Unlock()
    {
        GameObject[] levelAssets = GameObject.FindGameObjectsWithTag("PhysicLevelAsset");
        foreach (GameObject g in levelAssets)
        {
            g.GetComponent<PhysicsLevelAsset>().Unlock();
        }
    }




  
}
