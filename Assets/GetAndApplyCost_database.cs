using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GetAndApplyCost_database : MonoBehaviour {

	private string[] trees;
	public int id;
	public double total_grid;
	public String type;
	private Text cost_text;
	private double cost;
	private bool CanPlace;
	private double calculated_cost;
	IEnumerator Start () {
		WWW treeData = new WWW ("http://localhost/NewTheorySimulator/tree_data.php");
		yield return treeData;
		string treeDataString = treeData.text;
		trees = treeDataString.Split (';');
		cost = Convert.ToDouble(GetDataValue (trees [id], "cost_per_Rai:"));
	

		cost_text =  GameObject.Find("TotalCost").GetComponent<Text>();

		double cost_perRai = ((1 / total_grid)*cost)*(1600.00*1600.00);
		calculated_cost = cost_perRai / globalvariable.area;

		starting_money money_p = GameObject.Find ("Left_money").GetComponent<starting_money>();
		money_p.UpdateMoney (calculated_cost);
		cost_text.text = "" +(Convert.ToDouble (cost_text.text) + calculated_cost);
	}
	
	string GetDataValue(string data,string index){
		string value = data.Substring (data.IndexOf (index) + index.Length);
		if(value.Contains("|"))
			value = value.Remove(value.IndexOf("|"));
		return value;
	}
	public double GetCost(){
		return calculated_cost;
	}
}
