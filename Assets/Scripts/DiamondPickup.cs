using UnityEngine;
using System.Collections;

public class DiamondPickup : MonoBehaviour {

	public bool picked;
	private Vector3 diamondPosition;
	private GameObject diamondCounter;
	private Color diamondColor;
	private Material diamondMaterial;

	void Start () {
		picked = false;
		diamondCounter = GameObject.Find ("DiamondPosition");
	}

	void Update () {
		if (picked) {
			gameObject.GetComponent<CircleCollider2D> ().enabled = false;
			diamondPosition = Camera.main.ScreenToWorldPoint (diamondCounter.transform.position);
			transform.position = Vector3.Lerp(transform.position, diamondPosition, 5f * Time.deltaTime);
			if (Vector3.Distance (transform.position, diamondPosition) < 0.2) {
				Destroy (gameObject);
			}
		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.GetComponent<PlayerController> () == null)
			return;
		gameObject.GetComponent<CircleCollider2D> ().enabled = false;
		AudioManager.Main.PlayNewSound ("diamond_pick");
		LevelManager.PickCrystal ();
		picked = true;
	}
}
