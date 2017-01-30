using UnityEngine;
using System.Collections;

public class Admin : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Mouse1)) {
			Application.LoadLevel ("StageSelect");
		}
	}
}
