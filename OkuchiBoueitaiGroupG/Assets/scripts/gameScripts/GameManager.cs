using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    //public GameObject PauseMenu;
    //public GameObject PauseButton;
    private bool bPause = false;

    public Camera mainCamera;
    public AudioClip[] BGMs;

    public static GameManager instance = null;
    [HideInInspector]

    //==============================
    // 初期化処理
    //==============================
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    //==============================
    // ゲームの初期化処理
    //==============================
    void Start()
    {
        //int nStage = DataStore.instance.GetStage();

        //SoundManager.instance.PlayTrack(BGMs[Random.Range(0,BGMs.Length)]);


    }

    //==============================
    // ゲームの更新処理
    //==============================
    void Update()
    {
        if( bPause )
        {
            return;
        }

    }

    //==============================
    // ゲームオーバー確認処理
    //==============================
    void CheckGameOver()
    {
        
    }


    ////==============================
    //// オブジェクトをリストに追加処理
    ////==============================
    //public void PlayEffect(int ID, Vector3 pos)
    //{
    //    EffectList[ID].GetComponent<ParticleSystem>().Play();
    //    EffectList[ID].transform.position = pos;
    //}

    //==============================
    // ポーズ処理
    //==============================
    //public void Pause()
    //{
    //    bPause = !bPause;

    //    if( bPause )
    //    {
    //        Time.timeScale = 0f;
    //        PauseMenu.SetActive(true);
    //        PauseButton.GetComponent<Button>().enabled = false;
    //    }
    //    else
    //    {
    //        Time.timeScale = 1f;
    //        PauseMenu.SetActive(false);
    //        PauseButton.GetComponent<Button>().enabled = true;
    //    }
    //}

    //public bool Paused()
    //{
    //    return bPause;
    //}

}
