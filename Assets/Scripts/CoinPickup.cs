using UnityEngine;
using System.Collections;

public class CoinPickup : MonoBehaviour {

	public int pointsToAdd;

	void OnTriggerEnter2D (Collider2D other) {
		if (other.GetComponent<PlayerController> () == null)
			return;
		AudioManager.Main.PlayNewSound ("coin");
		ScoreManager.AddPoints (pointsToAdd);
		LevelManager.CrystalPicked ();
		Destroy (gameObject);
	}
}
