using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ConfigUtils
{
	public static bool IsValidStringValue(string str)
	{
		return string.IsNullOrEmpty(str) == false && str != "#";
	}

	// public static void 
	// public static bool CheckRecipeRatioValid(string str)
	// {
	// 	string[] vals = str.Split(':');
	// 	Debug.Assert(vals.Length == 3, "CHECK: recipe ratio should be 3 values.");
		
	// }
}
