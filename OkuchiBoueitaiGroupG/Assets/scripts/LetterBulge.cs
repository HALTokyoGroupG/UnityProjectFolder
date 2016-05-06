using UnityEngine;
using System.Collections;

public class LetterBulge : MonoBehaviour {

    public float fBulgeScale = 0.03f;
    public float fBulgeRate = 0.05f;

    private float fScale;
    private float fTheta;
    //==============================
    // 初期化処理
    //==============================
    void Start()
    {
        fScale = transform.localScale.y;
    }

    //==============================
    // 更新処理
    //==============================
    void Update()
    {
        float fWork = fScale + (Mathf.Sin(fTheta) * fBulgeScale);
        transform.localScale = new Vector3(fWork, fWork, 1f);
        fTheta += fBulgeRate;
        if( fTheta > Mathf.PI*2 )
        {
            fTheta = 0;
        }
    }
}
