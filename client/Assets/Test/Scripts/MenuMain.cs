using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMain : UIMenu
{
	public static string Name { get { return "MenuMain"; } }

	private void Start()
	{
	}

	public void OnClickBtnBag()
	{
		Debug.Log("OnClickBtnBag");
		UIManager.Instance.OpenMenu("MenuBag");
	}

	public void OnClickBtnShop()
	{
		Debug.Log("OnClickBtnShop");
	}
}
