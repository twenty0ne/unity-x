using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemData
{
	public int itemId;
	public int num;
}

[Serializable]
public class SettingsData
{
	public bool isPlayMusic = true;
	public bool isPlaySFX = true;
}

[Serializable]
public class ProductData
{
	public int productId;
	public string name;
	public string icon;
	public int sweet;
	public int tart;
	public int bitter;
	public int tea;
	public int milk;
	public int alcohol;
	public int price;
}

[Serializable]
public class PlayerData : ISerializationCallbackReceiver
{
	public ItemData[] items;
	public ProductData[] products;
	public SettingsData settings;

	public PlayerData()
	{
		items = new ItemData[0];
		products = new ProductData[0];
		settings = new SettingsData();
	}

	public void OnAfterDeserialize()
	{
		Debug.Log("xx-- PlayerData.OnAfterDeserialize");
	}

	public void OnBeforeSerialize()
	{
		Debug.Log("xx-- PlayerData.OnBeforeSerialize");
	}
}

