using System;
using UnityEngine;


[Serializable]
public class PlayerData
{
	public Vector3 position;
	public Quaternion rotation;
}

[Serializable]
public class SystemData
{
	public int currentTempSaveNum;
	public string savedTime;
}

[Serializable]
public class SaveDataWithHash
{
	public PlayerData playerData;
	public SystemData systemData;

	public string hashOfContents;
}