using UnityEngine;
using System.Collections;

public class ExplorationView : MonoBehaviour
{
	public GameObject Scenery;
	public GameObject Props;
	public GameObject Player;

	//==============================
	// 初期化処理
	//==============================
	void Start()
	{
		//GameManager.instance.GetComponent<ModeChange>().RegisterBackdrop(Backdrop);
	}

	//==============================
	// 更新処理
	//==============================
	void Update()
	{

	}

	//==============================
	// 
	//==============================
	public void ActivateAll(bool bActive)
	{
		Scenery.SetActive(bActive);
		Props.SetActive(bActive);
		Player.SetActive(bActive);
	}

	//==============================
	// 
	//==============================
	public void ShowProps(bool bActive)
	{
		Props.SetActive(bActive);
		Player.SetActive(bActive);
	}
}
