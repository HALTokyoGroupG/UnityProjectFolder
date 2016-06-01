using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class SceneLoaderScrpt : MonoBehaviour {

    private bool loadScene = false;

    private int nScene;
    [SerializeField]
    private Text loadingText;


    //==============================
    // ロード画面の初期化処理
    //==============================
    void Start()
    {

    }

    //==============================
    // ロード画面の更新処理
    //==============================
    void Update()
    {
        if (!loadScene)
        {
            //
            loadScene = true;

            //フェード管理から次のシーン番号を受け取る
            nScene = SysUpdate.instance.GetComponent<SysUpdate>().GetNextLevel();

            // ロードアクションの初期化
            loadingText.text = "Loading...";


            StartCoroutine(LoadNewScene());
        }

        //ロード中処理
        if (loadScene)
        {

            //ロードアクションの更新
            loadingText.color = new Color(loadingText.color.r, loadingText.color.g, loadingText.color.b, Mathf.PingPong(Time.time, 1.0f));

        }
    }

    //==============================
    // 次のシーンをロード処理
    //==============================
    IEnumerator LoadNewScene()
    {

        //temporary
        //yield return new WaitForSeconds(3.0f);

        //裏で次のシーのをロードし始めてくれる呪文
        AsyncOperation async = Application.LoadLevelAsync(nScene);

        // 呪文が終わるまで続く
        while (!async.isDone)
        {
            SysUpdate.instance.GetComponent<SysUpdate>().FadeLoadIn();
            yield return null;

        }
    }

}
