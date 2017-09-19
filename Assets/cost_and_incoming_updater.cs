using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class cost_and_incoming_updater : MonoBehaviour {

	public GameObject investment;
	public GameObject profit_tab;
	Transform percent;
	int percent_num;
	Transform cost;
	Transform profit_percent;
	Transform profit;
	double cost_num;
	double profit_num;
	public void update_values(){
		double cost_perRai = ((1.0 / 100.0)*GetComponent<placing_variable> ().getCost ())/(1600.00);
		double profit_perRai = ((1.0 / 100.0)*GetComponent<placing_variable> ().getProfit ())/(1600.00);
		//initiallize for investment and profit
		percent = investment.gameObject.transform.GetChild (2);
		cost =  investment.gameObject.transform.GetChild (3);
		profit_percent = profit_tab.gameObject.transform.GetChild (2);
		profit =  profit_tab.gameObject.transform.GetChild (3);
		percent_num = int.Parse(Regex.Match (percent.GetComponent<Text> ().text, @"\d+").Value);
		if (percent_num == 0) {
			investment.gameObject.SetActive (true);
			profit_tab.gameObject.SetActive (true);
		}
		percent_num++;
		percent.GetComponent<Text> ().text = percent_num+"%";
		profit_percent.GetComponent<Text>().text = percent_num+"%";

		profit_num = double.Parse (Regex.Match (cost.GetComponent<Text> ().text, @"[+-]?([0-9]*[.])?[0-9]+").Value) + (profit_perRai*(globalvariable.area*0.3));
		profit.GetComponent<Text> ().text =profit_num.ToString("F2") +" Baht";

		cost_num = double.Parse (Regex.Match (cost.GetComponent<Text> ().text, @"[+-]?([0-9]*[.])?[0-9]+").Value) + (cost_perRai*(globalvariable.area*0.3));
		print ("cost_num:" + cost_num);
		cost.GetComponent<Text> ().text =cost_num.ToString("F2") +" Baht";

	}
	public void update_values_down(){
		double cost_perRai = ((1.0 / 100.0)*GetComponent<placing_variable> ().getCost ())/(1600.00);
		double profit_perRai = ((1.0 / 100.0)*GetComponent<placing_variable> ().getProfit ())/(1600.00);
		//initiallize for investment and profit
		percent = investment.gameObject.transform.GetChild (2);
		cost =  investment.gameObject.transform.GetChild (3);
		profit_percent = profit_tab.gameObject.transform.GetChild (2);
		profit =  profit_tab.gameObject.transform.GetChild (3);
		percent_num = int.Parse(Regex.Match (percent.GetComponent<Text> ().text, @"\d+").Value);
		if (percent_num == 1) {
			investment.gameObject.SetActive (false);
			profit_tab.gameObject.SetActive (false);
		}
		percent_num--;
		percent.GetComponent<Text> ().text = percent_num+"%";
		profit_percent.GetComponent<Text>().text = percent_num+"%";

		profit_num = double.Parse (Regex.Match (cost.GetComponent<Text> ().text, @"[+-]?([0-9]*[.])?[0-9]+").Value) - (profit_perRai*(globalvariable.area*0.3));
		profit.GetComponent<Text> ().text =profit_num.ToString("F2") +" Baht";

		cost_num = double.Parse (Regex.Match (cost.GetComponent<Text> ().text, @"[+-]?([0-9]*[.])?[0-9]+").Value) - (cost_perRai*(globalvariable.area*0.3));
		cost.GetComponent<Text> ().text =cost_num.ToString("F2") +" Baht";

	}
}
