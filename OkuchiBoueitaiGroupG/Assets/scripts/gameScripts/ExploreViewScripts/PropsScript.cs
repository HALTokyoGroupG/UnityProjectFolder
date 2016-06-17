using UnityEngine;
using System;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

[Serializable]
struct PropsData
{
	public int nId;
	public float posX;
	public float posY;
	public float posZ;
	//public float sclX;//consider redundant
	//public float sclY;
	//public float sclZ;
	//public float rotW;
	//public float rotX;
	//public float rotY;
	//public float rotZ;//
};

public class PropsScript : MonoBehaviour {

	//temporary
	public GameObject[] ForSaving;

	public GameObject[] PropsReferenceArray;
	private PropsData[] PropsSet;

	//==============================
	// 初期化処理
	//==============================
	void Awake()
	{

	}

	//==============================
	// セーブロード処理
	//==============================
	public void SavePropsData(int nID)
	{
		EncodePropsData();

		BinaryFormatter bf = new BinaryFormatter();

		FileStream file = File.Open(Application.dataPath + "/propsData" + nID + ".dat", FileMode.OpenOrCreate);

		PropsSaveData data = new PropsSaveData();
		data.SetArray(PropsSet);

		bf.Serialize(file, data);
		file.Close();
	}
	public void LoadPropsData(int nID)
	{

		if (File.Exists(Application.dataPath + "/propsData" + nID + ".dat"))
		{
			BinaryFormatter bf = new BinaryFormatter();

			FileStream file = File.Open(Application.dataPath + "/propsData" + nID + ".dat", FileMode.Open);

			PropsSaveData data = (PropsSaveData)bf.Deserialize(file);
			file.Close();

			PropsSet = data.GetArray();
		}

		DecodePropsData();
	}

	//==============================
	// 
	//==============================
	void DecodePropsData()
	{
		foreach (PropsData SD in PropsSet)
		{
			Vector3 pos = new Vector3(SD.posX, SD.posY, SD.posZ);
			//Vector3 scl = new Vector3(SD.sclX, SD.sclY, SD.sclZ);
			//Quaternion rot = new Quaternion(SD.rotX, SD.rotY, SD.rotZ, SD.rotW);

			GameObject work = Instantiate(PropsReferenceArray[SD.nId], pos, Quaternion.identity) as GameObject;
			//work.transform.localScale = scl;
			work.transform.SetParent(this.transform);
		}
	}
	void EncodePropsData()
	{
		PropsSet = new PropsData[ForSaving.Length];
		for (int i = 0; i < ForSaving.Length; i++)
		{
			PropsSet[i].nId = ForSaving[i].GetComponent<SceneProp>().GetID();
			PropsSet[i].posX = ForSaving[i].transform.position.x;
			PropsSet[i].posY = ForSaving[i].transform.position.y;
			PropsSet[i].posZ = ForSaving[i].transform.position.z;

			//PropsSet[i].rotW = ForSaving[i].transform.rotation.w;
			//PropsSet[i].rotX = ForSaving[i].transform.rotation.x;
			//PropsSet[i].rotY = ForSaving[i].transform.rotation.y;
			//PropsSet[i].rotZ = ForSaving[i].transform.rotation.z;

			//PropsSet[i].sclX = ForSaving[i].transform.localScale.x;
			//PropsSet[i].sclY = ForSaving[i].transform.localScale.y;
			//PropsSet[i].sclZ = ForSaving[i].transform.localScale.z;
		}
	}
}

[Serializable]
class PropsSaveData
{
	private PropsData[] PropsArray;

	public void SetArray(PropsData[] scenery)
	{
		PropsArray = scenery;
	}
	public PropsData[] GetArray()
	{
		return PropsArray;
	}

}