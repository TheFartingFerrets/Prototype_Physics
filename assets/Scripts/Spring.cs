using UnityEngine;
using System.Collections;

enum state
{
    ready = 0,
    sprung = 1,
    reseting = 2,
}
public class Spring : MonoBehaviour 
{
    int springState = (int)state.ready;

    public void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Roller" && springState == 0)
        {
            StartCoroutine(LoadSpring(coll));
        }
    }

    public void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Roller" && springState == 0)
        {
            StartCoroutine(LoadSpring(coll));
        }
    }

    void Update()
    {
        transform.localPosition = new Vector2(0, transform.localPosition.y);
    }

    IEnumerator LoadSpring(Collision2D coll)
    {
        springState = (int)state.sprung;
        this.GetComponent<SpringJoint2D>().distance = 0;
        this.rigidbody2D.isKinematic = false;
        coll.gameObject.rigidbody2D.AddForce(transform.up * 10f, ForceMode2D.Impulse);
        //other.transform.rotation = Quaternion.RotateTowards(other.transform.rotation, transform.rotation, 360f);
        yield return new WaitForSeconds(0.2f);
        StartCoroutine(ResetSpring());
    }

    IEnumerator ResetSpring()
    {
        springState = (int)state.reseting;
        yield return new WaitForSeconds(0.2f);
        this.GetComponent<SpringJoint2D>().distance = 0.7f;
        yield return new WaitForSeconds(2f);
        springState = (int)state.ready;
    }


}
