using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
	public void LoadScene(string sceneName, System.Action callback = null)
	{
		StartCoroutine(_LoadScene(sceneName, callback));
	}

	private IEnumerator _LoadScene(string sceneName, System.Action callback)
	{
			yield return SceneManager.LoadSceneAsync (sceneName, LoadSceneMode.Additive);

			if (callback != null)
				callback.Invoke();
	}

	public void SetActiveScene(string sceneName)
	{
		// Scene newlyLoadedScene = SceneManager.GetSceneAt (SceneManager.sceneCount - 1);
		Scene newlyLoadedScene = SceneManager.GetSceneByName(sceneName);
		if (newlyLoadedScene == null)
		{
			Logger.Error("cant find scene by name > " + sceneName);
			return;
		}

		SceneManager.SetActiveScene (newlyLoadedScene);
	}

	private IEnumerator LoadSceneAndSetActive (string sceneName)
	{
			// Allow the given scene to load over several frames and add it to the already loaded scenes (just the Persistent scene at this point).
			yield return SceneManager.LoadSceneAsync (sceneName, LoadSceneMode.Additive);

			// Find the scene that was most recently loaded (the one at the last index of the loaded scenes).
			Scene newlyLoadedScene = SceneManager.GetSceneAt (SceneManager.sceneCount - 1);

			// Set the newly loaded scene as the active scene (this marks it as the one to be unloaded next).
			SceneManager.SetActiveScene (newlyLoadedScene);
	}
}
