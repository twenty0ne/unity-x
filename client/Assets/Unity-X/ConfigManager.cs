using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class ConfigManager
{
	private static readonly string[] lineSeparator = new string[] {"\n", "\r\n"};
	private static readonly char[] valueSeparator = new char[]{','};

	public static Dictionary<string, ItemConfig> itemConfigs = new Dictionary<string, ItemConfig>();
	public static Dictionary<string, RecipeConfig> recipeConfigs = new Dictionary<string, RecipeConfig>();

	// key - -1_-1_-1_0
	private static Dictionary<string, string> _recipeIndexs = new Dictionary<string, string>();

	private static StringBuilder _gsb = new StringBuilder();

	public static bool Init()
	{
		LoadConfig<ItemConfig>("config_item.csv", itemConfigs);
		LoadConfig<RecipeConfig>("config_recipe.csv", recipeConfigs);

		if (GameDefine.IsCheckConfigsValid)
		{
			CheckConfigsValid();
		}

		return true;
	}

	// TODO:
	// how to read into one array, like element_1, element_2
	private static void LoadConfig<T>(string filename, Dictionary<string, T> dicts) where T : class, new()
	{
		string txt = AssetManager.LoadConfig(AssetsPath.Configs + filename);
		string[] lines = txt.Split(lineSeparator, System.StringSplitOptions.RemoveEmptyEntries);
		if (lines.Length < 3)
		{
			Logger.Error("cant find any lines in config > " + filename);
			return;
		}

		System.Type t = typeof(T);
		FieldInfo[] fieldInfos = t.GetFields();
		
		// cache for search
		Dictionary<string, FieldInfo> fiDict = new Dictionary<string, FieldInfo>();
		foreach (var fi in fieldInfos)
		{
			fiDict[fi.Name.ToLower()] = fi; 
		}

		// line 0: key
		// line 1: value-type
		string[] keys = lines[0].Split(valueSeparator, System.StringSplitOptions.RemoveEmptyEntries);
		string[] valTypes = lines[1].Split(valueSeparator, System.StringSplitOptions.RemoveEmptyEntries);
		for (int i = 2; i < lines.Length; ++i)
		{
			T cfg = new T();

			string[] vals = lines[i].Split(valueSeparator, System.StringSplitOptions.RemoveEmptyEntries);
			// HARDCODE: use first val as key
			dicts[vals[0]] = cfg;
			
			for (int j = 0; j < vals.Length; ++j)
			{
				FieldInfo fi = null;
				if (fiDict.TryGetValue(keys[j].ToLower(), out fi) == false)
				{
					Logger.Error("cant find field define in > " + t.ToString());
					continue;
				}

				if ((fi.FieldType == typeof(String) && valTypes[j] == "STRING"))
					fi.SetValue(cfg, vals[j]);
				else if ((fi.FieldType == typeof(Int32) && valTypes[j] == "INT"))
					fi.SetValue(cfg, int.Parse(vals[j]));
				else if ((fi.FieldType == typeof(Single) && valTypes[j] == "FLOAT"))
					fi.SetValue(cfg, float.Parse(vals[j]));
				else
				{
					Logger.Error("failed because fieldtype dont match > " + fi.FieldType + " - " + valTypes[j]);
				}
			}
		}
	}

	public static ItemConfig GetItemConfig(int itemId)
	{
#if DEBUG
		if (!itemConfigs.ContainsKey(itemId.ToString()))
			Logger.Error("cant fine item config id > " + itemId);
#endif
		return itemConfigs[itemId.ToString()];
	}

	private static void CheckConfigsValid()
	{
		// Check config recipe ratio
		foreach (var kv in recipeConfigs)
		{
			var cfg = kv.Value;

			if (cfg.element_ratio + cfg.tea_ratio + cfg.water_ratio != 10)
				Debug.LogError("CHECK: config_recipe all ration != 10 > " + cfg.id);
			if (cfg.element_ratio != 0 && cfg.element1_ratio + cfg.element2_ratio + cfg.element3_ratio != 10)
				Debug.LogError("CHECK: config_recipe all element ration != 10 > " + cfg.id);
		}
	}
}
