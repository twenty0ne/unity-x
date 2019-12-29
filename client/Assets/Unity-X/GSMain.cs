using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GSMain : GameState
{
	public override void Enter(GameState gs)
	{
		UIManager.Instance.OpenMenu(MenuMain.Name);
	}

	public override void Exit(GameState gs)
	{
	}

	public override void Tick()
	{
	}
}
