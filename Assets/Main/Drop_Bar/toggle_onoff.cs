using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace cakeslice{
public class toggle_onoff : MonoBehaviour {

		ColorBlock tempcolor;
		ColorBlock normalcolor;
	// Use this for initialization
	private void Start()
	{
		Button btn = GetComponent<Button>();
		btn.onClick.AddListener(onoff);
		tempcolor = GetComponent<Button> ().colors;
		normalcolor = tempcolor;

	}
	void onoff(){
			GetComponent<toggle_delete> ().enabled=!GetComponent<toggle_delete> ().enabled;
			if (GetComponent<toggle_delete> ().enabled) {
				tempcolor.normalColor = new Color (0.4f, 0.4f, 0.4f, 1);
				tempcolor.highlightedColor = new Color (0.4f, 0.4f, 0.4f, 1);
				GetComponent<Button> ().colors = tempcolor;
			} else {
				GetComponent<Button> ().colors = normalcolor;
			}
	}

}
}
