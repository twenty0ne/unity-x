
public class GSLoading : GameState
{
	private LoadingStep _loadingStep = LoadingStep.None;

	public override void Enter(GameState gs)
	{
		UIManager.Instance.OpenMenu(MenuLoading.Name);
	}

	public override void Exit(GameState gs)
	{
		
	}

	public override void Tick()
	{
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

		EventManager.Instance.Dispatch(EventName.LoadingStep, (int)_loadingStep);
	}

	private void OnLoadingStepLogin()
	{
		// FAKE: test
		TimeUtils.WaitForSeconds(2f, () => {
			ChangeLoadingStep(_loadingStep + 1);
		});
	}

	private void OnLoadingStepData()
	{
		// FAKE: test
		TimeUtils.WaitForSeconds(2f, () => {
			ChangeLoadingStep(_loadingStep + 1);
		});
	}

	private void OnLoadingStepMain()
	{
		// FAKE: test
		TimeUtils.WaitForSeconds(2f, () => {
			ChangeLoadingStep(_loadingStep + 1);
		});
	}

	private void OnLoadingStepEnd()
	{
		EventManager.Instance.Dispatch(EventName.LoadingEnd);
	}
}