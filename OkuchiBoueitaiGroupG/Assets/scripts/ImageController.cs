using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ImageController : MonoBehaviour
{
	//キャラ画像ポインタ
	public Image[] CharactorImage_;
	//キャラ画像位置保存
	private Vector3[] CharactorPosition_;

	private bool ShakeFlag_ = false;
	public int ShakeCount;
	private int ShakeNum_ = 0;
	public int Shake_;
	private int Direction_ = 1;

	private bool FadeFlag_ = false;

	// Use this for initialization
	void Start()
	{

		CharactorPosition_ = new Vector3[4];

		//キャラクター画像位置保存
		for (int Loop = 0; Loop < 4; Loop++)
			CharactorPosition_[Loop] = CharactorImage_[Loop].transform.position;

		CharactorImage_[1].enabled = false;
		CharactorImage_[2].enabled = false;
	}

	// Update is called once per frame
	void Update()
	{
		//仮実装震え
		if (Input.GetMouseButtonDown(0))
		{
			ShakeFlag_ = true;
		}

		//震え実装		ここから
		if (ShakeFlag_ && ShakeNum_ < ShakeCount)
		{
			ShakeNum_++;
			CharaShake(0);
		}
		else if (ShakeFlag_ && ShakeNum_ >= ShakeCount)
		{
			ShakeNum_ = 0;
			ShakeFlag_ = false;
			for (int Loop = 0; Loop < 4; Loop++)
				CharactorImage_[Loop].rectTransform.position = CharactorPosition_[Loop];
		}
		//震え実装		ここまで
	}

	//キャラクター震え
	public void CharaShake(int _CharaNumber)
	{
		CharactorImage_[_CharaNumber].rectTransform.position = new Vector3(CharactorPosition_[_CharaNumber].x + Mathf.PingPong(ShakeNum_ * Shake_ / 2, Shake_) - Shake_ * 0.5f,
																		CharactorPosition_[_CharaNumber].y,
																		CharactorPosition_[_CharaNumber].z);
	}

	//キャラクター回転
	public void RollCharactor(int _CharactorNumber)
	{
		Vector3 Scale = CharactorImage_[_CharactorNumber].transform.localScale;
		Scale.x *= -1;
		CharactorImage_[_CharactorNumber].transform.localScale = Scale;
	}

	public void CharactorEnable(int _CharactorNumber, bool _Flag)
	{
		CharactorImage_[_CharactorNumber].enabled = _Flag;
	}

	public void ImageIn(int _CharactorNumber)
	{

	}
}
