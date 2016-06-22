using UnityEngine;
using System.Collections;

public class AreaMoveTrigger : MonoBehaviour {

	private string NextAreaID;

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

	//==============================
	// 更新処理
	//==============================
	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "Player")
		{
			Debug.Log("PlayerEnter");
			GetComponentInParent<ExplorationView>().Scenery.GetComponent<SceneryScript>().LoadSceneryData(NextAreaID);
		}
	}

	//==============================
	// 更新処理
	//==============================
	public void SetNextAreaID( string ID )
	{
		NextAreaID = ID;
	}

}
