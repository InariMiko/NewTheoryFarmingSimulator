using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Apply_WH : MonoBehaviour {

    public InputField width_field;
    public InputField height_field;
    public Text areatext;
	public GameObject grid;
	gridbuilding gb;
	void Start () {

        Button b = GetComponent<Button>();
        b.onClick.AddListener(onclick);

	}
    void onclick()
    {
        areatext.text = ""+(Convert.ToInt32(width_field.text) * Convert.ToInt32(height_field.text));
		gridbuilding gb = this.grid.GetComponent<gridbuilding>();
		if (gb != null) {
			gb.starting ();
			gb.spawn ();
		} else {
			print ("null");
		}

    }
}
