using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Build_floor : MonoBehaviour {
	// Use this for initialization
	public GameObject prefab;
	public int size;//max is 20 for now
	public float speed;

	public static GameObject[,] floor = new GameObject[20,20];
	public static bool[,] up = new bool[20, 20];
	public static Vector3[] moveDown = new Vector3[400];
	public static Vector3[] moveUp = new Vector3[400];

	void Start () {
		for (int x=0;x<size; x++) {//loop though x and y
			for (int y = 0; y < size; y++) {
				up[x,y] = false; //set all to false
				floor[x,y] = Instantiate (prefab, new Vector3 (x, 0, y), new Quaternion ()) as GameObject;//and add all
			}
		}
	}

	
	// Update is called once per frame
	void Update () {
		foreach(Vector3 i in moveUp){
			
	}
}
}