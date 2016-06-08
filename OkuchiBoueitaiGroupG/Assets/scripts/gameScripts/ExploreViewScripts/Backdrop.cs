using UnityEngine;
using System.Collections;

public class Backdrop : MonoBehaviour
{

	public int nLimitRight = 5;
	public int nLimitLeft = -5;

	//==============================
	// ゲームの初期化処理
	//==============================
	void Start()
	{

	}

	//==============================
	// ゲームの更新処理
	//==============================
	void Update()
	{
		Vector3 pos = transform.position;

		if (!GameManager.instance.GetComponent<LocalMove>().LimitHit())
		{
			pos.x += GameManager.instance.GetComponent<LocalMove>().GetMovement();
		}

		if (-pos.x > nLimitRight)
		{
			GameManager.instance.GetComponent<LocalMove>().SetLimitFlag(true);
			pos.x = -nLimitRight;
		}
		if (-pos.x < nLimitLeft)
		{
			GameManager.instance.GetComponent<LocalMove>().SetLimitFlag(true);
			pos.x = -nLimitLeft;
		}

		transform.position = pos;
	}
}
