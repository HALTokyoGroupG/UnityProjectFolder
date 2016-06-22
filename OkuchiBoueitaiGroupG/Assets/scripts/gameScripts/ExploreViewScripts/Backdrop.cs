using UnityEngine;
using System;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

//[Serializable]
//struct BackDropData
//{
//    string SceneryID;

//};

public class Backdrop : MonoBehaviour
{
	public int nLimitRight = 5;
	public int nLimitLeft = -5;

	public GameObject RightTrigger;
	public GameObject LeftTrigger;

	//==============================
	// 初期化処理
	//==============================
	void Start()
	{

	}

	//==============================
	// 更新処理
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

//[Serializable]
//class BackDropSaveData
//{
//    private BackDropData BackDrop;

//    public void SetArray(BackDropData backdrop)
//    {
//        BackDrop = backdrop;
//    }
//    public BackDropData GetArray()
//    {
//        return BackDrop;
//    }

//}