using UnityEngine;
using System.Collections;

public class ActionMoveUp : MonoBehaviour {

	//temporary use
	[SerializeField]
	private int NextAreaID = 0;
	[SerializeField]
	private float posX = 0.0f;

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
					pos.x -= posX;
					GetComponentInParent<Backdrop>().FadeOutMove(Backdrop.MVSwitch.MVUP, pos, 0.05f);
					GetComponentInParent<ExplorationView>().Scenery.GetComponent<SceneryScript>().SetNextNo(NextAreaID);
					//GameManager.instance.GetComponent<ModeChange>().ChangeTo(4);
				}
			}
		}
	}
}
