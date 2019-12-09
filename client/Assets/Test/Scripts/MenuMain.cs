using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMain : UIMenu
{
	private enum TabIndex
	{
		Shop = 0,
		Card,
		Battle,
		Social,
		Event,
		Count,
	}


	public GameObject[] tabs = new GameObject[(int)TabIndex.Count];

	private int _curTabBarIndex = (int)TabIndex.Battle;
	private float _selectedTabWidth = 0f;
	private float _unselectedTabWidth = 0f;

	public static string Name { get { return "MenuMain"; } }

#if UNITY_EDITOR
	private void OnValidate()
	{
		Debug.Assert(tabs.Length == (int)TabIndex.Count);
		for (int i = 0; i < tabs.Length; ++i)
			Debug.Assert(tabs[i] != null);
	}
#endif

	protected override void OnShow()
	{
		Debug.Log("MenuMain.OnShow");
		UpdateTabs();
	}

	public void OnClickTabBar(int idx)
	{
		Logger.Debug("MenuMain.OnClickTabBar > " + idx);

		if (_curTabBarIndex == idx)
			return;

		// resize last tab bar
		GameObject curTab = tabs[_curTabBarIndex];
		var curTabRT = curTab.GetComponent<RectTransform>();
		// curTabRT.rect.width

		// set cur tab bar
		_curTabBarIndex = idx;
		UpdateTabs();
	}

	private void UpdateTabs()
	{
		float tabUnitWidth = Screen.width * 1.0f / ((int)TabIndex.Count + 1);
		_selectedTabWidth = tabUnitWidth * 2;
		_unselectedTabWidth = tabUnitWidth;

		Debug.Log("MenuMain.OnShow > " + _selectedTabWidth + " - " + _unselectedTabWidth);

		for (int i = 0; i < tabs.Length; ++i)
		{
			var curTabRT = tabs[i].GetComponent<RectTransform>();

			var curPos = curTabRT.anchoredPosition;
			curPos.x = (i - 2) * tabUnitWidth;

			if (i < _curTabBarIndex)
				curPos.x -= tabUnitWidth * 0.5f;
			else if (i > _curTabBarIndex)
				curPos.x += tabUnitWidth * 0.5f;
			curTabRT.anchoredPosition = curPos;

			if (i == _curTabBarIndex)
				curTabRT.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, _selectedTabWidth);
			else
				curTabRT.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, _unselectedTabWidth);
		}
	}
}
