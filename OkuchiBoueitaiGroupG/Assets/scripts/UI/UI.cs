using UnityEngine;
using System.Collections;

namespace ui {

	public class UI : MonoBehaviour {

		[SerializeField] private ui.UIFrame frame;				//	フレーム	
		[SerializeField] private GameObject content;		//	コンテンツ

		private bool visible = false;						//	可視状態
		public bool Visible{ get{ return visible; } private set{ visible = value; } }

		// Use this for initialization
		void Start () {
			content.transform.parent = frame.gameObject.transform;
		}
		
		// Update is called once per frame
		void Update () {
		
		}

		public void Activate( ){
			frame.Maximize ();
		}
		public void Deactivate( ){
			frame.Minimize ();
		}
	}

}
