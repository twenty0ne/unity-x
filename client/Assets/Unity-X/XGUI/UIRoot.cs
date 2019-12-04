using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRoot : MonoBehaviour
{
	public Canvas backCanvas;
	public Canvas mainCanvas;
	public Canvas frontCanvas;

	private void Awake()
	{
		UIManager.Instance.mainCanvas
	}
}
