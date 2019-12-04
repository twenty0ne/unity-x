using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class ComponentCreater
{
	// [MenuItem("GameObject/UI/Image")]
	// public static void CreateImage()
	// {
	// 	if (Selection.activeTransform &&
	// 			Selection.activeTransform.GetComponentInParent<Canvas>())
	// 	{
	// 		GameObject obj = new GameObject("Image", typeof(Image));
	// 		obj.GetComponent<Image>().raycastTarget = false;
	// 		obj.transform.SetParent(Selection.activeTransform, false);
	// 	}
	// }

	// [MenuItem("GameObject/UI/Text")]
	// public static void CreateText()
	// {
	// 	if (Selection.activeTransform &&
	// 			Selection.activeTransform.GetComponentInParent<Canvas>())
	// 	{
	// 		GameObject obj = new GameObject("Text", typeof(Text));
	// 		obj.transform.SetParent(Selection.activeTransform, false);

	// 		var cp = obj.GetComponent<Text>();
	// 		cp.raycastTarget = false;
	// 		cp.resizeTextForBestFit = false;
	// 		cp.supportRichText = false;
	// 	}
	// }
}
