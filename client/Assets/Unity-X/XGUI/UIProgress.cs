using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIProgress : UIWidget
{
	public RectTransform fillBar;
	public Text valueLabel;

	private string _valueFormat = "{0}%";
	private float _currValue = 0f;
	private Vector2 _originSize;

	private void Start()
	{
		_originSize = fillBar.rect.size;
	}

	public void SetValueFormat(string foramt)
	{
		_valueFormat = foramt;
	}

	public void SetPercent(float value)
	{
		_currValue = value;

		if (valueLabel != null)
			valueLabel.text = string.Format(_valueFormat, _currValue);
		
		fillBar.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, _originSize.x * _currValue * 0.01f);
	}
}
