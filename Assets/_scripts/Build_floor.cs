using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Build_floor : MonoBehaviour {
	// Use this for initialization
	public GameObject prefab;
	public int size;
	public static GameObject[,] floor = new GameObject[20,20];

	void Start () {
		for (int x=0;x<size; x++) {
			for (int y = 0; y < size; y++) {
				floor[x,y] = Instantiate (prefab, new Vector3 (x, 0, y), new Quaternion ()) as GameObject;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
