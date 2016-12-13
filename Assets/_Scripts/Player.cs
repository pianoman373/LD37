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
	public Map map;
	public float rotationSpeed;

	public static bool frezze = true;

	private bool moving = false;
	private float rotation = 0;
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

	public Vector2 getLook() {
		if (way == "+x")
			return new Vector2 (x + 1, z);

		if (way == "-x")
			return new Vector2 (x - 1, z);

		if (way == "-z")
			return new Vector2 (x, z - 1);

		if (way == "+z")
			return new Vector2 (x, z + 1);

		return new Vector2 (x, z);
	}

	private void moveToRotation (float angle) {
		player2.transform.rotation = Quaternion.RotateTowards (player2.transform.rotation, Quaternion.Euler (0, angle, 0), rotationSpeed * Time.deltaTime);
	}
	
	// Update is called once per frame
	void Update () {
		//zoom
		Camera.transform.localPosition += new Vector3 (0, 0, Input.GetAxis ("Mouse ScrollWheel")) * camSpeed * Time.deltaTime;
		Camera.transform.LookAt (player2.transform.position);
		Camera.transform.localRotation = new Quaternion (0, 0, 0, 0);

		AudioSource audio = this.GetComponent<AudioSource> ();

		//set animation
		if (moving) {

			if (!audio.isPlaying)
				audio.Play (0);

			player2.GetComponent<Animator> ().SetFloat ("walking", 1.0f);
		} else {
			if (audio.isPlaying)
				audio.Stop ();

			player2.GetComponent<Animator> ().SetFloat ("walking", 0.0f);
		}

		Vector2 look = getLook ();

		if (Map.isCrate (look.x, look.y)) {
			player2.GetComponent<Animator> ().SetBool ("arms-up", true);
		} else {
			player2.GetComponent<Animator> ().SetBool ("arms-up", false);
		}

		// move tiles
		if (moving && !frezze) {
			bool pushingCrateFalse = false;
			if (way == "+x") {
				transform.position += new Vector3 (1, 0, 0) * speed * Time.deltaTime;
				if (transform.position.x > x) {
					if (Input.GetAxis ("Horizontal") == 0||!canMove ("+x")) {
						transform.position = new Vector3 (x, transform.position.y, transform.position.z);
						pushingCrateFalse = true;
					}
					moving = false;
				}
			} else if (way == "-x") {
				transform.position += new Vector3 (-1, 0, 0) * speed * Time.deltaTime;
				if (transform.position.x < x) {
					if (Input.GetAxis ("Horizontal") == 0||!canMove ("-x")) {
						transform.position = new Vector3 (x, transform.position.y, transform.position.z);
						pushingCrateFalse = true;
					}
					moving = false;
				}
			} else if (way == "+z") {
				transform.position += new Vector3 (0, 0, 1) * speed * Time.deltaTime;
				if (transform.position.z > z) {
					if (Input.GetAxis ("Vertical") == 0||!canMove ("+z")) {
						transform.position = new Vector3 (transform.position.x, transform.position.y, z);
						pushingCrateFalse = true;
					}
					moving = false;
				}
			} else if (way == "-z") {
				transform.position += new Vector3 (0, 0, -1) * speed * Time.deltaTime;
				if (transform.position.z < z) {
					if (Input.GetAxis ("Vertical") == 0||!canMove ("-z")) {
						transform.position = new Vector3 (transform.position.x, transform.position.y, z);
						pushingCrateFalse = true;
					}
					moving = false;
				}
			}
			if (pushingCrate) {
				if (way == "+x") {
					crate.transform.position = this.transform.position + new Vector3 (1, 0, 0) - new Vector3 (0, .25f, 0);
					tiggerButton (x + 1, z);
					unTiggerButton (x, z);
				} else if (way == "-x") {
					crate.transform.position = this.transform.position - new Vector3 (1, 0, 0)- new Vector3 (0, .25f, 0);
					tiggerButton (x - 1, z);
					unTiggerButton (x, z);
				} else if (way == "+z") {
					crate.transform.position = this.transform.position + new Vector3 (0, 0, 1)- new Vector3 (0, .25f, 0);
					tiggerButton (x, z + 1);
					unTiggerButton (x, z);
				} else if (way == "-z") {
					crate.transform.position = this.transform.position - new Vector3 (0, 0, 1)- new Vector3 (0, .25f, 0);
					tiggerButton (x, z - 1);
					unTiggerButton (x, z);

				}
			}
			if (pushingCrateFalse) {
				pushingCrate = false;
			}
		} 
		if (!moving&&!frezze) {
			if (Input.GetAxis ("Horizontal") > 0 && canMove ("+x")) {
				way = "+x";
				x += 1;
				moving = true;

				rotation = 90;

			} else if (Input.GetAxis ("Horizontal") < 0 && canMove ("-x")) {
				way = "-x";
				x -= 1;
				moving = true;

				rotation = -90;

			} else if (Input.GetAxis ("Vertical") > 0 && canMove ("+z")) {
				way = "+z";
				z += 1;
				moving = true;

				rotation = 0;

			} else if (Input.GetAxis ("Vertical") < 0 && canMove ("-z")) {
				way = "-z";
				z -= 1;
				moving = true;

				rotation = 180;
			}
		}

		moveToRotation (rotation);
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

	void unTiggerButton(int x, int z){ //if any
		if (Map.isButton (x, z)) {
			GameObject button = Map.getButton (x, z);
			if (button.GetComponent<Renderer> ().material.name == crate.GetComponent<Renderer> ().material.name) {
				Map.unTriggerButton (x, z);
			}
		}
	}
	void tiggerButton(int x, int z){ //if any
		if (Map.isButton (x, z)) {
			GameObject button = Map.getButton (x, z);
			if (button.GetComponent<Renderer> ().material.name == crate.GetComponent<Renderer> ().material.name) {
				map.triggerButton (x, z);
			}
		}
	}
}