using UnityEngine;
using System.Collections;

public class CameraAspect : MonoBehaviour {

    public float width = 16f;
    public float height = 10f;

    //==============================
    // 初期化処理
    //==============================
    void Start()
    {
        //プロジェクトの画面の比率
        float targetaspect = width / height;

        //ウィンドウ画面の比率を確認
        float windowaspect = (float)Screen.width / (float)Screen.height;

        //ビューポートの高さ拡大の計算
        float scaleheight = windowaspect / targetaspect;

        Camera camera = GetComponent<Camera>();

        // 比率によって枠を付ける
        //高さ足りない場合
        if (scaleheight < 1f)
        {
            Rect rect = camera.rect;

            rect.width = 1f;
            rect.height = scaleheight;
            rect.x = 0f;
            rect.y = (1f - scaleheight) / 2f;

            camera.rect = rect;
        }
        //幅が足りない場合
        else
        {
            float scalewidth = 1f / scaleheight;

            Rect rect = camera.rect;

            rect.width = scalewidth;
            rect.height = 1f;
            rect.x = (1f - scalewidth) / 2f;
            rect.y = 0f;

            camera.rect = rect;
        }
    }
}
