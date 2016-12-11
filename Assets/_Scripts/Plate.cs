using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.GetComponent<Renderer> ().material.name==this.GetComponent<Renderer> ().material.name)
		{
			other.gameObject.SetActive (false);
		}
	}
}
