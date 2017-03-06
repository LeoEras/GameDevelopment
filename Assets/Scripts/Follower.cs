using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour {
	private Vector3 pos;
	private GameObject player;

	// Use this for initialization
	void Start () {
		pos = this.transform.position;
		player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (pos);
		this.transform.position = player.transform.position + pos;
	}
}
