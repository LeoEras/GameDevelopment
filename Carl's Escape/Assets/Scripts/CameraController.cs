using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject followTarget;
	private Vector3 offset;
	private static bool cameraExists;

	// Use this for initialization
	void Start () {
		offset = transform.position - followTarget.transform.position;

		if (!cameraExists) {
			cameraExists = true;
			DontDestroyOnLoad (transform.gameObject);
		} 
		else {
			Destroy (gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (!followTarget) {
			followTarget = FindObjectOfType<PlayerController> ().gameObject;
		}
		transform.position = followTarget.transform.position + offset;

	}
}
