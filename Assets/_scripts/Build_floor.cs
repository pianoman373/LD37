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
	public static List<Vector2> moveDown = new List<Vector2>();
	public static List<Vector2> moveUp = new List<Vector2>();

	void Start () {
		for (int x=0;x<size; x++) {//loop though x and y
			for (int y = 0; y < size; y++) {
				up[x,y] = false; //set all to false
				floor[x,y] = Instantiate (prefab, new Vector3 (x, 0, y), new Quaternion ());//and add all
			}
		}
		moveUp.Add(new Vector3(0,0));
	}
	
	// Update is called once per frame
	void Update () {
		float y;
		foreach (Vector3 i in moveUp) {
			if (floor [(int)i.x, (int)i.z].transform.position.y + (speed * Time.deltaTime) >= 1) {
				y = 1;
			} else {
				y = (float)(floor [(int)i.x, (int)i.y].transform.position.y + (speed * Time.deltaTime));
			}
			floor [(int)i.x, (int)i.z].transform.position.Set (i.x, y, i.z);
			print (y);
			print (floor [(int)i.x, (int)i.y].transform.position);
			if (i.y == 1) {
				print ("remved");
				moveUp.Remove (i);
			}
		}
	}
}