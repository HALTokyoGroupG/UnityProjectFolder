using UnityEngine;
using System;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;

[Serializable] 
struct SceneryData
{
	public int nId;
	public float posX;
	public float posY;
	public float posZ;
	public float sclX;
	public float sclY;
	public float sclZ;
	public float rotW;
	public float rotX;
	public float rotY;
	public float rotZ;
};

public class SceneryScript : MonoBehaviour {

	//temporary
	public GameObject[] ForSaving;
	public string SaveNo = "0000";
	public string RightTrigNo = "0000";
	public string LeftTrigNo = "0000";
	public int RightLimit;
	public int LeftLimit;

	public GameObject[] SceneryReferenceArray;
	private SceneryData[] ScenerySet;

	//==============================
	// 初期化処理
	//==============================
	void Awake()
	{

	}

	//==============================
	// セーブロード処理
	//==============================
	public void SaveSceneryData()
	{
		string nID = SaveNo;
		EncodeSceneryData();

		BinaryFormatter bf = new BinaryFormatter();

		FileStream file = File.Open(Application.dataPath+"/sceneryData" + nID + ".dat", FileMode.OpenOrCreate);

		ScenerySaveData data = new ScenerySaveData();
		data.SetArray(ScenerySet);
		data.LeftLimit = LeftLimit;
		data.RightLimit = RightLimit;
		data.LeftTriggerID = LeftTrigNo;
		data.RightTriggerID = RightTrigNo;

		bf.Serialize(file, data);
		file.Close();
	}
	public void LoadSceneryData()
	{
		string nID = SaveNo;
		if (File.Exists(Application.dataPath + "/sceneryData" + nID + ".dat"))
		{
			BinaryFormatter bf = new BinaryFormatter();

			FileStream file = File.Open(Application.dataPath + "/sceneryData" + nID + ".dat", FileMode.Open);

			ScenerySaveData data = (ScenerySaveData)bf.Deserialize(file);
			file.Close();

			ScenerySet = data.GetArray();
			LeftLimit = data.LeftLimit;
			RightLimit = data.RightLimit;
			LeftTrigNo = data.LeftTriggerID;
			RightTrigNo = data.RightTriggerID;
		}

		DecodeSceneryData();
	}

	public void LoadSceneryData(string nID)
	{
		if (File.Exists(Application.dataPath + "/sceneryData" + nID + ".dat"))
		{
			BinaryFormatter bf = new BinaryFormatter();

			FileStream file = File.Open(Application.dataPath + "/sceneryData" + nID + ".dat", FileMode.Open);

			ScenerySaveData data = (ScenerySaveData)bf.Deserialize(file);
			file.Close();

			ScenerySet = data.GetArray();
			LeftLimit = data.LeftLimit;
			RightLimit = data.RightLimit;
			LeftTrigNo = data.LeftTriggerID;
			RightTrigNo = data.RightTriggerID;
		}

		DecodeSceneryData();
	}
	//==============================
	// 
	//==============================
	void DecodeSceneryData()
	{
		Backdrop BDWork = GetComponentInParent<Backdrop>();
		BDWork.LeftTrigger.GetComponent<AreaMoveTrigger>().SetNextAreaID(LeftTrigNo);
		BDWork.RightTrigger.GetComponent<AreaMoveTrigger>().SetNextAreaID(RightTrigNo);
		BDWork.nLimitLeft = LeftLimit;
		BDWork.nLimitRight = RightLimit;

		foreach (SceneryData SD in ScenerySet)
		{
			Vector3 pos = new Vector3(SD.posX, SD.posY, SD.posZ);
			Vector3 scl = new Vector3(SD.sclX, SD.sclY, SD.sclZ);
			Quaternion rot = new Quaternion(SD.rotX, SD.rotY, SD.rotZ, SD.rotW);

			GameObject work = Instantiate(SceneryReferenceArray[SD.nId], pos, rot) as GameObject;
			work.transform.localScale = scl;
			work.transform.SetParent(this.transform);
		}
	}
	void EncodeSceneryData()
	{
		ScenerySet = new SceneryData[ForSaving.Length];
		for (int i = 0; i < ForSaving.Length; i++ )
		{
			ScenerySet[i].nId = ForSaving[i].GetComponent<SceneProp>().GetID();
			ScenerySet[i].posX = ForSaving[i].transform.position.x;
			ScenerySet[i].posY = ForSaving[i].transform.position.y;
			ScenerySet[i].posZ = ForSaving[i].transform.position.z;

			ScenerySet[i].rotW = ForSaving[i].transform.rotation.w;
			ScenerySet[i].rotX = ForSaving[i].transform.rotation.x;
			ScenerySet[i].rotY = ForSaving[i].transform.rotation.y;
			ScenerySet[i].rotZ = ForSaving[i].transform.rotation.z;

			ScenerySet[i].sclX = ForSaving[i].transform.localScale.x;
			ScenerySet[i].sclY = ForSaving[i].transform.localScale.y;
			ScenerySet[i].sclZ = ForSaving[i].transform.localScale.z;
		}
	}
}

[Serializable]
class ScenerySaveData
{
	private SceneryData[] SceneryArray;
	public string RightTriggerID;
	public string LeftTriggerID;
	public int RightLimit;
	public int LeftLimit;

	public void SetArray(SceneryData[] scenery)
	{
		SceneryArray = scenery;
	}
	public SceneryData[] GetArray()
	{
		return SceneryArray;
	}

}
