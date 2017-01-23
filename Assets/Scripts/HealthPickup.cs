using UnityEngine;
using System.Collections;

public class HealthPickup : MonoBehaviour {

	public int healthToGive;

	void OnTriggerEnter2D (Collider2D other) {
		if (other.GetComponent<PlayerController> () == null)
			return;
		if (healthToGive <= 20) {
			AudioManager.Main.PlayNewSound ("health20");
		} else if (healthToGive > 20 && healthToGive <= 40) {
			AudioManager.Main.PlayNewSound ("health40");
		} else if (healthToGive > 40 && healthToGive <= 60) {
			AudioManager.Main.PlayNewSound ("health60");
		} else if (healthToGive > 60 && healthToGive <= 100) {
			AudioManager.Main.PlayNewSound ("health100");
		}

		HealthManager.InflictDamage (-healthToGive);
		Destroy (gameObject);
	}
}
