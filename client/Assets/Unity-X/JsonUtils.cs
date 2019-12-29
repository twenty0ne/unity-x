using System;
using System.Collections;
using System.Collections.Generic;
using SimpleJson;

public static class JsonUtils
{
	public static bool TryGetInt(this JsonObject obj, string key, ref int value)
	{
		if (obj.ContainsKey(key))
		{
			value = (int)obj[key];
			return true;
		}
		return false;
	}

	public static bool TryGetString(this JsonObject obj, string key, ref string value)
	{
		if (obj.ContainsKey(key))
		{
			value = (string)obj[key];
			return true;
		}
		return false;
	}

	public static bool TryGetFloat(this JsonObject obj, string key, ref float value)
	{
		if (obj.ContainsKey(key))
		{
			value = (float)obj[key];
			return true;
		}
		return false;
	}

	public static bool TryGetStringArray(this JsonObject obj, string key, 
		ref string[] values, string separator = " ")
	{
		if (obj.ContainsKey(key))
		{
			string val = (string)obj[key];
			values = val.Split(separator.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
			return true;
		}
		return false;
	}

	public static bool TryGetIntArray(this JsonObject obj, string key, 
		ref int[] values, string separator = " ")
	{


		string[] tmp = null;
		if (obj.TryGetStringArray(key, ref tmp))
		{
			values = new int[tmp.Length];
			for (int i = 0; i < tmp.Length; ++i)
			{
				values[i] = int.Parse(tmp[i].Trim());
			}
			return true;
		}
		return false;
	}

	public static bool TryGetFloatArray(this JsonObject obj, string key, 
		ref float[] values, string separator = " ")
	{
		string[] tmp = null;
		if (obj.TryGetStringArray(key, ref tmp))
		{
			values = new float[tmp.Length];
			for (int i = 0; i < tmp.Length; ++i)
			{
				values[i] = float.Parse(tmp[i].Trim());
			}
			return true;
		}
		return false;
	}
}
