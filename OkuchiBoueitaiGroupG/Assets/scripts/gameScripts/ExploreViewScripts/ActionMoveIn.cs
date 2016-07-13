using UnityEngine;
using System.Collections;

public class ActionMoveIn : MonoBehaviour {

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
					Vector3 pos = transform.parent.transform.position;
					pos.z -= 0.5f;
					GetComponentInParent<Backdrop>().FadeOutMove(Backdrop.MVSwitch.MVIN, pos, 0.02f);
					//GetComponentInParent<ExplorationView>().Scenery.GetComponent<SceneryScript>().SetNextNo(NextAreaID);
				}
			}
		}
	}
}
