using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
#if UNITY_EDITOR
using UnityEditor.SceneManagement;
#endif

public class GameManager : MonoSingleton<GameManager>
{
	private GameState _currGameState = null;
	private GameState _prevGameState = null;

	public GameState CurrGameState { get { return _currGameState; } }
	public GameState PrevGameState { get { return _prevGameState; } }

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	static void OnBeforeSceneLoadRuntimeMethod()
	{
		DOTween.Init();

#if UNITY_EDITOR
		Scene scene = EditorSceneManager.GetActiveScene();
		if (scene.name != "Start" && scene.name.StartsWith("Test") == false)
		{
			Logger.Debug("change to start scene.");
			SceneManager.LoadScene("Start");
		}
#endif

		var gm = GameManager.Instance;
	}

	private void Start()
	{
#if UNITY_EDITOR
		Scene scene = EditorSceneManager.GetActiveScene();
		if (scene.name.StartsWith("Test"))
			return;
#endif

		// Init
		UIManager.Instance.MenuPrefabPath = "Prefabs/UI/";

		GameObject obj = GameObject.Find("MainCanvas");
		UIManager.Instance.AddCanvas("MainCanvas", obj.GetComponent<Canvas>(), true);

		var gs = new GSLoading();
		ChangeGameState(gs);
	}

	private void Update()
	{
		if (_currGameState != null)
		{
			_currGameState.Tick();
		}
	}

	public void ChangeGameState(GameState gs)
	{
		_prevGameState = _currGameState;
		if (_currGameState != null)
			_currGameState.Exit(gs);

		_currGameState = gs;
		_currGameState.Enter(gs);
	}
}
