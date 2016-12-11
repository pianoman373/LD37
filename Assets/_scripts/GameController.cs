using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameController : MonoBehaviour {
	// Use this for initialization
	public GameObject prefab;
	public int size;//max is 20 for now
	public float speed;

	public static GameObject[,] floor = new GameObject[20,20];
	public static bool[,] up = new bool[20, 20];
	public static List<Vector2> moveDown = new List<Vector2>();
	public static List<Vector2> moveUp = new List<Vector2>();

    private int[,] map = new int[10, 10]
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
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
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
			Instantiate (prefab, new Vector3 (-1, .9f, z - 1), new Quaternion (-0.707f,0,0,0.707f));
		}

		//right wall
		for (int z = 0; z < size + 2; z++) {
			Instantiate (prefab, new Vector3 (size, .9f, z - 1), new Quaternion (-0.707f,0,0,0.707f));
		}

		//top wall
		for (int x = 0; x < size; x++) {
			Instantiate (prefab, new Vector3 (x, .9f, -1), new Quaternion (-0.707f,0,0,0.707f));
		}

		//bottom wall
		for (int x = 0; x < size; x++) {
			Instantiate (prefab, new Vector3 (x, .9f, size), new Quaternion (-0.707f,0,0,0.707f));
		}

        for (int x = 0; x < 10; x++)
        {
            for (int j = 0; j < 10; j++)
            {
                if (map[x, j] == 1)
                {
                    MoveUp(x, j);
                }
            }
        }
    }

	public void MoveUp(int x, int z){
		moveUp.Add (new Vector2 (x,z));
	}

	public void MoveDown(int x, int z){
		moveDown.Add (new Vector2 (x,z));
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
			if (i.y == 1) {
				print ("remved");
				moveUp.Remove (i);
			}
		}

		foreach (Vector2 i in moveDown) {
			y = floor [(int)i.x, (int)i.y].transform.position.y;
			if (y - (speed * Time.deltaTime) < 0) {
				y = 0;
			} else {
				y -= (speed * Time.deltaTime);
			}
			floor [(int)i.x, (int)i.y].transform.position = new Vector3(i.x, y, i.y);
			print (y);
			print (floor [(int)i.x, (int)i.y].transform.position);
			if (i.y == 1) {
				print ("remved");
				moveUp.Remove (i);
			}
		}
	}
}