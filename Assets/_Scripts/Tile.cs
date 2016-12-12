using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {
	public GameObject[] lights;

	// Use this for initialization
	void Start () {
		//turnOff ();
	}

	public void turnOff() {
		foreach (GameObject i in lights) {
			i.SetActive (false);
		}
	}

	public void turnOn() {
		foreach (GameObject i in lights) {
			i.SetActive (true);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
