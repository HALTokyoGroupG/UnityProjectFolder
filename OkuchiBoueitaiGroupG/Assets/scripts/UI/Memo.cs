using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace ui{

	public class Memo : UIContent {
		int currentPage;
		ArrayList characterNameList;

		[SerializeField] Character2D character;
		[SerializeField]Text charaName;

		// Use this for initialization
		void Start () {
			currentPage = 0;
			characterNameList = new ArrayList( CharacterDatabase.Size );
			foreach( var val in CharacterDatabase.Data )
				characterNameList.Add ( val.Key );
			character.Load ( characterNameList[0].ToString () );
			charaName.text = characterNameList[0].ToString();
		}
		
		// Update is called once per frame
		void Update () {
		
		}

		/// <summary>
		/// ページ切り替え
		/// </summary>
		/// <param name="page">表示するページ</param>
		public void LoadPage( int page ){
			if( page >= characterNameList.Count || page < 0 ) return;
			currentPage = page;
			character.Load ( characterNameList[page].ToString () );
			charaName.text = characterNameList[page].ToString();
		}

		public void TurnPage( ){
			LoadPage ( currentPage + 1 );
		}
		public void PageBack( ){
			LoadPage ( currentPage - 1 );
		}
	}
}
