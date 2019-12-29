using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJson;

// TODO:
// fonts, sprite, prefab ... also need localizations
public class Localization
{
	private static Dictionary<string, string> _localMap = new Dictionary<string, string>(); 

	public static bool Init()
	{
		string txt = AssetManager.LoadConfig(AssetsPath.Localizations + "ZH-HANS.json");
		SimpleJson.JsonObject objs = (SimpleJson.JsonObject)SimpleJson.SimpleJson.DeserializeObject(txt);
		foreach (var kv in objs)
		{
			_localMap[kv.Key] = (string)kv.Value;
		}

		return true;
	}

	public static string Get(string key)
	{
		string val;
		if (!_localMap.TryGetValue(key, out val))
		{
			Logger.Error("cant find localization key > " + key);
			return string.Empty;
		}
		return val;
	}
}
