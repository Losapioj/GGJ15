using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml; 
using System.Xml.Serialization; 
using System.IO; 
using System.Text;

public class LoadSave : MonoBehaviour
{
	// An example where the encoding can be found is at 
	// http://www.eggheadcafe.com/articles/system.xml.xmlserialization.asp 
	// We will just use the KISS method and cheat a little and use 
	// the examples from the web page since they are fully described 
	
	// This is our local private members 
	Rect _Save, _Load, _SaveMSG, _LoadMSG;
	bool _ShouldSave, _ShouldLoad, _SwitchSave, _SwitchLoad;
	string _FileLocation, _FileName;
	
	Vector3 VPosition;
	
	List<XMLitemCatcher.GameItem> _GameItem;
	public GameObject[] bodies;
	string _data = string.Empty;
	
	void Awake()
	{
		_GameItem = new List<XMLitemCatcher.GameItem>();
	}
	
	// When the EGO is instansiated the Start will trigger 
	// so we setup our initial values for our local members 
	void Start()
	{
		// We setup our rectangles for our messages 
		_Save = new Rect(10, 80, 100, 20);
		_Load = new Rect(10, 100, 100, 20);
		_SaveMSG = new Rect(10, 120, 400, 40);
		_LoadMSG = new Rect(10, 140, 400, 40);
		
		// Where we want to save and load to and from 
		_FileLocation = Application.dataPath+"/";
		_FileName = "SaveData.xml";
	}
	
	void Update() { }
	
	bool isSaving = false;
	bool isLoading = false;
	void OnGUI()
	{
		//*************************************************** 
		// Loading The Player... 
		// **************************************************       
		
		
		//*************************************************** 
		// Saving The Player... 
		// **************************************************    
		
	}
	
	//////////////////////////////
	//used in new GUI save and loads
	//////////////////////////////
	public void SaveLevel()
	{
		if (!isSaving)
		{
			try
			{
				isSaving = true;
				GUI.Label(_SaveMSG, "Saving to: " + _FileLocation);
				
				bodies = FindObjectsOfType(typeof(GameObject)) as GameObject[];
				_GameItem = new List<XMLitemCatcher.GameItem>();
				XMLitemCatcher.GameItem itm;
				foreach (GameObject body in bodies)
				{
					itm = new XMLitemCatcher.GameItem();
					itm.ID = body.name + "_" + body.GetInstanceID();
					itm.Name = body.name;
					itm.posx = body.transform.position.x;
					itm.posy = body.transform.position.y;
					itm.posz = body.transform.position.z;
					_GameItem.Add(itm);
				}
				
				// Time to creat our XML! 
				_data = SerializeObject(_GameItem);
				
				CreateXML();
//				Debug.Log("Data Saved");
			}
			catch (Exception ex)
			{
				Debug.LogError(ex.ToString());
			}
			finally
			{
				isSaving = false;
			}
		}
	}
	
	//////////////////////////////
	public void LoadLevel()
	{
		if (!isLoading)
		{
			try
			{
				Debug.Log(_FileName);
				LoadXML();
				isLoading = true;
				GUI.Label(_LoadMSG, "Loading from: " + _FileLocation);
				Debug.Log(_FileLocation);
				Debug.Log(_FileName);
				Debug.Log("Data loaded");
			}
			catch (Exception ex)
			{
				Debug.LogError(ex.ToString());
			}
			finally
			{
				isLoading = false;
			}
			
		}
	}
	
	//////////////////////////////
	//////////////////////////////
	
	/* The following metods came from the referenced URL */
	string UTF8ByteArrayToString(byte[] characters)
	{
		UTF8Encoding encoding = new UTF8Encoding();
		string constructedString = encoding.GetString(characters);
		return (constructedString);
	}
	
	byte[] StringToUTF8ByteArray(string pXmlString)
	{
		UTF8Encoding encoding = new UTF8Encoding();
		byte[] byteArray = encoding.GetBytes(pXmlString);
		return byteArray;
	}
	
	// Here we serialize our UserData object of myData 
	string SerializeObject(object pObject)
	{
		string XmlizedString = null;
		MemoryStream memoryStream = new MemoryStream();
		XmlSerializer xs = new XmlSerializer(typeof(List<XMLitemCatcher.GameItem>));
		XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
		xs.Serialize(xmlTextWriter, pObject);
		memoryStream = (MemoryStream)xmlTextWriter.BaseStream;
		XmlizedString = UTF8ByteArrayToString(memoryStream.ToArray());
		return XmlizedString;
	}
	
	// Here we deserialize it back into its original form 
	object DeserializeObject(string pXmlizedString)
	{
		XmlSerializer xs = new XmlSerializer(typeof(List<XMLitemCatcher.GameItem>));
		MemoryStream memoryStream = new MemoryStream(StringToUTF8ByteArray(pXmlizedString));
		return xs.Deserialize(memoryStream);
	}
	
	// Finally our save and load methods for the file itself 
	void CreateXML()
	{
		StreamWriter writer;
		FileInfo t = new FileInfo(_FileLocation + "/" + _FileName);
		if (!t.Exists)
		{
			writer = t.CreateText();
		}
		else
		{
			//t.Delete();
			writer = t.CreateText();
		}
		writer.Write(_data);
		writer.Close();
		Debug.Log("File written.");
	}
	
	void LoadXML()
	{
		Debug.Log("File Searching........");
		if (File.Exists(_FileLocation + "/" + _FileName))
		{
			Debug.Log("File Analyzing........");
			StreamReader r = File.OpenText(_FileLocation + "/" + _FileName);
			Debug.Log(_FileLocation + "/" + _FileName);
			string _info = r.ReadToEnd();

			if(_info != "")
			{
				Debug.Log("LVL Found........");
				// notice how I use a reference to type (UserData) here, you need this
				// so that the returned object is converted into the correct type
				_GameItem = (List<XMLitemCatcher.GameItem>)DeserializeObject(_info);
				bodies = new GameObject[_GameItem.Count];
				Debug.Log("File Searching2........");
				for(int i = 0; i < _GameItem.Count; i++)
				{
					Debug.Log("LVL Building........");

					VPosition = new Vector3(_GameItem[i].posx, _GameItem[i].posy, _GameItem[i].posz);
					//var tried = Instantiate(bodies[i],VPosition,Quaternion.identity);
					bodies[i].transform.position=VPosition;
				}
				Debug.Log("File Read with item count: " + _GameItem.Count);
			}
			r.Close();
		}
		else
		{
			Debug.Log("Files does not exist: " + _FileLocation + "/" + _FileName);
		}
	}
}