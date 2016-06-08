using UnityEngine;
using UnityEngine.UI;
using System.Collections;


namespace ui {


	//	UIframe
	public class UIFrame : MonoBehaviour {

		public float moveSpeed = 1.0f; 	//	UI の移動速度
		public float scalingSpeed = 20.0f;		//	UI のサイズ変更の速度
		
		//		サイズ　
		public Vector2 size;
		private Vector2 destSize;
		public Vector2 sizeOnActive = new Vector2( 100.0f, 100.0f );
		public Vector2 Size{ 
			set{ destSize = value; }
			get{ return size; } 
		}
		
		//		Position
		private Vector2 position;		//	現在の位置
		private Vector2 destination;	//	目標の位置
		public Vector2 Position {
			set{ destination = value;}	
			get{ return position;}
		}
		
		//	
		private RectTransform rectTransform;

		//	UI の名前
		[SerializeField] private Text text; 
		[SerializeField] GameObject contentName;

		void Awake( ){
			//		visible = false;
			destSize = size = Vector2.zero;
		}
		
		// Use this for initialization
		void Start () {
			rectTransform = GetComponent< RectTransform > ();
			text.text = contentName.name;
		}
		
		// Update is called once per frame
		void Update () {
			position = Vector3.Lerp (position, destination, moveSpeed*Time.deltaTime);
			size = Vector3.Lerp (size, destSize, scalingSpeed*Time.deltaTime);
			rectTransform.anchoredPosition = position;
			rectTransform.sizeDelta = size;
		}

		public void Maximize( ){
			destSize = sizeOnActive;
		}
		
		public void Minimize( ){
			destSize = Vector2.zero;
		}
	}
}

