using UnityEngine;
using System.Collections;

public class LocalMove : MonoBehaviour {

    public float fSpeed = 0.1f;

    private float fMovement = 0.0f;

    private bool bLimitR = false;
    private bool bLimitL = false;

    //==============================
    // 右移動処理
    //==============================
    public void MoveRight()
    {
        fMovement = -fSpeed;
    }

    //==============================
    // 右移動処理
    //==============================
    public void MoveLeft()
    {
        fMovement = fSpeed;
    }

    //==============================
    // 右限界判定処理
    //==============================
    public bool LimitRHit()
    {
        return bLimitR;
    }

    //==============================
    // 左限界判定処理
    //==============================
    public bool LimitLHit()
    {
        return bLimitL;
    }

    //==============================
    // 移動限界設定処理
    //==============================
    public void SetLimitFlag(bool R, bool L)
    {
        bLimitR = R;
        bLimitL = L;
    }

    //==============================
    // 移動処理
    //==============================
    public float GetMovement()
    {
        return fMovement;
    }

    //==============================
    // 移動中止処理
    //==============================
    public void CancelMove()
    {
        fMovement = 0.0f;
    }

}
