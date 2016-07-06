using UnityEngine;
using System.Collections;

public class AreaMoveTrigger : MonoBehaviour {

	public bool bRightSide;
	private int NextAreaID = 0;

	//==============================
	// 初期化処理
	//==============================
	void Awake()
	{

	}

	//==============================
	// 更新処理
	//==============================
	void Update()
	{

	}

	//==============================
	// 更新処理
	//==============================
	void OnTriggerExit2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "Player")
		{
			if (NextAreaID != 0)
			{
				transform.parent.GetComponentInChildren<Backdrop>().FadeOutMove(bRightSide);
				
				Debug.Log("PlayerExit-change area");

				GetComponentInParent<ExplorationView>().Scenery.GetComponent<SceneryScript>().SetNextNo(NextAreaID);
			}

		}
	}

	//==============================
	// 
	//==============================
	public void SetNextAreaID( int ID )
	{
		NextAreaID = ID;
	}
	public int GetNextAreaID()
	{
		return NextAreaID;
	}

}
