using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Show_result : MonoBehaviour {

	// Use this for initialization
	public Transform canvas;
	void Start () {
		Button btn = GetComponent<Button>();
		btn.onClick.AddListener(show_result);
	}
	
	// Update is called once per frame
	void show_result () {
		if (canvas.gameObject.activeInHierarchy == false) {
			canvas.gameObject.SetActive (true);
			Time.timeScale = 0;
		} 
		else {
			canvas.gameObject.SetActive (false);
			Time.timeScale = 1;
		}
	}
}
