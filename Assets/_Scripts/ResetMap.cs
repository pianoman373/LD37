using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ResetMap : MonoBehaviour {

	public static bool canReset = false;
	
	// Update is called once per frame
	void Update () {
		if (canReset&&Input.GetKeyDown(KeyCode.Space)){
			SceneManager.LoadScene (1);
		}
	}
}
