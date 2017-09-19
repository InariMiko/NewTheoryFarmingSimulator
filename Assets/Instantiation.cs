using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiation : MonoBehaviour {

	void Start() {
		for (int y = 0; y < 5; y++) {
			for (int x = 0; x < 5; x++) {
				GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

				cube.transform.position = new Vector3(this.transform.position.x+x, this.transform.position.y+y, this.transform.position.z);
			}
		}
	}
}