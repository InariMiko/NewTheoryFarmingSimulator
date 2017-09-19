using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class placing_variable : MonoBehaviour {
	GameObject tile;
	public int id;
	private string[] trees;
	public double cost;
	public double profit;
	public string name;
	public string detail;
	public int harvest_time;
	bool status;

	IEnumerator Start () {
		WWW treeData = new WWW ("http://localhost/NewTheorySimulator/tree_data.php");
		yield return treeData;
		status = true;
		string treeDataString = treeData.text;
		trees = treeDataString.Split (';');
		name = GetDataValue (trees [id], "Name:");
		//print (name);
		cost = Convert.ToDouble(GetDataValue (trees [id], "cost_per_Rai:"));
		//print (GetDataValue (trees [id], "cost_per_Rai:"));
		profit = Convert.ToDouble(GetDataValue (trees [id], "profit_per_Rai:"));
		detail = GetDataValue (trees [id], "detail:");
		harvest_time = Convert.ToInt32(GetDataValue (trees [id], "first_harvest_time:"));
		globalvariable.id = id;
		//print (getCost ());
	}
	
	string GetDataValue(string data,string index){
		string value = data.Substring (data.IndexOf (index) + index.Length);
		if(value.Contains("|"))
			value = value.Remove(value.IndexOf("|"));
		return value;
	}
	public void setTile(GameObject T){
		tile = T;
	}
	public GameObject getTile(){
		return tile;
	}
	public double getCostfromTile(){
		return tile.GetComponent<Tile> ().getCalc_cost ();
	}
	public double getprofitfromTile(){
		return tile.GetComponent<Tile> ().getCalc_profit ();
	}
	public string getName(){
		return name;
	}
	public double getCost(){
		return cost;
	}
	public double getProfit(){
		return profit;
	}
	public bool Cangetvalue(){
		return status;
	}
	public int getHarvestTime(){
		return harvest_time;
	}

}
