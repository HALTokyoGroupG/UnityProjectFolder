using UnityEngine;
using System.Collections;

public class Action : MonoBehaviour {

    // Use this for initialization
    void Start () {
    }

    // Update is called once per frame
    void Update () {

        //　タップ処理
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();

            if (Physics.Raycast(ray, out hit))
            {
                GameObject obj = hit.collider.gameObject;

                if (obj.tag == "Action")
                {
                    //　ここに！をタップした場合の処理を追加する
                    Debug.Log("選択中");
                }
            }
        }

    }
}
