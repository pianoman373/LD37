﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO; 

public class Map : MonoBehaviour {
	// Use this for initialization
	public GameObject prefab;
	public GameObject crate;
	public float speed;
	public Material color1;
	public Material color2;
	public Material color3;
	public Material color4;
	public Material color5;
	public Material color6;
	public Material color7;


	const int size = 15;

	public static List<GameObject> Crates = new List<GameObject>();
	public static GameObject[,] floor = new GameObject[size,size];
	public static bool[,] up = new bool[size, size];
	public static List<Vector2> moveDown = new List<Vector2>();
	public static List<Vector2> moveUp = new List<Vector2>();
	private List<Vector2> remove = new List<Vector2>();

	private int[,] map1 = fromFile("maps/map1.map");

	void Start () {
		for (int x=0;x<size; x++) {//loop though x and y
			for (int z = 0; z < size; z++) {
				up[x,z] = false; //set all to false
				floor[x,z] = Instantiate (prefab, new Vector3 (x, 0, z), new Quaternion ());//and add all
			}
		}
		//left wall
		for (int z = 0; z < size + 2; z++) {
			Instantiate (prefab, new Vector3 (-1, 1, z - 1), new Quaternion ());
		}

		//right wall
		for (int z = 0; z < size + 2; z++) {
			Instantiate (prefab, new Vector3 (size, 1, z - 1), new Quaternion ());
		}

		//top wall
		for (int x = 0; x < size; x++) {
			Instantiate (prefab, new Vector3 (x, 1, -1), new Quaternion ());
		}

		//bottom wall
		for (int x = 0; x < size; x++) {
			Instantiate (prefab, new Vector3 (x, 1, size), new Quaternion ());
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
		Player.frezze = false;
	}

	void loadMap(int[,] map){ // a simple map loader
		for (int x = 0; x < size; x++)
		{
			for (int y = 0; y < size; y++)
			{
				if (map [x, y] == 1) {
					MoveDown (y, size - x - 1);
					if (isCrate (y, size - x - 1)) {
						Destroy (getCrate (y, size - x - 1));
					}
				} else if (map [x, y] == 2) {
					MoveUp (y, size - x - 1);
				} else if (map [x, y] >= 101&&map [x, y] <= 107) {
					GameObject newCrate = Instantiate (crate, new Vector3 (y, 0.75f, size - x - 1), new Quaternion ());
					if(map [x, y]-100==1)newCrate.GetComponent<Renderer> ().material = color1;
					if(map [x, y]-100==2)newCrate.GetComponent<Renderer> ().material = color2;
					if(map [x, y]-100==3)newCrate.GetComponent<Renderer> ().material = color3;
					if(map [x, y]-100==4)newCrate.GetComponent<Renderer> ().material = color4;
					if(map [x, y]-100==5)newCrate.GetComponent<Renderer> ().material = color5;
					if(map [x, y]-100==6)newCrate.GetComponent<Renderer> ().material = color6;
					if(map [x, y]-100==7)newCrate.GetComponent<Renderer> ().material = color7;
					Crates.Add (newCrate);
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

	public static bool isCrate(float x, float z){
		foreach(GameObject i in Crates){
			if (i.transform.position == new Vector3 (x, 0.75f, z)) {
				return true;
			}
		}
		return false;
	}
	public static GameObject getCrate(float x, float z){
		foreach(GameObject i in Crates){
			if (i.transform.position == new Vector3 (x, 0.75f, z)) {
				return i;
			}
		}
		return null;
	}
	public static int[,] fromFile(string path){
		List<string[]> arrayOfFile = new List<string[]> ();
		try {
			string line;
			StreamReader theReader = new StreamReader (path, Encoding.Default);
			using (theReader) {
				do {
					line = theReader.ReadLine ();
					if (line != null) {
						arrayOfFile.Add (line.Split (','));
					}
				} while (line != null);   
				theReader.Close ();
				int[,] output = new int[arrayOfFile.Count, arrayOfFile [0].Length];
				int linenum = 0;
				foreach (string[] linee in arrayOfFile) {
					int itemnum = 0;
					foreach (string item in linee) {
						output [linenum, itemnum] = System.Int16.Parse (item);
						itemnum += 1;
					}
					linenum += 1;
				}
				return output;
			}
		} catch (System.Exception e) {
			print ("{0}\n" + e.Message);
		}
		return null;
	}
}