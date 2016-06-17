using UnityEngine;
using System;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class DataStore : MonoBehaviour
{


	private int nStage = 1;
	private int nScore = 0;
	private bool bStageClear = false;
	private int[] nRankingArray;

	public static DataStore instance = null;
	[HideInInspector]

	//==============================
	// 初期化処理
	//==============================
	void OnEnable()
	{

	}

	//==============================
	// 初期化処理
	//==============================
	void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else if (instance != this)
		{
			Destroy(gameObject);
		}

		DontDestroyOnLoad(this);
	}

	//==============================
	// スコアゲットセット処理
	//==============================
	public void SetScore(int score)
	{
		nScore = score;
	}
	public int GetScore()
	{
		return nScore;
	}

	//==============================
	// ステージゲットセット処理
	//==============================
	public void SetStage(int stage)
	{
		nStage = stage;
	}
	public int GetStage()
	{
		return nStage;
	}

	//==============================
	// ステージクリアゲットセット処理
	//==============================
	public void SetStageClear(bool clear)
	{
		bStageClear = clear;
	}
	public bool GetStageClear()
	{
		return bStageClear;
	}

	//==============================
	// ステージゲットセット処理
	//==============================
	public void SetRanking(int[] ranking)
	{
		nRankingArray = ranking;
	}
	public int[] GetRanking()
	{
		return nRankingArray;
	}

	//==============================
	// セーブロード処理
	//==============================
	public void Save()
	{
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Open(Application.persistentDataPath + "/saveData.dat", FileMode.OpenOrCreate);

		SaveData data = new SaveData();
		data.SetRanking(nRankingArray);

		bf.Serialize(file, data);
		file.Close();
	}
	public void Load()
	{
		if (File.Exists(Application.persistentDataPath + "/saveData.dat"))
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/saveData.dat", FileMode.Open);

			SaveData data = (SaveData)bf.Deserialize(file);
			file.Close();

			nRankingArray = data.GetRanking();
		}
		else
		{
			nRankingArray = new int[3];
			nRankingArray[0] = 300;
			nRankingArray[1] = 200;
			nRankingArray[2] = 100;
		}

	}
}


[Serializable]
class SaveData
{
	private int[] nRankingArray;

	public void SetRanking(int[] ranking)
	{
		nRankingArray = ranking;
	}
	public int[] GetRanking()
	{
		return nRankingArray;
	}

}