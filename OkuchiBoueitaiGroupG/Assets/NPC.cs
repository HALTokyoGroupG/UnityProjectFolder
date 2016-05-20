using UnityEngine;
using System.Collections;

public class NPC : MonoBehaviour {

    public RaycastHit hit;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //if (Input.GetMouseButtonDown(0))
        //{

        //    Vector3 aTapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //    Collider2D aCollider2d = Physics2D.OverlapPoint(aTapPoint);

        //    if (aCollider2d)
        //    {
        //        GameObject obj = aCollider2d.transform.gameObject;
        //        Debug.Log(obj.name);
        //    }
        //}

        Vector3 mousePos = GameManager.instance.mainCamera.ScreenToWorldPoint(Input.mousePosition);


        if (Physics.Raycast(mousePos, new Vector3(0,0,1), 1000))
        {
            if(hit.collider.tag=="NPC")
            {
                Debug.Log("hit");
            }
        }
    }
}
