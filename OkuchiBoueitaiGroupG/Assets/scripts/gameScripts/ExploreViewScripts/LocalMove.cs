using UnityEngine;
using System.Collections;

public class LocalMove : MonoBehaviour {

    public float fSpeed = 0.1f;

    private float fMovement = 0.0f;

    private bool bMovingR = false;
    private bool bMovingL = false;

    private bool bLimitR = false;
    private bool bLimitL = false;

    //==============================
    // 右移動処理
    //==============================
    public void MoveRight()
    {
        if(!bMovingL)
        {
            fMovement = -fSpeed;
            bMovingR = true;
        }
    }

    //==============================
    // 右移動処理
    //==============================
    public void MoveLeft()
    {
        if (!bMovingR)
        {
            fMovement = fSpeed;
            bMovingL = true;
        }
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
        bMovingR = false;
        bMovingL = false;
    }

}
