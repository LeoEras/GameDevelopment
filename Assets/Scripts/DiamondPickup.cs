using UnityEngine;
using System.Collections;

public class DiamondPickup : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D other) {
		if (other.GetComponent<PlayerController> () == null)
			return;
		AudioManager.Main.PlayNewSound ("diamond_pick");
		LevelManager.PickCrystal ();
		Destroy (gameObject);
	}
}
