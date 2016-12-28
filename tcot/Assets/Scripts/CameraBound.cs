using UnityEngine;
using System.Collections;

public class CameraBound : MonoBehaviour {
	public FollowPlayer camera;

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.CompareTag ("bound wall")) {
			camera.mustFollow = false;
		}
	}

	void OnTriggerExit2D(Collider2D coll){
		if (coll.gameObject.CompareTag ("bound wall")) {
			camera.canMove = true;
		}
	}

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
	
	}
}
