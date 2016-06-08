using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class CharacterData{
	public string name{ protected set; get; }
	public int age{ private set; get; }
	public string image3D{ protected set; get; }
	public string image2D{ protected set; get; }
	public Vector3 position{ set; get; }
	public CharacterData ( Dictionary<string, object> member ){
		this.name = member["name"].ToString( );
		//this.age = (int)member["age"];
		this.image3D = member["image3D"].ToString ( );
		this.image2D = member["image2D"].ToString( );
		position = Vector3.zero;
	}
}

/// <summary>
/// Character database.
/// キャラクタデータを管理するクラス
/// まずLoad  メソッド<see cref="Load"/>を読んでから各処理
/// </summary>
public class CharacterDatabase : MonoBehaviour {
	private static Dictionary< string, CharacterData > database;
	public static IEnumerable< KeyValuePair<string, CharacterData> > Data{ 
		private set{ } 
		get{ foreach( var keyval in database ) yield return keyval; } 
	}
	public static int Size{ protected set{} get{ return database.Count; } }

	/// <summary>
	/// ezjson ファイルからキャラクタデータを読み出す
	/// </summary>
	public static void Load( ){
		if( database != null ) return;
		database = new Dictionary< string, CharacterData >( );
		Ezjson characterData = Ezjson.Load ( Application.dataPath+"/test.ezjson" );
		foreach( var obj in characterData.objects ){
			var data = new CharacterData( obj.member );
			database.Add ( data.name, data );
		}
	}

	public static CharacterData Get( string key ){
		return database [key];
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
