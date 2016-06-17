using UnityEngine;
using System.Collections;

public class SceneProp : MonoBehaviour
{
	[SerializeField]
	private int nID;
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

	}

	public int GetID()
	{
		return nID;
	}
	public void SetID(int nId)
	{
		nID = nId;
	}
}
