using UnityEngine;
using System.Collections;

public class TouchButton : MonoBehaviour
{
    public GameObject myItem;
    public int amount;
    public GameObject current;

    void Awake()
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject a = (GameObject)Instantiate(myItem);
            a.transform.position = this.transform.position;
            a.transform.rotation = Quaternion.Euler(0, 0, 0);
            a.transform.parent = this.transform;
            a.name = myItem.name;
            a.SetActive(false);
        }
    }

    public void OnMouseDown()
    {
        if (amount > 0)
        {
            current = GetNextChild();
            current.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
            current.gameObject.SetActive(true);

        }
    }

    public void OnMouseDrag()
    {
        if (current != null)
        {
            current.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
        }
    }

    public void OnMouseUp()
    {
        if (amount > 0)
        {
            amount--;
            current = null;
        }
    }


    public void RemoveThis( GameObject child )
    {
        child.SetActive(false);
        child.transform.position = this.transform.position;
        amount += 1;
    }



    public GameObject GetNextChild()
    {
        GameObject a = null;
        foreach (Transform c in transform)
        {
            if (!c.gameObject.activeInHierarchy)
            {
                a = c.gameObject;
                break;
            }
        }
        return a;
    }
}