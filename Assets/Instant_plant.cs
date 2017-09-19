using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instant_plant : MonoBehaviour {

    public GameObject Plant;
    public int width;
    public int length;
    public int distance;
    private int area;
    private int plant_area, plant_width, plant_height;
    drag_drop_tree d;
    public void spawn(Vector3 origin)
    {
      
        int spawnNum = area / plant_area;
        int row = width / plant_width;
        
        for (int i = 0; i < row; i++)
        {
            if(i==0)
            for (int j = 0; j < (spawnNum/row)-1; j++)
            {

                    
                
                    Vector3 plantPos = new Vector3(origin.x + (j+1) * (plant_width + distance),
                        0,
                        origin.z + i * plant_height);
                    plantPos.y = Terrain.activeTerrain.SampleHeight(plantPos);
                    Instantiate(Plant, plantPos, Quaternion.identity);
            }
            else
                for (int j = 0; j < (spawnNum / row); j++)
                {



                    Vector3 plantPos = new Vector3(origin.x + (j) * (plant_width + distance),
                        0,
                        origin.z + i * plant_height);
                    plantPos.y = Terrain.activeTerrain.SampleHeight(plantPos);
                    Instantiate(Plant, plantPos, Quaternion.identity);
                }

        }
    }
    public void starting()
    {
        
        area = width * length;

        
        //RectTransform rt = Plant.GetComponent<RectTransform>();
        d = GetComponent<drag_drop_tree>();
        
        plant_width = 5;
        plant_height = 5;
        plant_area = plant_width * plant_height;
    }
}
