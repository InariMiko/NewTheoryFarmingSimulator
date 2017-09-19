using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
public class Tile : MonoBehaviour
{
	public Material ins;
	public Material outs;
	public String type;
	private Text count_text;
	private string[] trees;
	private int id;
	public double total_grid;
	private Text cost_text;
	private double cost;
	private double profit;
	private bool CanPlace;
	private double calculated_cost;
	private double calculated_profit;
	private GameObject newobject;
	void  Start()
	{




	}
	private void planting()
	{
		id = globalvariable.id;
		Vector3 plantPos = this.transform.position;
		plantPos.y=Terrain.activeTerrain.SampleHeight(plantPos);
		newobject = Instantiate(globalvariable.placingobject, plantPos, Quaternion.identity);
		StartCoroutine (calculating ());
	}
	IEnumerator calculating()
	{
		yield return new WaitUntil(()=>newobject.GetComponent<placing_variable>().Cangetvalue()==true);
		cost = newobject.GetComponent<placing_variable>().getCost();
		profit = newobject.GetComponent<placing_variable>().getProfit();
		double cost_perRai = ((1 / total_grid)*cost)/(1600.00);
		//print (total_grid);
		calculated_cost = cost_perRai * (globalvariable.area*0.3);

		double profit_perRai = ((1 / total_grid)*profit)/(1600.00);
		calculated_profit = profit_perRai * (globalvariable.area*0.3);
		//save this Tile to planted tree
		newobject.GetComponent<placing_variable> ().setTile (getTile ());

		starting_money money_p = GameObject.Find ("Left_money").GetComponent<starting_money>();
		money_p.UpdateMoney (calculated_cost);
		money_p.UpdateProfit (calculated_profit);
		money_p.UpdateTotalCost (calculated_cost);
		if (globalvariable.money < 0) {
			money_p.UpdateMoney (-calculated_cost);
			money_p.UpdateProfit (-calculated_profit);
			money_p.UpdateTotalCost (-calculated_cost);
			Destroy (newobject);
		} else {
			newobject.GetComponent<cost_and_incoming_updater> ().update_values ();
			gameObject.SetActive (false);
		}
		//find min harvest time
		if (globalvariable.harvest_time == 0) {
			//start case
			globalvariable.harvest_time = newobject.GetComponent<placing_variable> ().getHarvestTime ();
		} else if (newobject.GetComponent<placing_variable> ().getHarvestTime () < globalvariable.harvest_time) {
			//found new min time
			globalvariable.harvest_time = newobject.GetComponent<placing_variable> ().getHarvestTime ();
		}

	}
	public double getCalc_cost()
	{
		return calculated_cost;
	}
	public double getCalc_profit()
	{
		return calculated_profit;
	}
	public GameObject getTile()
	{
		return this.gameObject;
	}
	private void OnMouseOver()
	{
		if (Input.GetMouseButtonDown(0)&&globalvariable.isplaceing==true&&!globalvariable.IsOverUi)
		{
			if(gameObject.tag=="Tree_P"&&globalvariable.placingobject.tag=="Tree")
				planting();
			else if(gameObject.tag=="Rice_P"&&globalvariable.placingobject.tag=="Rice")
				planting();
		}
	}
	void OnMouseEnter()
	{
		if(globalvariable.isplaceing==true)
			gameObject.GetComponent<Renderer>().material = ins;
	}
	void OnMouseExit()
	{
		if (globalvariable.isplaceing == true)
			gameObject.GetComponent<Renderer>().material = outs;
	}
	public void changecolor()
	{
		gameObject.GetComponent<Renderer>().material = ins;
	}
}