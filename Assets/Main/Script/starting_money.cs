using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class starting_money : MonoBehaviour {
	public Text money_text;
	public Text profit_text;
	public Text cost_text;
	public Text total_profit;
	double money;
	double profit;
	private string[] trees;
	IEnumerator Start () {
		WWW treeData = new WWW ("http://localhost/NewTheorySimulator/tree_data.php");
		yield return treeData;
		string treeDataString = treeData.text;
		trees = treeDataString.Split (';');

		profit = 0;
		money = globalvariable.money;
		money_text.text = "" + money;
		//cost_text =  GameObject.Find("TotalCost").GetComponent<Text>();
		FloatingTextController.Initialize ();
	}
	public void UpdateMoney(double cost){
		//print ("cost:" + cost);
		if(cost>0)
			FloatingTextController.CreateFloatingText ("-"+cost.ToString("F2"), money_text.transform);
		else
			FloatingTextController.CreateFloatingText ("<color=green>"+(cost*-1).ToString("F2")+"</color>", money_text.transform);
		money -= cost;
		globalvariable.money = money;
		money_text.text =  money.ToString("F2");
	}
	public void UpdateProfit(double p){
		profit += p;
		globalvariable.profit = profit;
		profit_text.text = profit.ToString("F2");
		total_profit.text = profit.ToString ("F2");
	}
	public void UpdateTotalCost(double c){
		cost_text.text =  (Convert.ToDouble (cost_text.text) + c).ToString("F2");
	}
}
