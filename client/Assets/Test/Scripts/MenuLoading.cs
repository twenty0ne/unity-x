using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuLoading : UIMenu
{
	public Text statusLabel;
	public UIProgress progressBar;

	public static string Name { get { return "MenuLoading"; } }

#if UNITY_EDITOR
	private void OnValidate()
	{
		Debug.Assert(statusLabel);
		Debug.Assert(progressBar);
	}
#endif

	protected override void OnShow()
	{
		EventManager.Instance.Add(EventName.LoadingBegin, this, OnEvtLoadingBegin);
		EventManager.Instance.Add(EventName.LoadingStep, this, OnEvtLoadingStep);
		EventManager.Instance.Add(EventName.LoadingEnd, this, OnEvtLoadingEnd);
	}

	protected override void OnHide()
	{
		EventManager.Instance.RemoveAll(this);
	}

	public override void Tick(float dt)
	{
		
	}

	private void OnEvtLoadingBegin(Event evt)
	{
		Logger.Debug("MenuLoading.OnEvtLoadingBegin");
		statusLabel.text = "Loading Begin.";
	}

	private void OnEvtLoadingStep(Event evt)
	{
		Logger.Debug("MenuLoading.OnEvtLoadingStep");

		EventSimpleInt nevt = evt as EventSimpleInt;

		if (nevt.val == (int)LoadingStep.Login)
		{
			statusLabel.text = "Login...";
		}
		else if (nevt.val == (int)LoadingStep.Data)
		{
			statusLabel.text = "Loading Data...";
		}
		else if (nevt.val == (int)LoadingStep.Main)
		{
			statusLabel.text = "Loading Main...";
		}

		float percent = nevt.val * 100.0f / (int)LoadingStep.Count;
		progressBar.SetPercent(percent);
	}

	private void OnEvtLoadingEnd(Event evt)
	{
		Logger.Debug("MenuLoading.OnEvtLoadingEnd");
		statusLabel.text = "Loading End.";
	}
}
