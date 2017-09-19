using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FloatingTextController : MonoBehaviour {
	private static FloatingText popupText;
	private static GameObject canvas;
	// Use this for initialization
	public static void Initialize()
	{
		canvas = GameObject.Find ("Canvas");
		popupText = Resources.Load<FloatingText> ("Prefabs/PopupTextParent");

	}
	
	// Update is called once per frame
	public static void CreateFloatingText(string text,Transform location)
	{
		FloatingText instance = Instantiate (popupText);
		Vector2 screenPosition = Camera.main.WorldToScreenPoint (location.position);
		instance.transform.SetParent (canvas.transform, false);
		instance.transform.position = location.position;
		instance.animator.gameObject.GetComponent<TextMeshProUGUI> ().SetText (text);
	}
}
