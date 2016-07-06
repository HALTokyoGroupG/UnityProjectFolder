using UnityEngine;
using System;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;
using System.Collections.Generic;

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
	public int RightTrigNo = 0;
	public int LeftTrigNo = 0;
	public int RightLimit;
	public int LeftLimit;

	public GameObject[] SceneryReferenceArray;
	private ScenerySaveData[] ScenerySet;
	private List<GameObject> CurrentScenery;

	private int nNextNo = 1;
	//==============================
	// 初期化処理
	//==============================
	void Awake()
	{
		CurrentScenery = new List<GameObject>();

		////////// load the sceneries for the current part of the game //////////
		ScenerySet = new ScenerySaveData[3];
		ScenerySet[0] = new ScenerySaveData();
		ScenerySet[1] = new ScenerySaveData();
		ScenerySet[2] = new ScenerySaveData();

		LoadSceneryData("0001", 1);
		LoadSceneryData("0002", 2);

		///// create first scenery /////
		DecodeSceneryData();



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
		data.SceneryArray = ScenerySet[0].SceneryArray;
		data.LeftLimit = LeftLimit;
		data.RightLimit = RightLimit;
		data.LeftTriggerID = LeftTrigNo;
		data.RightTriggerID = RightTrigNo;

		bf.Serialize(file, data);
		file.Close();

		Debug.Log("data Saved");
	}
	//public void LoadSceneryData()
	//{
	//    string nID = SaveNo;
	//    if (File.Exists(Application.dataPath + "/sceneryData" + nID + ".dat"))
	//    {
	//        BinaryFormatter bf = new BinaryFormatter();

	//        FileStream file = File.Open(Application.dataPath + "/sceneryData" + nID + ".dat", FileMode.Open);

	//        ScenerySaveData data = (ScenerySaveData)bf.Deserialize(file);
	//        file.Close();

	//        ScenerySet[0].SceneryArray = data.SceneryArray;
	//        ScenerySet[0].LeftLimit = data.LeftLimit;
	//        ScenerySet[0].RightLimit = data.RightLimit;
	//        ScenerySet[0].LeftTriggerID = data.LeftTriggerID;
	//        ScenerySet[0].RightTriggerID = data.RightTriggerID;
	//    }


	//    //DecodeSceneryData();
	//}

	public void LoadSceneryData(string nID, int nNo)
	{
		if (File.Exists(Application.dataPath + "/sceneryData" + nID + ".dat"))
		{
			BinaryFormatter bf = new BinaryFormatter();

			FileStream file = File.Open(Application.dataPath + "/sceneryData" + nID + ".dat", FileMode.Open);

			ScenerySaveData data = (ScenerySaveData)bf.Deserialize(file);
			file.Close();

			ScenerySet[nNo].SceneryArray = data.SceneryArray;
			ScenerySet[nNo].LeftLimit = data.LeftLimit;
			ScenerySet[nNo].RightLimit = data.RightLimit;
			ScenerySet[nNo].LeftTriggerID = data.LeftTriggerID;
			ScenerySet[nNo].RightTriggerID = data.RightTriggerID;
		}

		Debug.Log("data " + nNo + " Loaded");
		//DecodeSceneryData();
	}
	//==============================
	// 
	//==============================
	//public void DecodeSceneryData(int nNo)
	//{
	//    foreach (GameObject GO in CurrentScenery)
	//    {
	//        Destroy(GO);
	//    }

	//    //transform.parent.transform.position = new Vector3(0.0f, 0.0f, 0.0f);

	//    Backdrop BDWork = GetComponentInParent<Backdrop>();
	//    BDWork.LeftTrigger.GetComponent<AreaMoveTrigger>().SetNextAreaID(ScenerySet[nNo].LeftTriggerID);
	//    BDWork.RightTrigger.GetComponent<AreaMoveTrigger>().SetNextAreaID(ScenerySet[nNo].RightTriggerID);
	//    BDWork.nLimitLeft = ScenerySet[nNo].LeftLimit;
	//    BDWork.nLimitRight = ScenerySet[nNo].RightLimit;

	//    foreach (SceneryData SD in ScenerySet[nNo].SceneryArray)
	//    {
	//        Vector3 pos = new Vector3(SD.posX, SD.posY, SD.posZ);
	//        Vector3 scl = new Vector3(SD.sclX, SD.sclY, SD.sclZ);
	//        Quaternion rot = new Quaternion(SD.rotX, SD.rotY, SD.rotZ, SD.rotW);

	//        GameObject work = Instantiate(SceneryReferenceArray[SD.nId], pos, rot) as GameObject;
	//        work.transform.localScale = scl;
	//        work.transform.SetParent(this.transform);

	//        CurrentScenery.Add(work);
	//    }
	//}
	public void DecodeSceneryData()
	{
		if (CurrentScenery.Count > 0)
		{
			foreach (GameObject GO in CurrentScenery)
			{
				Destroy(GO);
			}
		}

		transform.parent.transform.position = new Vector3(0.0f, 0.0f, 0.0f);

		Backdrop BDWork = GetComponentInParent<Backdrop>();
		BDWork.LeftTrigger.GetComponent<AreaMoveTrigger>().SetNextAreaID(ScenerySet[nNextNo].LeftTriggerID);
		BDWork.RightTrigger.GetComponent<AreaMoveTrigger>().SetNextAreaID(ScenerySet[nNextNo].RightTriggerID);
		BDWork.nLimitLeft = ScenerySet[nNextNo].LeftLimit;
		BDWork.nLimitRight = ScenerySet[nNextNo].RightLimit;

		foreach (SceneryData SD in ScenerySet[nNextNo].SceneryArray)
		{
			Vector3 pos = new Vector3(SD.posX, SD.posY, SD.posZ);
			Vector3 scl = new Vector3(SD.sclX, SD.sclY, SD.sclZ);
			Quaternion rot = new Quaternion(SD.rotX, SD.rotY, SD.rotZ, SD.rotW);

			GameObject work = Instantiate(SceneryReferenceArray[SD.nId], pos, rot) as GameObject;
			work.transform.localScale = scl;
			work.transform.SetParent(this.transform);

			CurrentScenery.Add(work);
		}
	}
	public void SetNextNo(int nNo)
	{
		nNextNo = nNo;
	}
	//==============================
	// 
	//==============================
	void EncodeSceneryData()
	{
		ScenerySet[0].SceneryArray = new SceneryData[ForSaving.Length];
		for (int i = 0; i < ForSaving.Length; i++)
		{
			ScenerySet[0].SceneryArray[i].nId = ForSaving[i].GetComponent<SceneProp>().GetID();
			ScenerySet[0].SceneryArray[i].posX = ForSaving[i].transform.position.x;
			ScenerySet[0].SceneryArray[i].posY = ForSaving[i].transform.position.y;
			ScenerySet[0].SceneryArray[i].posZ = ForSaving[i].transform.position.z;
			
			ScenerySet[0].SceneryArray[i].rotW = ForSaving[i].transform.rotation.w;
			ScenerySet[0].SceneryArray[i].rotX = ForSaving[i].transform.rotation.x;
			ScenerySet[0].SceneryArray[i].rotY = ForSaving[i].transform.rotation.y;
			ScenerySet[0].SceneryArray[i].rotZ = ForSaving[i].transform.rotation.z;
			
			ScenerySet[0].SceneryArray[i].sclX = ForSaving[i].transform.localScale.x;
			ScenerySet[0].SceneryArray[i].sclY = ForSaving[i].transform.localScale.y;
			ScenerySet[0].SceneryArray[i].sclZ = ForSaving[i].transform.localScale.z;
		}
	}
}

[Serializable]
class ScenerySaveData
{
	public SceneryData[] SceneryArray;
	public int RightTriggerID;
	public int LeftTriggerID;
	public int RightLimit;
	public int LeftLimit;

}
