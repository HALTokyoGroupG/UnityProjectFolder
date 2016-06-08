using UnityEngine;
using System.Collections;

public class HitObject : MonoBehaviour
{

	//　子供(！ポリゴン)
	[SerializeField]
	private GameObject action;

	// Use this for initialization
	void Start()
	{

		//　最初にフォルス
		action.SetActive(false);
	}

	// Update is called once per frame
	void Update()
	{


	}

	//　当たった場合
	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "Player")
		{
			action.SetActive(true);
		}
	}

	//　当たっている状態から当たっていない状態になった場合
	void OnTriggerExit2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "Player")
		{
			action.SetActive(false);
		}
	}
}
