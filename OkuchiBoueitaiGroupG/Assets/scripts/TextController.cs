/**************************************************************************************************************/
/*TextController*/
/*Auther:NaraYuuki*/
/**************************************************************************************************************/

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
	//シナリオ		これをファイルから読み込めるようにする
	public string[] Scenarios;

	//テキストボックスのポインタ
	[SerializeField]
	Text UiText;

	//文字表示の速度
	[SerializeField]
	[Range(0.001f, 0.3f)]
	float IntervalForCharacterDisplay = 0.05f;


	//現在の文字列
	private string CurrentText = string.Empty;

	//表示にかかる時間
	private float TimeUntilDisplay = 0;

	//文字列の表示開始時間
	private float TimeElapsed = 1;

	//現在の行番号
	private int CurrentLine = 0;

	//表示中の文字数
	private int LastUpdateCharacter = -1;

	//クリックしてねっていう三角の点滅用フラグ
	private bool NextFlag = false;

	//クリックしてねって言う三角の点滅用時間
	private float FlashTime = 0;

	public Button Menu;

	// 文字の表示が完了しているかどうか
	public bool IsCompleteDisplayText
	{
		get { return Time.time > TimeElapsed + TimeUntilDisplay; }
	}

	//文字表示速度変更
	public float TextSpeed
	{
		set { IntervalForCharacterDisplay = value * 0.01f; }
	}

	void Start()
	{
	}

	void OnEnable()
	{
		SetNextLine();
	}

	void OnDisable()
	{
		Clear();
	}

	void Update()
	{
		// 文字の表示が完了してるならクリック時に次の行を表示する
		if (IsCompleteDisplayText)
		{
			//クリックされてから一定時間立ったら
			if ((int)Mathf.Clamp01((Time.time - FlashTime)) > Time.deltaTime * 0.5f)
			{
				FlashTime = Time.time;

				NextFlag = !NextFlag;

				if (NextFlag)
				{
					UiText.text = Scenarios[CurrentLine - 1];
				}
				else
				{
					UiText.text = Scenarios[CurrentLine - 1] + "▼";
				}
			}

			if (CurrentLine < Scenarios.Length && Input.GetMouseButtonUp(0))
			{
				SetNextLine();
			}
		}
		else
		{
			//完了してないなら文字をすべて表示する
			if (Input.GetMouseButtonUp(0))
			{
				TimeUntilDisplay = 0;
			}
		}

		//クリックから経過した時間が想定表示時間の何%か確認し、表示文字数を出す
		int displayCharacterCount = (int)(Mathf.Clamp01((Time.time - TimeElapsed) / TimeUntilDisplay) * CurrentText.Length);

		//表示文字数が前回の表示文字数と異なるならテキストを表示する
		if (displayCharacterCount != LastUpdateCharacter)
		{
			//文字更新
			UiText.text = CurrentText.Substring(0, displayCharacterCount);

			//表示文字数更新
			LastUpdateCharacter = displayCharacterCount;
		}
	}


	public void SetNextLine()
	{
		CurrentText = Scenarios[CurrentLine];

		//想定表示時間と現在の時刻をキャッシュ
		TimeUntilDisplay = CurrentText.Length * IntervalForCharacterDisplay;
		TimeElapsed = Time.time;
		CurrentLine++;

		//文字カウントを初期化
		LastUpdateCharacter = -1;
	}


	//初期化
	void Clear()
	{
		CurrentText = string.Empty;
		CurrentLine = 0;

		TimeElapsed = 0;
		LastUpdateCharacter = -1;

		NextFlag = false;
		FlashTime = 0;

	}

	public void SetScenario(params string[] Scenario)
	{
		Scenarios = Scenario;
	}
}