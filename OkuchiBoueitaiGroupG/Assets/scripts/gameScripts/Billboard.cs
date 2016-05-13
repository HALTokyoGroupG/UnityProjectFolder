using UnityEngine;
using System.Collections;

public class Billboard : MonoBehaviour {

    private Camera m_Camera;

    //==============================
    // ゲームの初期化処理
    //==============================
    void Start()
    {
        m_Camera = GameManager.instance.mainCamera;

    }

    //==============================
    // ゲームの更新化処理
    //==============================
    void Update()
    {

        transform.LookAt(transform.position + m_Camera.transform.rotation * Vector3.forward,
            m_Camera.transform.rotation * Vector3.up);

    }
}
