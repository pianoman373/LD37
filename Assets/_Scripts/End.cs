using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour {

	// Use this for initialization
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.name == "Player") {
			Map.nextMap ();
		}
	}
}
