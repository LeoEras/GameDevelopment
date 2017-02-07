using UnityEngine;
using System.Collections;

public class CoinPickup : MonoBehaviour {

	public int pointsToAdd;
	public bool picked;
	private Vector3 scorePosition;
	private GameObject scoreCounter;

	void Start () {
		picked = false;
		scoreCounter = GameObject.Find ("ScorePosition");
	}

	void Update () {
		if (picked) {
			gameObject.GetComponent<CircleCollider2D> ().enabled = false;
			scorePosition = Camera.main.ScreenToWorldPoint (scoreCounter.transform.position);
			transform.position = Vector3.Lerp(transform.position, scorePosition, 5f * Time.deltaTime);
			if (Vector3.Distance (transform.position, scorePosition) < 0.2) {
				Destroy (gameObject);
			}
		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.GetComponent<PlayerController> () == null)
			return;
		gameObject.GetComponent<CircleCollider2D> ().enabled = false;
		AudioManager.Main.PlayNewSound ("coin");
		ScoreManager.AddPoints (pointsToAdd);
		picked = true;
	}
}
