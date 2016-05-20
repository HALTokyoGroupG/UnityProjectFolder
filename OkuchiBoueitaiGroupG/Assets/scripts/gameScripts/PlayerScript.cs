using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    //==============================
    // ゲームの初期化処理
    //==============================
    void Start()
    {

    }

    //==============================
    // ゲームの更新処理
    //==============================
    void Update()
    {
        Vector3 pos = transform.position;

        if (GameManager.instance.GetComponent<LocalMove>().LimitHit())
        {
            pos.x -= GameManager.instance.GetComponent<LocalMove>().GetMovement();
        }


        if (Mathf.Abs(pos.x) < 0.05f)
        {
            pos.x = 0.0f;
            GameManager.instance.GetComponent<LocalMove>().SetLimitFlag(false);
        }

        transform.position = pos;
    }
}
