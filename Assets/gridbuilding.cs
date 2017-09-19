using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class gridbuilding : MonoBehaviour {

	public GameObject grid;
	private int width;
	private int height;	
	public InputField width_field;
	public InputField height_field;
	public int distance;
	private int area;
	private int grid_area, grid_width, grid_height;
	drag_drop_tree d;
	public void spawn()
	{
		print ("Hello");
		int spawnNum = area / grid_area;
		int row = width / grid_width;

		for (int i = 0; i < row; i++)
		{
			if(i==0)
				for (int j = 0; j < (spawnNum/row)-1; j++)
				{



					Vector3 gridPos = new Vector3(this.transform.position.x + (j+1) * (5 + distance),
						0,
						this.transform.position.z + i * 5);
					gridPos.y = Terrain.activeTerrain.SampleHeight(gridPos)+0.4f;
					Instantiate(grid, gridPos, Quaternion.identity);
				}
			else
				for (int j = 0; j < (spawnNum / row); j++)
				{



					Vector3 gridPos = new Vector3(this.transform.position.x + (j) * (5 + distance),
						0,
						this.transform.position.z + i * 5);
					gridPos.y = Terrain.activeTerrain.SampleHeight(gridPos)+0.4f;
					Instantiate(grid, gridPos, Quaternion.identity);
				}

		}
	}
	public void starting()
	{
		 height= Convert.ToInt32 (width_field.text);
		width = Convert.ToInt32 (height_field.text);
		area = width * height;


		grid_width = 230;
		grid_height = 230;
		grid_area = grid_width * grid_height;
	}
}
