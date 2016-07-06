using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class CharacterDesc{
	public int age{ private set; get; }
};

public class CharacterData{
	public int ID{ protected set; get; }
	public string name{ protected set; get; }
	public string image3D{ protected set; get; }
	public string image2D{ protected set; get; }
	public CharacterDesc Parameter{ private set; get; }
	public Vector3 position{ set; get; }
	public CharacterData ( Dictionary<string, object> member ){
		this.ID = (int) member["ID"];
		this.name = member["name"].ToString( );
		this.image3D = member["imageExplore"].ToString ( );
		this.image2D = member["imageEvent"].ToString( );
		position = Vector3.zero;
	}
}

/// <summary>
/// Character database.
/// キャラクタデータを管理するクラス
/// まずLoad  メソッド<see cref="Load"/>を読んでから各処理
/// </summary>
public class CharacterDatabase : MonoBehaviour {
	private static Dictionary< string, CharacterData > dictionaryByName;
	private static Dictionary< int, CharacterData > dictionaryByID;
	public static IEnumerable< KeyValuePair<string, CharacterData> > Data{ 
		private set{ } 
		get{ foreach( var keyval in dictionaryByName ) yield return keyval; } 
	}
	public static int Size{ protected set{} get{ return dictionaryByName.Count; } }
	
	/// <summary>
	/// ezjson ファイルからキャラクタデータを読み出す
	/// </summary>
	public static void Load( ){
		if( dictionaryByName != null ) return;
		if( dictionaryByID != null ) return;
		dictionaryByName = new Dictionary< string, CharacterData >( );
		dictionaryByID = new Dictionary< int, CharacterData >( );

		Ezjson characterData = Ezjson.Load ( Application.dataPath+"/kataokaBackup/test.ezjson" );
		foreach( var obj in characterData.objects ){
			var data = new CharacterData( obj.member );
			dictionaryByName.Add ( data.name, data );
			dictionaryByID.Add ( data.ID, data );
		}
	}

	public static CharacterData Get( string key ){
		return dictionaryByName [key];
	}

	public static CharacterData Get( int key ){
		return dictionaryByID[key];
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
