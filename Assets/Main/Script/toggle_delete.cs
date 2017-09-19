using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

using  cakeslice;

	public class toggle_delete : MonoBehaviour {
		Transform ht=null;
		void Update()
		{


			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			var layerMask = 1 << 8; // only cast ray on layer 8 (prefab layer)


			if (Physics.Raycast (ray, out hit, Mathf.Infinity, layerMask)&&!globalvariable.isplaceing) {
			
			if (ht != hit.transform&&ht!=null) {
					if (ht.gameObject.GetComponent<Outline> ())
						ht.gameObject.GetComponent<Outline> ().enabled = false;
					foreach (Transform child in ht) {
						if (child.gameObject.GetComponent<Outline> ())
							child.gameObject.GetComponent<Outline> ().enabled = false;
					}
				}
				ht = hit.transform;
				if (ht.parent != null)
					ht = ht.parent;
				if (ht.gameObject.GetComponent<Outline> ())
					ht.gameObject.GetComponent<Outline> ().enabled = true;
					foreach (Transform child in ht) {
						if (child.gameObject.GetComponent<Outline> ())
							child.gameObject.GetComponent<Outline> ().enabled = true;
					}

				if (Input.GetMouseButtonDown (0)) {
					print ("destroy" + ht.gameObject.name);
					double calculated_cost =ht.gameObject.GetComponent<placing_variable> ().getCostfromTile ();
					double calculated_profit =ht.gameObject.GetComponent<placing_variable> ().getprofitfromTile ();

					//money recalculation
					starting_money money_p = GameObject.Find ("Left_money").GetComponent<starting_money>();
					money_p.UpdateMoney (-calculated_cost);
					money_p.UpdateProfit (-calculated_profit);
					money_p.UpdateTotalCost (-calculated_cost);


					GameObject temptile = ht.gameObject.GetComponent<placing_variable>().getTile();
					temptile.SetActive (true);
					if(!globalvariable.isplaceing)
						temptile.GetComponent<Renderer> ().enabled = false;
					ht.gameObject.GetComponent<cost_and_incoming_updater> ().update_values_down();
					Destroy (ht.gameObject);

					ht = null;
				}
				}
				else {
					if (ht != null) {
						if (ht.gameObject.GetComponent<Outline> ())
						ht.gameObject.GetComponent<Outline> ().enabled = false;
						foreach (Transform child in ht) {
							if (child.gameObject.GetComponent<Outline> ())
								child.gameObject.GetComponent<Outline> ().enabled = false;
						}
					}
				}
				

		}

	}
	