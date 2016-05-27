using UnityEngine;
using System.Collections;

public class HitObject : MonoBehaviour {

    static private PlayerScript player;

    //　子供(！ポリゴン)
    [SerializeField]
    private GameObject action;

    // Use this for initialization
    void Start()
    {
        //Child.SetActive(true);
        if (player == null)
            player = GameObject.Find("Player").GetComponent<PlayerScript>();

        //　最初にフォルス
        action.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       if( player == null)
        {
            Debug.Log( "null" ) ;
            return;
        }

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

    //　当たった場合
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "player")
        {
            action.SetActive(true);
            Debug.Log("hit Object");
        }
    }

    //　当たっている状態から当たっていない状態になった場合
    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "player")
        {
            action.SetActive(false);
            Debug.Log("Hit Exit Object");
        }
    }
}
