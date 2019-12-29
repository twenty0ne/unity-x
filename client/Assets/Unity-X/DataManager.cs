using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataManager
{
	[NonSerialized]
	private static PlayerData _playerData;
	[NonSerialized]
	private static IDataSaver _dataSaver;
	// TODO:
	// 如果还有其他玩家信息，可以继续保存

	public static bool Init()
	{
		// TODO:
		// 对于 release 版本，可以采用加密的 saver
		_dataSaver = new JsonDataSaver();
		_playerData = new PlayerData();

		bool isExist = _dataSaver.Load(_playerData);
		if (!isExist)
		{
			Logger.Info("dont exist any data archive.");

			// Init 
			var itemCfgs = ConfigManager.itemConfigs.Values.ToList();
			_playerData.items = new ItemData[ConfigManager.itemConfigs.Count];
			for (int i = 0; i < itemCfgs.Count; ++i)
			{
				_playerData.items[i] = new ItemData();
				_playerData.items[i].itemId = itemCfgs[i].id;
				_playerData.items[i].num = 9999;
			}

			SaveData();
		}
		return true;
	}

	public static void SaveData()
	{
		_dataSaver.Save(_playerData);
	}

	public static ItemData[] GetItemDatas()
	{
		return _playerData.items;
	}

	public static ProductData[] GetProductDatas()
	{
		return _playerData.products;
	}

	public static void AddProductData(ProductData dat)
	{
		System.Array.Resize(ref _playerData.products, _playerData.products.Length + 1);
		_playerData.products[_playerData.products.Length - 1] = dat;
		SaveData();
	}
}
