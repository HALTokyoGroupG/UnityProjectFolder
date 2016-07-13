using UnityEngine;
using System.Collections;

public class AreaMoveTrigger : MonoBehaviour {

	public bool bRightSide;
	private int NextAreaID = 0;
	private bool bJunction = false;
	private float posXJunction = 0;

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
	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "Player")
		{
			if (NextAreaID != 0)
			{
				if(bJunction)
				{
					transform.parent.GetComponentInChildren<Backdrop>().FadeOutMove(Backdrop.MVSwitch.MVDOWN, new Vector3(posXJunction, 0.0f, 0.0f));
				}
				else
				{
					if (bRightSide)
					{
						transform.parent.GetComponentInChildren<Backdrop>().FadeOutMove(Backdrop.MVSwitch.MVRIGHT, Vector3.zero);
					}
					else
					{
						transform.parent.GetComponentInChildren<Backdrop>().FadeOutMove(Backdrop.MVSwitch.MVLEFT, Vector3.zero);
					}
				}


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

	//==============================
	// 
	//==============================
	public void SetNextAreaJunction(bool bJunc, float posX)
	{
		bJunction = bJunc;
		posXJunction = posX;
	}
	//public bool GetbJunction()
	//{
	//    return bJunction;
	//}
	//public int GetJunctionPosX()
	//{
	//    return posXJunction;
	//}
}
