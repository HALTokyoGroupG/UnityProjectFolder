using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class Character2D : MonoBehaviour {
	Image image;
	CharacterData data;
	private string name;
	// Use this for initialization
	void Start () {
		Load ( name );
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Load( string name ){
		this.name = name;
		data = CharacterDatabase.Get ( name );
		image = GetComponent<Image>( );
		var tex = Resources.Load ( "Images/"+ data.image2D ) as Texture2D;
		image.sprite = Sprite.Create( tex, new Rect(0,0,tex.width,tex.height), Vector2.zero );
	}
}
