using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Map : MonoBehaviour {
	// Use this for initialization
	public GameObject prefab;
	public GameObject crate;
	public float speed;

	const int size = 10;//max is 20 for now

	public static List<GameObject> Crates = new List<GameObject>();
	public static GameObject[,] floor = new GameObject[size,size];
	public static bool[,] up = new bool[size, size];
	public static List<Vector2> moveDown = new List<Vector2>();
	public static List<Vector2> moveUp = new List<Vector2>();
	private List<Vector2> remove = new List<Vector2>();

	private int[,] map1 = new int[10, 10]
	{
		{1, 0, 1, 0, 0, 0, 0, 0, 0, 0 },
		{1, 1, 0, 0, 0, 0, 0, 0, 0, 0 },
		{0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
		{0, 0, 0, 1, 1, 1, 0, 0, 0, 0 },
		{0, 0, 1, 0, 0, 0, 1, 0, 0, 0 },
		{0, 0, 1, 0, 0, 0, 1, 0, 0, 0 },
		{0, 1, 1, 0, 0, 0, 0, 0, 0, 0 },
		{0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
		{0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
		{0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
	};

	void Start () {
		for (int x=0;x<size; x++) {//loop though x and y
			for (int z = 0; z < size; z++) {
				up[x,z] = false; //set all to false
				floor[x,z] = Instantiate (prefab, new Vector3 (x, 0, z), new Quaternion (-0.707f,0,0,0.707f));//and add all
			}
		}
		//left wall
		for (int z = 0; z < size + 2; z++) {
			Instantiate (prefab, new Vector3 (-1, 1, z - 1), new Quaternion (-0.707f,0,0,0.707f));
		}

		//right wall
		for (int z = 0; z < size + 2; z++) {
			Instantiate (prefab, new Vector3 (size, 1, z - 1), new Quaternion (-0.707f,0,0,0.707f));
		}

		//top wall
		for (int x = 0; x < size; x++) {
			Instantiate (prefab, new Vector3 (x, 1, -1), new Quaternion (-0.707f,0,0,0.707f));
		}

		//bottom wall
		for (int x = 0; x < size; x++) {
			Instantiate (prefab, new Vector3 (x, 1, size), new Quaternion (-0.707f,0,0,0.707f));
		}
		StartCoroutine(ExecuteAfterTime(1));
	}

	public void MoveUp(int x, int z){
		if (!up [x, z]) {
			moveUp.Add (new Vector2 (x, z));
			up [x, z] = true;
		}
	}

	public void MoveDown(int x, int z){
		if (up [x, z]) {
			moveDown.Add (new Vector2 (x, z));
			up [x, z] = false;
		}
	}

	// Update is called once per frame
	void Update () {
		
		float y;
		foreach (Vector2 i in moveUp) {
			y = floor [(int)i.x, (int)i.y].transform.position.y;
			if (y + (speed * Time.deltaTime) > 1) {
				y = 1;
			} else {
				y += (speed * Time.deltaTime);
			}
			floor [(int)i.x, (int)i.y].transform.position = new Vector3(i.x, y, i.y);
			if (y == 1) {
				remove.Add(i);
			}
		}
		foreach (Vector2 i in remove) {
			moveUp.Remove (i);
		}
		remove = new List<Vector2>();
		foreach (Vector2 i in moveDown) {
			y = floor [(int)i.x, (int)i.y].transform.position.y;
			if (y - (speed * Time.deltaTime) < 0) {
				y = 0;
			} else {
				y -= (speed * Time.deltaTime);
			}
			floor [(int)i.x, (int)i.y].transform.position = new Vector3(i.x, y, i.y);
			if (y == 1) {
				remove.Add(i);
			}
		}
		foreach (Vector2 i in remove) {
			moveDown.Remove (i);
		}
		remove = new List<Vector2>();
	}

	IEnumerator ExecuteAfterTime(float time){//to call the map to pop up
		yield return new WaitForSeconds(time);
		loadMap (map1);
	}

	void loadMap(int[,] map){ // a simple map loader
		for (int x = 0; x < size; x++)
		{
			for (int y = 0; y < size; y++)
			{
				if (map [x, y] == 1) {
					MoveUp (y, size-x-1);
				} else {
					MoveDown (y, size-x-1);
				}
			}
		}
	}
	public static bool isblock(int x, int z){
		if (x >= 0 && x <= size-1 && z >= 0 && z <= size-1) {
			return up [x, z];
		} else {
			return true;
		}
		
	}

	public static bool isCrate(int x, int z){
		foreach(GameObject i in Crates){
			if (i.transform.position == new Vector3 (x, 0.75f, z)) {
				return true;
			}
		}
		return false;
	}
}