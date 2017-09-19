using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fade_panel : MonoBehaviour {

	// Use this for initialization
	void Start () {
		foreach (Transform child in this.gameObject.transform) {
			if (child.GetComponent<CanvasRenderer> ()) {
				child.GetComponent<CanvasRenderer> ().SetAlpha (0f);
			}
		}
	}
	
	// Update is called once per frame
	public void fade_in () {
		foreach (Transform child in this.gameObject.transform) {
			if (child.GetComponent<Image> ()) {
				child.GetComponent<Image> ().CrossFadeAlpha (1f, 1f, false);
			}
		}
	}
}
