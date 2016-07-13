using UnityEngine;
using System.Collections;

public class ActionCheck : MonoBehaviour {


	//temporary use
	[Multiline]
	public string[] str;
	public Sprite sprite;

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

				//if (obj.tag == "Action")
				if (obj == this.gameObject) //このゲームオブジェクトだけに反応する
				{
					//ここに！をタップした場合の処理を追加する
					GameManager.instance.GetComponent<ModeChange>().ChangeTo((int)ModeChange.VIEWMODE.CHECK);
					GameManager.instance.GetComponent<GameManager>().StoreString(str);
					GameManager.instance.GetComponent<GameManager>().StoreSprite(sprite);
				}
			}
		}
	}
}
