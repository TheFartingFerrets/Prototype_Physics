using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour
{




    public void SetSpawn(Vector2 pos)
    {
        this.transform.position = pos;
    }


    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Roller")
        {
            other.SendMessage("DecreaseSpeed");

            LevelMaster.Instance.StartCoroutine("CompleteLevel");

        }
    }
}