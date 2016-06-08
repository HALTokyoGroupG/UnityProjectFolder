using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ui;

namespace ui{
	public enum TYPE : int
	{
		SAMPLE00 = 0,
		SAMPLE01 = 1,
	}
}


public class UIManager : MonoBehaviour {

	[SerializeField] private GameObject backScreen;
	[SerializeField] private List< UI > uiList;
	private UI currentActive = null;

	//	forbid instantiate
	private UIManager( ){ }

	//	instance
	private static UIManager instance;

	//		インスタンスへのアクセス
	public static UIManager GetInstance( ){
		return instance;
	}

	void Awake( ){
		instance = this;
	}
	// Use this for initialization
	void Start () {
		uiList = new List< UI > (transform.childCount);
		Transform t = GameObject.Find ("UIs").transform;
		for (int i=0; i<t.transform.childCount; ++i) {
			uiList.Add ( t.transform.GetChild(i).gameObject.GetComponent< UI >() );
		}
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	public void ActivateUI( TYPE which ){
		if ((int)which > uiList.Count || uiList[(int)which] == currentActive )
			return;

		backScreen.SetActive (true);

		if (currentActive != null) {
			currentActive.Deactivate ();
		}
		currentActive = uiList[(int)which];
		currentActive.Activate ();
	}

	public void DeactivateUI( ){
		if( currentActive != null ){
			currentActive.Deactivate ( );
			currentActive = null;
		}
		backScreen.SetActive (false);
	}
}

