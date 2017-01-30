using UnityEngine;
using System.Collections;

public class RotateAround : MonoBehaviour {
	public float speed;
	public GameObject center;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.RotateAround (center.transform.position, Vector3.back, speed);
	}
}
