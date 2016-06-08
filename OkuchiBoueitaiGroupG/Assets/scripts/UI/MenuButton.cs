using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace ui{
	public class MenuButton : MonoBehaviour {
		private Button button;
		[SerializeField] private TYPE callType = TYPE.SAMPLE00;
		// Use this for initialization
		void Start () {
			button = GetComponent< Button > ();
			button.onClick.AddListener( ()=>{UIManager.GetInstance ().ActivateUI (callType); } );
		}
		
		// Update is called once per frame
		void Update () {
			
		}
	}
}