using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class Character2D : MonoBehaviour {
	Image image;
	CharacterData data;
	private string charaName;
	// Use this for initialization
	void Start () {
		Load(charaName);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Load( string sName ){
		this.charaName = sName;
		data = CharacterDatabase.Get(sName);
		image = GetComponent<Image>( );
		var tex = Resources.Load ( "Images/"+ data.image2D ) as Texture2D;
		image.sprite = Sprite.Create( tex, new Rect(0,0,tex.width,tex.height), Vector2.zero );
	}
}
