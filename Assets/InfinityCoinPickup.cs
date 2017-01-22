using UnityEngine;
using System.Collections;

public class InfinityCoinPickup : MonoBehaviour {

	public GameObject infinityBeam;
	private PlayerController player;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.GetComponent<PlayerController> () == null)
			return;
		player.moveSpeed = 8;
		player.jumpHeight = 16;
		player.shotDelay = 0.075f;
		player.shootingObjet = infinityBeam;
		Destroy (gameObject);
	}
}
