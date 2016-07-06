using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Character3D : MonoBehaviour {
	private CharacterData data;
	public CharacterData Data{ 
		set{
			data = value;
			var tex = Resources.Load ( data.image3D ) as Texture2D;
			spriteRenderer.sprite = Sprite.Create( tex, new Rect(0,0,tex.width,tex.height), Vector2.zero );
		}
		get{ return data; }
	}


	SpriteRenderer spriteRenderer;

	void Awake( ){
		spriteRenderer = GetComponent< SpriteRenderer >( );
		CharacterDatabase.Load ( );
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}
}
