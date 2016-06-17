using UnityEngine;
using System.Collections;

public class OnClick : MonoBehaviour
{

	public AudioClip sfx;

	//==============================
	// クリックでシーン読み込み処理
	//==============================
	public void LoadScene(int level)
	{
		//SoundManager.instance.PlaySingle(sfx);
		SysUpdate.instance.FadeLoad(level);
	}

	//==============================
	// クリックでシーン読み込み処理
	//==============================
	//public void LoadStage(int stage)
	//{
	//    DataStore.instance.SetStage(stage);
	//    SysUpdate.instance.FadeLoad(1);
	//}
}
