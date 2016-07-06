using UnityEngine;
using System.Collections;

public class Character3D : MonoBehaviour {
	[SerializeField]
	string charaName;
	CharacterData data;
	TextMesh text;
	void Awake( ){
		CharacterDatabase.Load ( );
	}
	// Use this for initialization
	void Start () {
		data = CharacterDatabase.Get(charaName);
		text = transform.GetChild (0).gameObject.GetComponent< TextMesh >( );
		text.text = data.image3D.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
		if( data != null )
			transform.position = data.position;
	}
}
