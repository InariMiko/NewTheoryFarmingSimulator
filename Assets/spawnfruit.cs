using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnfruit : MonoBehaviour {

	public GameObject fruit;
	int spawnNum=5;
	void spawn () {
		for (int i = 0; i < spawnNum; i++) {
			Vector3 fruitPos = new Vector3 (this.transform.position.x + Random.Range(2f, 3f),
				this.transform.position.y + Random.Range(5f, 5.5f),
				this.transform.position.z + Random.Range(-1f, 0.5f));
			Instantiate (fruit, fruitPos, Quaternion.identity);
		}
	}
	void Start() {
		spawn ();
	}
}