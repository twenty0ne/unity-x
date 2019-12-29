using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JsonDataSaver : IDataSaver 
{
	// persistentDataPath:
	// mac: /User/xxx/Library/Application Support/company name/product name
	// windows: Users/xxxx/AppData/LocalLow/CompanyName/ProductName
	// android: /storage/emulated/0/Android/data/<packagename>/files
	// ios: /var/mobile/Containers/Data/Application/<guid>/Documents
	public static string GetSaveFullPath(string filename)
	{
		return string.Format("{0}/{1}", Application.persistentDataPath, filename);
	}

	public void Save(PlayerData dat)
	{
		string fn = GetSaveFullPath ("player.txt");
		string json = JsonUtility.ToJson (dat);

		using (StreamWriter writer = new StreamWriter (new FileStream (fn, FileMode.Create)))
		{
			writer.Write (json);
		}
	}

	public bool Load(PlayerData dat)
	{
		string fn = GetSaveFullPath ("player.txt");

		if (File.Exists (fn)) 
		{
			using (StreamReader reader = new StreamReader (new FileStream (fn, FileMode.Open)))
			{
				JsonUtility.FromJsonOverwrite (reader.ReadToEnd (), dat);	
			}

			return true;
		}

		return false;
	}
}
