using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CloseButton : MonoBehaviour {

	private Button button;
	// Use this for initialization
	void Start () {
		button = GetComponent< Button > ();
		button.onClick.AddListener (() => {
			UIManager.GetInstance ().DeactivateUI (); }
		);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
