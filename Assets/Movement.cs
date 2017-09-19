using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    CharacterController controller;
    public float speed;
    public int time;
	// Use this for initialization
	void Start () {
        controller = GetComponent<CharacterController>();
        InvokeRepeating("turn", time, time);
    }
	
	// Update is called once per frame
	void Update () {
       
        
        controller.Move(transform.forward*speed);
	}
    void turn()
    {
                transform.Rotate(0, 180, 0);
    }
}
