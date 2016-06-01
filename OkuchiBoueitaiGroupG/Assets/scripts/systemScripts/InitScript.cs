using UnityEngine;
using System.Collections;

public class InitScript : MonoBehaviour {

    //==============================
    // 初期化処理
    //==============================
    void Start ()
    {
        //最初に出したいシーンの番号
        SysUpdate.instance.FadeLoad(2);
    }
    

}
