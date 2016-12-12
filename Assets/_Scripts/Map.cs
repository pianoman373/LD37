using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO; 
using UnityEngine.SceneManagement;

public class Map : MonoBehaviour {
	// Use this for initialization
	public GameObject prefab;
	public GameObject crate;
	public GameObject button;
	public GameObject player;
	public GameObject end;
	public GameObject endText;
	public float speed;
	public Material color1;
	public Material color2;
	public Material color3;
	public Material color4;
	public Material color5;
	public Material color6;
	public Material color7;


	const int size = 20;

	public static bool nextMapb = false;
	public static List<GameObject> Crates = new List<GameObject>();
	public static List<GameObject> Buttons = new List<GameObject>();
	public static GameObject[,] floor = new GameObject[size,size];
	public static bool[,] up = new bool[size, size];
	public static List<Vector2> moveDown = new List<Vector2>();
	public static List<Vector2> moveUp = new List<Vector2>();
	private List<Vector2> remove = new List<Vector2>();
	public static List<Vector4> Group;
	public static GameObject endPoint;

	private static List<string> maps = new List<string>();

	void loadMaps(){
		foreach (string i in maps) {
			json.loadMap (i);
		}
	}

	void Start () {
		maps.Add ("tutorial.json");
		maps.Add ("template.json");
		loadMaps ();
		movePlayerSpawn(json.maps[maps[0]]);
		for (int x=0;x<size; x++) {//loop though x and y
			for (int z = 0; z < size; z++) {
				up[x,z] = false; //set all to false
				floor[x,z] = Instantiate (prefab, new Vector3 (x, 0, z), new Quaternion ());//and add all
			}
		}
		//left wall
		for (int z = 0; z < size + 2; z++) {
			GameObject obj = Instantiate (prefab, new Vector3 (-1, 1, z - 1), new Quaternion ());
			obj.GetComponent<Tile> ().turnOn ();
		}

		//right wall
		for (int z = 0; z < size + 2; z++) {
			GameObject obj = Instantiate (prefab, new Vector3 (size, 1, z - 1), new Quaternion ());
			obj.GetComponent<Tile> ().turnOn ();
		}

		//top wall
		for (int x = 0; x < size; x++) {
			GameObject obj = Instantiate (prefab, new Vector3 (x, 1, -1), new Quaternion ());
			obj.GetComponent<Tile> ().turnOn ();
		}

		//bottom wall
		for (int x = 0; x < size; x++) {
			GameObject obj = Instantiate (prefab, new Vector3 (x, 1, size), new Quaternion ());
			obj.GetComponent<Tile> ().turnOn ();
		}
		StartCoroutine(ExecuteAfterTime(1));
	}

	public static void MoveUp(int x, int z){
		if (!up [x, z]) {
			moveUp.Add (new Vector2 (x, z));
			up [x, z] = true;

			floor [x, z].GetComponent<Tile> ().turnOn ();
		}
	}

	public static void MoveDown(int x, int z){
		if (up [x, z]) {
			moveDown.Add (new Vector2 (x, z));
			up [x, z] = false;

			floor [x, z].GetComponent<Tile> ().turnOff ();
		}
	}

	// Update is called once per frame
	void Update () {
		
		if (nextMapb) {
			if (maps.Count == 0) {
				endText.SetActive (true);
				Player.frezze = true;
			} else {
				loadMap (maps [0]);
			}
			nextMapb = false;
		}
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
		loadMap (maps[0]);
		Player.frezze = false;
	}
	void movePlayerSpawn(int[,] map){
		for (int x = 0; x < size; x++) {
			for (int z = 0; z < size; z++) {
				if (map [x, z] == 3) {
					player.transform.position = new Vector3 (z, 1, size - x - 1);
					Player.setPos (z, size - x - 1);
				}
			}
		}
	}
	void loadMap(string mapName){ // a simple map loader
		foreach (GameObject i in Crates) {
			Destroy (i);
		}
		foreach (GameObject i in Buttons) {
			Destroy (i);
		}
		Crates = new List<GameObject>();
		Buttons = new List<GameObject>();
		Destroy (endPoint);
		int[,] map = json.maps[mapName];
		Group = json.groups[mapName]; 
		movePlayerSpawn(map);
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
				} else if (map [x, y] == 4) {
					endPoint = Instantiate (end, new Vector3 (y, 0.5f, size - x - 1), new Quaternion ());
				}else if (map [x, y] >= 101&&map [x, y] <= 107) {
					GameObject newCrate = Instantiate (crate, new Vector3 (y, 0.75f, size - x - 1), new Quaternion ());
					if(map [x, y]-100==1)newCrate.GetComponent<Renderer> ().material = color1;
					if(map [x, y]-100==2)newCrate.GetComponent<Renderer> ().material = color2;
					if(map [x, y]-100==3)newCrate.GetComponent<Renderer> ().material = color3;
					if(map [x, y]-100==4)newCrate.GetComponent<Renderer> ().material = color4;
					if(map [x, y]-100==5)newCrate.GetComponent<Renderer> ().material = color5;
					if(map [x, y]-100==6)newCrate.GetComponent<Renderer> ().material = color6;
					if(map [x, y]-100==7)newCrate.GetComponent<Renderer> ().material = color7;
					Crates.Add (newCrate);
				}else if (map [x, y] >= 111&&map [x, y] <= 117) {
					GameObject newButton = Instantiate (button, new Vector3 (y, 0.5f, size - x - 1), new Quaternion ());
					if(map [x, y]-110==1)newButton.GetComponent<Renderer> ().material = color1;
					if(map [x, y]-110==2)newButton.GetComponent<Renderer> ().material = color2;
					if(map [x, y]-110==3)newButton.GetComponent<Renderer> ().material = color3;
					if(map [x, y]-110==4)newButton.GetComponent<Renderer> ().material = color4;
					if(map [x, y]-110==5)newButton.GetComponent<Renderer> ().material = color5;
					if(map [x, y]-110==6)newButton.GetComponent<Renderer> ().material = color6;
					if(map [x, y]-110==7)newButton.GetComponent<Renderer> ().material = color7;
					Buttons.Add (newButton);
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
		foreach (GameObject i in Crates) {
			if (i.transform.position == new Vector3 (x, 0.75f, z)) {
				return i;
			}
		}
		return null;
	}

	public static bool isButton(float x, float z){
		foreach(GameObject i in Buttons){
			if (i.transform.position == new Vector3 (x, 0.5f, z)) {
				return true;
			}
		}
		return false;
	}
	public static GameObject getButton(float x, float z){
		foreach (GameObject i in Buttons) {
			if (i.transform.position == new Vector3 (x, 0.5f, z)) {
				return i;
			}
		}
		return null;
	}
	public static void triggerButton(float x, float z){
		foreach (Vector4 i in Group) {
			if (i.w == 2 && i.y == x && i.z == z) {
				foreach (Vector4 j in Group) {
					if (i.x == j.x && j.w == 0f) {
						MoveDown ((int)j.y, (int)j.z);
					} else if (i.x == j.x && j.w == 1f) {
						MoveUp ((int)j.y, (int)j.z);
					}
				}
			}
		}
	}
	public static void nextMap(){
		json.maps.Remove(maps[0]);
		maps.Remove (maps[0]);
		nextMapb = true;
	}
}