using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineHandler : MonoBehaviour
{
	private static CoroutineHandler _instance;
	public static CoroutineHandler Instance
	{
		get 
		{
			if (_instance == null)
			{
				GameObject obj = new GameObject("CoroutineHandler");
				DontDestroyOnLoad(obj);
				_instance = obj.AddComponent<CoroutineHandler>();
			}

			return _instance;
		}
	}

	private void OnDisable() 
	{
		if (_instance)
			Destroy(_instance.gameObject);
	}

	public static Coroutine DoCoroutine(IEnumerator coroutine)
	{
		return Instance.StartCoroutine(coroutine);
	}
}