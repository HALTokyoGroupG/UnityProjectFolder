using UnityEngine;
using System.Collections;

public class LocalMove : MonoBehaviour
{

	public float fSpeed = 0.1f;
	public float fAccel = 0.1f;

	private float fMovement = 0.0f;
	private float fTargetMovement = 0.0f;

	private bool bMovingR = false;
	private bool bMovingL = false;

	private bool bLimit = false;

	//==============================
	// 更新処理
	//==============================
	void Update()
	{
		fMovement += (fTargetMovement - fMovement) * fAccel;
	}

	//==============================
	// 右移動処理
	//==============================
	public void MoveRight()
	{
		if (!bMovingL)
		{
			fTargetMovement = -fSpeed;
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
			fTargetMovement = fSpeed;
			bMovingL = true;
		}
	}

	//==============================
	// 右限界判定処理
	//==============================
	public bool LimitHit()
	{
		return bLimit;
	}


	//==============================
	// 移動限界設定処理
	//==============================
	public void SetLimitFlag(bool L)
	{
		bLimit = L;
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
		fTargetMovement = 0.0f;
		bMovingR = false;
		bMovingL = false;
	}

	//==============================
	// 移動中止処理
	//==============================
	public void StopMove()
	{
		fMovement = 0.0f;
		fTargetMovement = 0.0f;
		bMovingR = false;
		bMovingL = false;
	}

}
