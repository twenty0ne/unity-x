using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GSLoading : GameState
{
	private LoadingStep _loadingStep = LoadingStep.None;
	private SceneController _sceneCtrl = null;

	public override void Enter(GameState gs)
	{
		Logger.Debug("GSLoading.Enter.");
		UIManager.Instance.OpenMenu(MenuLoading.Name);

		_sceneCtrl = GameObject.FindObjectOfType<SceneController>();
	}

	public override void Exit(GameState gs)
	{
		Logger.Debug("GSLoading.Exit.");
		UIManager.Instance.CloseMenu(MenuLoading.Name, true);
	}

	public override void Tick()
	{
		if (_loadingStep == LoadingStep.Count)
			return;

		if (_loadingStep == LoadingStep.None)
			ChangeLoadingStep(_loadingStep + 1);
	}

	private void ChangeLoadingStep(LoadingStep step)
	{
		if (_loadingStep == step)
		{
			Logger.Warning("CHECK: set same loading step.");
			return;
		}

		_loadingStep = step;

		if (_loadingStep == LoadingStep.Login)
			OnLoadingStepLogin();
		else if (_loadingStep == LoadingStep.Data)
			OnLoadingStepData();
		else if (_loadingStep == LoadingStep.Main)
			OnLoadingStepMain();
		else if (_loadingStep == LoadingStep.Count)
			OnLoadingStepEnd();

		EventManager.Instance.Dispatch(EventId.LoadingStep, (int)_loadingStep);
	}

	private void OnLoadingStepLogin()
	{
		// FAKE: test
		TimeUtils.WaitForSeconds(0.1f, () => {
			ChangeLoadingStep(_loadingStep + 1);
		});
	}

	private void OnLoadingStepData()
	{
		// FAKE: test
		TimeUtils.WaitForSeconds(0.1f, () => {
			ChangeLoadingStep(_loadingStep + 1);
		});
		
	}

	private void OnLoadingStepMain()
	{
		_sceneCtrl.LoadScene("Main", ()=>{
			ChangeLoadingStep(_loadingStep + 1);
		});
	}

	private void OnLoadingStepEnd()
	{
		EventManager.Instance.Dispatch(EventId.LoadingEnd);

		_sceneCtrl.SetActiveScene("Main");

		var gs = new GSMain();
		GameManager.Instance.ChangeGameState(gs);
	}
}