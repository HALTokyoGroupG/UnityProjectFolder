using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SysUpdate : MonoBehaviour {

    public float FadeRate = 0.1f;
    //public Image FadeFilter;
    public SpriteRenderer Fader;
    private int nLoadNo;
    private bool bFadeOut = false;
    private bool bFadeIn = false;
    private Color col = new Color(0f, 0f, 0f, 0f);

    public static SysUpdate instance = null;
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

        DontDestroyOnLoad(this);

        Application.targetFrameRate = 30;

    }

    public void FadeLoad(int scene)
    {
        bFadeOut = true;
        nLoadNo = scene;
    }

    void Update()
    {
        if( bFadeOut )
        {
            col.a += FadeRate;

            if( col.a > 1f )
            {
                bFadeOut = false;
                Application.LoadLevel(nLoadNo);
                bFadeIn = true;
            }
        }

        if( bFadeIn )
        {
            col.a -= FadeRate;

            if( col.a < 0f )
            {
                bFadeIn = false;
            }
        }

        //FadeFilter.color = col;
        Fader.color = col;
    }


}
