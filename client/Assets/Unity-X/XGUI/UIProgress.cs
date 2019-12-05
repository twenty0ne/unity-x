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
		_originSize = fillBar.sizeDelta;
		Debug.Log("xx-- originSize > " + _originSize);
	}

	public void SetValueFormat(string foramt)
	{
		_valueFormat = foramt;
	}

	public void SetPercent(float value)
	{
		// if (_currValue == val)
		// 	return;

		_currValue = value;

		Debug.Log("xx-- percent value > " + _originSize.x * _currValue * 0.01f);

		if (valueLabel != null)
			valueLabel.text = string.Format(_valueFormat, _currValue);
		
		fillBar.sizeDelta = new Vector2(_originSize.x * _currValue * 0.01f, _originSize.y);
	}
}
