using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public float speed;
	public float camSpeed;

	public static int x = 0;
	public static int z = 0;
	public GameObject Camera;
	public GameObject player2;

	public static bool frezze = true;

	private bool moving = false;
	private string way;
	private bool pushingCrate = false;
	private GameObject crate;
	// Use this for initialization
	void Start () {
		transform.position = new Vector3 (x, 1, z);
		Camera.transform.LookAt (player2.transform.position);
	}
	public static void setPos(int x2, int z2){
		x = x2;
		z = z2;
	}
	
	// Update is called once per frame
	void Update () {
		//zoom
		Camera.transform.localPosition += new Vector3 (0, 0, Input.GetAxis ("Mouse ScrollWheel")) * camSpeed * Time.deltaTime;
		Camera.transform.LookAt (player2.transform.position);
		Camera.transform.localRotation = new Quaternion (0, 0, 0, 0);
		// move tiles
		if (moving && !frezze) {
			if (pushingCrate) {
				if (way == "+x") {
					crate.transform.position += new Vector3 (1, 0, 0) * speed * Time.deltaTime;
					if (crate.transform.position.x > x + 1) {
						crate.transform.position = new Vector3 (x + 1, crate.transform.position.y, crate.transform.position.z);
						tiggerButton (x + 1, z);
					}
				} else if (way == "-x") {
					crate.transform.position += new Vector3 (-1, 0, 0) * speed * Time.deltaTime;
					if (crate.transform.position.x < x - 1) {
						crate.transform.position = new Vector3 (x - 1, crate.transform.position.y, crate.transform.position.z);
						tiggerButton (x - 1, z);
					}
				} else if (way == "+z") {
					crate.transform.position += new Vector3 (0, 0, 1) * speed * Time.deltaTime;
					if (crate.transform.position.z > z + 1) {
						crate.transform.position = new Vector3 (crate.transform.position.x, crate.transform.position.y, z + 1);
						tiggerButton (x, z + 1);
					}
				} else if (way == "-z") {
					crate.transform.position += new Vector3 (0, 0, -1) * speed * Time.deltaTime;
					if (crate.transform.position.z < z - 1) {
						crate.transform.position = new Vector3 (crate.transform.position.x, crate.transform.position.y, z - 1);
						tiggerButton (x, z - 1);
					}

				}
			}
			if (way == "+x") {
				transform.position += new Vector3 (1, 0, 0) * speed * Time.deltaTime;
				if (transform.position.x > x) {
					transform.position = new Vector3 (x, transform.position.y, transform.position.z);
					moving = false;
					pushingCrate = false;
				}
			} else if (way == "-x") {
				transform.position += new Vector3 (-1, 0, 0) * speed * Time.deltaTime;
				if (transform.position.x < x) {
					transform.position = new Vector3 (x, transform.position.y, transform.position.z);
					moving = false;
					pushingCrate = false;
				}
			} else if (way == "+z") {
				transform.position += new Vector3 (0, 0, 1) * speed * Time.deltaTime;
				if (transform.position.z > z) {
					transform.position = new Vector3 (transform.position.x, transform.position.y, z);
					moving = false;
					pushingCrate = false;
				}
			} else if (way == "-z") {
				transform.position += new Vector3 (0, 0, -1) * speed * Time.deltaTime;
				if (transform.position.z < z) {
					transform.position = new Vector3 (transform.position.x, transform.position.y, z);
					moving = false;
					pushingCrate = false;
				}
			}
		} else if (!frezze) {
			if (Input.GetAxis ("Horizontal") > 0 && canMove ("+x")) {
				way = "+x";
				x += 1;
				moving = true;

				player2.transform.rotation = Quaternion.Euler (0, -90, 0);

			} else if (Input.GetAxis ("Horizontal") < 0 && canMove ("-x")) {
				way = "-x";
				x -= 1;
				moving = true;

				player2.transform.rotation = Quaternion.Euler (0, 90, 0);

			} else if (Input.GetAxis ("Vertical") > 0 && canMove ("+z")) {
				way = "+z";
				z += 1;
				moving = true;

				player2.transform.rotation = Quaternion.Euler (0, 0, 0);

			} else if (Input.GetAxis ("Vertical") < 0 && canMove ("-z")) {
				way = "-z";
				z -= 1;
				moving = true;

				player2.transform.rotation = Quaternion.Euler (0, 180, 0);
			}
		}
	}
	bool canMove(string way){
		if (way == "+x" && !Map.isblock (x + 1, z)) {
			if (Map.isCrate (x + 1, z)) {
				if (Map.isCrate (x + 2, z) || Map.isblock (x + 2, z)) {
					return false;
				}
				crate = Map.getCrate (x + 1, z);
				pushingCrate = true;
			}
			return true;
		} else if (way == "-x" && !Map.isblock (x - 1, z)) {
			if (Map.isCrate (x - 1, z)) {
				if (Map.isCrate (x - 2, z) || Map.isblock (x - 2, z)) {
					return false;
				}
				crate = Map.getCrate (x - 1, z);
				pushingCrate = true;
			}
			return true;
		} else if (way == "-z" && !Map.isblock (x, z - 1)) {
			if (Map.isCrate (x, z - 1)) {
				if (Map.isCrate (x, z - 2) || Map.isblock (x, z - 2)) {
					return false;
				}
				crate = Map.getCrate (x, z - 1);
				pushingCrate = true;
			}
			return true;
		} else if (way == "+z" && !Map.isblock (x, z + 1)) {
			if (Map.isCrate (x, z + 1)) {
				if (Map.isCrate (x, z + 2) || Map.isblock (x, z + 2)) {
					return false;
				}
				crate = Map.getCrate (x, z + 1);
				pushingCrate = true;
			}
			return true;
		}	
		return false;
	}

	void tiggerButton(int x, int z){ //if any
		if (Map.isButton (x, z)) {
			GameObject button = Map.getButton (x, z);
			if (button.GetComponent<Renderer> ().material.name == crate.GetComponent<Renderer> ().material.name) {
				Map.triggerButton (x, z);
			}
		}
	}
}