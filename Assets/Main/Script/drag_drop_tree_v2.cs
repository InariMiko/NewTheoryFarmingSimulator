using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class drag_drop_tree_v2 : MonoBehaviour
{
    public GameObject ObjectToPlace;
    GameObject []grid;
    public string Tagname;
	GameObject tile;
	ColorBlock tempcolor;
	ColorBlock normalcolor;
    private void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(showgrid);
		tempcolor = GetComponent<Button> ().colors;
		normalcolor = tempcolor;
        
    }
    void showgrid()
    {
		tempcolor.normalColor = new Color (0.4f, 0.4f, 0.4f, 1);
		tempcolor.highlightedColor = new Color (0.4f, 0.4f, 0.4f, 1);
		GetComponent<Button> ().colors = tempcolor;
		grid = GameObject.FindGameObjectsWithTag(Tagname);
        if (!globalvariable.isplaceing)
        {
            globalvariable.isplaceing = true;
            globalvariable.placingobject = ObjectToPlace;
            foreach (GameObject g in grid)
            {
                Renderer r = g.GetComponent<Renderer>();
                r.enabled = true;
            }
        }
        else
        {
			closinggrid();
        }
    }
	public void closinggrid()
	{
		globalvariable.isplaceing = false;
		GameObject []buttons = GameObject.FindGameObjectsWithTag("Drop_BT");
		foreach (GameObject button in buttons) {
			GetComponent<Button> ().colors = normalcolor;
		}

		grid = GameObject.FindGameObjectsWithTag("Tree_P");
		foreach (GameObject g in grid)
		{
			Renderer r = g.GetComponent<Renderer>();
			if (r.enabled == false)
				break;
			r.enabled = false;
		}
		grid = GameObject.FindGameObjectsWithTag("Rice_P");
		foreach (GameObject g in grid)
		{
			Renderer r = g.GetComponent<Renderer>();
			if (r.enabled == false)
				break;
			r.enabled = false;
		}
		globalvariable.placingobject = null;

	}

}

