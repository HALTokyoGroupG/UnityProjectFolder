using UnityEngine;
using System.Collections;

public class ActionMove : MonoBehaviour {

	//temporary use
	[SerializeField]
	private int NextAreaID = 0;

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
		// タップ処理
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit = new RaycastHit();

			if (Physics.Raycast(ray, out hit))
			{
				GameObject obj = hit.collider.gameObject;

				if (obj == this.gameObject) //このゲームオブジェクトだけに反応する
				{
					//ここに！をタップした場合の処理を追加する
					GetComponentInParent<Backdrop>().FadeOutMove(Backdrop.MVSwitch.MVIN, transform.parent.transform.parent.position);
				}
			}
		}
	}
}
