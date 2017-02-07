using UnityEngine;
using System.Collections;

public class FacePlayer : MonoBehaviour {

	public PlayerController player;
	float xScale;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ();
		xScale = transform.localScale.x;
	}
	
	// Update is called once per frame
	void Update () {
		if (player != null) {
			if (player.transform.position.x > transform.position.x) {
				transform.localScale = new Vector3 (-1f, 1f, 1f);
			} else if (player.transform.position.x < transform.position.x) {
				transform.localScale = new Vector3 (1f, 1f, 1f);
			}
		}
	}
}
