using UnityEngine;
using System.Collections;

public class ModeChange : MonoBehaviour {

    enum VIEWMODE
    {
        UNKNOWN = 0,
        EXPLORE,
        CONVERSE,
        MAX
    };

    public GameObject ExploreUI;
    public GameObject ExplorationView;
    private GameObject Backdrop;
    public GameObject ConversationView;

    private int nCurMode = (int)VIEWMODE.UNKNOWN;
    private int nNextMode = (int)VIEWMODE.UNKNOWN;

    public float FadeRate = 0.1f;
    public SpriteRenderer Fader;
    private bool bFadeOut = false;
    private bool bFadeIn = false;
    private Color col = new Color(0f, 0f, 0f, 0f);

    //==============================
    // ゲームの初期化処理
    //==============================
    void Awake()
    {

    }

    //==============================
    // ゲームの更新処理
    //==============================
    void Update()
    {

        if (bFadeOut)
        {
            col.a += FadeRate;

            if (col.a > 1f)
            {
                bFadeOut = false;
                ChangeMode();
                bFadeIn = true;
            }
        }

        if (bFadeIn)
        {
            col.a -= FadeRate;

            if (col.a < 0f)
            {
                bFadeIn = false;
            }
        }

        Fader.color = col;

        if (nCurMode != nNextMode)
        {

        }
    }

    //==============================
    // ゲームの更新処理
    //==============================
    void ChangeMode()
    {
        switch (nNextMode)
        {
            case (int)VIEWMODE.EXPLORE:

                ExploreUI.SetActive(true);
                ExplorationView.SetActive(true);
                Backdrop.SetActive(true);

                ConversationView.SetActive(false);
                break;

            case (int)VIEWMODE.CONVERSE:

                ExploreUI.SetActive(false);
                ExplorationView.SetActive(false);
                Backdrop.SetActive(false);

                ConversationView.SetActive(true);
                break;
        }
        nCurMode = nNextMode;
    }
    //==============================
    // モード切り替え処理
    //==============================
    public void ChangeTo(int nNo)
    {
        nNextMode = nNo;
        bFadeOut = true;
    }

    //==============================
    // backdrop登録処理
    //==============================
    public void RegisterBackdrop(GameObject backdrop)
    {
        Backdrop = backdrop;
    }


}
