using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public float speed;

	public int x;
	public int z;

	private bool moving = false;
	private string way;
	// Use this for initialization
	void Start () {
		transform.position = new Vector3 (x, 1, z);
	}
	
	// Update is called once per frame
	void Update () {
		if (!moving) {
			if (Input.GetAxis ("Horizontal") > 0&&canMove("+x")) {
				way = "+x";
				x += 1;
				moving = true;
			} else if (Input.GetAxis ("Horizontal") < 0&&canMove("-x")) {
				way = "-x";
				x -= 1;
				moving = true;
			} else if (Input.GetAxis("Vertical") > 0&&canMove("+z")) {
				way = "+z";
				z += 1;
				moving = true;
			} else if (Input.GetAxis("Vertical") < 0&&canMove("-z")) {
				way = "-z";
				z -= 1;
				moving = true;
			}
		}else {				
			if (way == "+x") {
				transform.position += new Vector3(1,0,0) * speed * Time.deltaTime;
				if (transform.position.x > x) {
					transform.position = new Vector3(x,transform.position.y,transform.position.z);
					moving = false;
				}
			}else if (way == "-x") {
				transform.position += new Vector3(-1,0,0) * speed * Time.deltaTime;
				if (transform.position.x < x) {
					transform.position = new Vector3(x,transform.position.y,transform.position.z);
					moving = false;
				}
			} else if (way == "+z") {
				transform.position += new Vector3(0,0,1) * speed * Time.deltaTime;
				if (transform.position.z > z) {
					transform.position = new Vector3(transform.position.x,transform.position.y,z);
					moving = false;
				}
			}else if (way == "-z") {
				transform.position += new Vector3(0,0,-1) * speed * Time.deltaTime;
				if (transform.position.z < z) {
					transform.position = new Vector3(transform.position.x,transform.position.y,z);
					moving = false;
				}
			}

		}
	}
	bool canMove(string way){
		if (way == "+x" &&!Map.isblock (x + 1, z)) {
			if (Map.isCrate (x + 1, z)) {
				if (Map.isCrate (x + 2, z)) {
					return false;
				}
			}
			return true;
		}else if (way == "-x" &&!Map.isblock (x - 1, z)) {
			if (Map.isCrate (x - 1, z)) {
				if (Map.isCrate (x - 2, z)) {
					return false;
				}
			}
			return true;
		}else if (way == "-z" &&!Map.isblock (x, z - 1)) {
			if (Map.isCrate (x, z - 1)) {
				if (Map.isCrate (x, z - 2)) {
					return false;
				}
			}
			return true;
		}else if (way == "+z" &&!Map.isblock (x, z + 1)) {
			if (Map.isCrate (x, z + 1)) {
				if (Map.isCrate (x, z + 2)) {
					return false;
				}
			}
			return true;
		}	
		return false;
	}
}
