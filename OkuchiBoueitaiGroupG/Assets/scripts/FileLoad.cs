using UnityEngine;
using System;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class FileLoad : MonoBehaviour
{

	private string[] ScenarioArray;

	public static FileLoad instance = null;
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
	// セーブロード処理
	//==============================
	public void Save()
	{
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Open(Application.persistentDataPath + "/ScenarioData.dat", FileMode.OpenOrCreate);

		ScenarioData data = new ScenarioData();

		TextAsset Text = Resources.Load("scenario.text") as TextAsset;

		System.StringSplitOptions option = StringSplitOptions.RemoveEmptyEntries;
		ScenarioArray = Text.text.Split(new char[]{ '\r', '\n' }, option);

		data.SetScenario(ScenarioArray);

		bf.Serialize(file, data);
		file.Close();
	}

	public void Load()
	{
		if (File.Exists(Application.persistentDataPath + "/ScenarioData.dat"))
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/SinarioData.dat", FileMode.Open);

			ScenarioData data = (ScenarioData)bf.Deserialize(file);
			file.Close();

			ScenarioArray = data.GetScenario();
		}
	}


}


[Serializable]
class ScenarioData
{
	private string[] ScenarioArray;

	public string[] GetScenario()
	{
		return ScenarioArray;
	}

	public void SetScenario(string[] Scenario)
	{
		ScenarioArray = Scenario;
	}

}