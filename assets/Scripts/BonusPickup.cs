using UnityEngine;
using System.Collections;

public class BonusPickup : MonoBehaviour 
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Roller") 
		{
			LevelMaster.Instance.BonusCollect();
            this.gameObject.SetActive(false);

		}
    }
}
