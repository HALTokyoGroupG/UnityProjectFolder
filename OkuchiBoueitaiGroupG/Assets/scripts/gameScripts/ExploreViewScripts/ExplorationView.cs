using UnityEngine;
using System.Collections;

public class ExplorationView : MonoBehaviour {

    public GameObject Backdrop;

    //==============================
    // ゲームの初期化処理
    //==============================
    void Start()
    {
        GameManager.instance.GetComponent<ModeChange>().RegisterBackdrop(Backdrop);
    }

    //==============================
    // ゲームの更新処理
    //==============================
    void Update()
    {

    }
}
