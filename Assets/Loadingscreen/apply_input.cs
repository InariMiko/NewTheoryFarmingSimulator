using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class apply_input : MonoBehaviour {

	public InputField width_field;
	public InputField height_field;
	public InputField money_field;
	// Use this for initialization
	void Start () {
		Button b = GetComponent<Button>();
		b.onClick.AddListener(onclick);
	}
	
	void onclick()
	{
		globalvariable.area = Convert.ToDouble (width_field.text) + Convert.ToDouble (height_field);
		globalvariable.money = Convert.ToDouble (money_field.text);
	}
}
