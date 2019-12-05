using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TimeUtils
{
	public static void WaitForSeconds(float seconds, System.Action callback)
	{
		CoroutineHandler.DoCoroutine(_WaitForSeconds(seconds, callback));
	}

	private static IEnumerator _WaitForSeconds(float seconds, System.Action callback)
	{
		yield return new WaitForSeconds(seconds);
		callback.Invoke();
	}
}
