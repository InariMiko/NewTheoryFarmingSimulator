using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class draggable : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler{
    public GameObject ObjectToPlace;
    public GameObject clone;
    bool InventoryOver = false;
    public void OnBeginDrag(PointerEventData eventData)
    {
        
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            var layerMask = 1 << 8; // only cast ray on layer 8 (prefab layer)


            layerMask = ~layerMask; // invert layermask, so we dont hit layer 8 (which is for prefabs)
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
                clone = Instantiate(ObjectToPlace, hit.point, Quaternion.identity);

    }

    public void OnDrag(PointerEventData eventData)
    {

      
       
            if (clone != null) // if there is some object in clone variable
            {
                Ray ray2 = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit2;
                var layerMask2 = 1 << 8;
                layerMask2 = ~layerMask2; // we are casting rays on other layers, except 8
                if (Physics.Raycast(ray2, out hit2, Mathf.Infinity, layerMask2))  // we hit something
                {
                    Vector3 pos = hit2.point;
                pos.x = Mathf.Round(pos.x / 5) * 5;
                pos.z = Mathf.Round(pos.z / 5) * 5;
                pos.y= Terrain.activeTerrain.SampleHeight(pos);
                clone.transform.position = pos;// move our object there
                }
            }
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Instant_plant i = this.ObjectToPlace.GetComponent<Instant_plant>();
        if(i!=null)
        {
           
            i.starting();
            i.spawn(clone.transform.position);
        }
            clone = null; // clear clone variable
            InventoryOver = false;
        
    }
 
 }

