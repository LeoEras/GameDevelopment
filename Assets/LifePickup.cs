using UnityEngine;
using System.Collections;

public class LifePickup : MonoBehaviour {

	private LifeManager lifeManager;

	void Start () {
		lifeManager = FindObjectOfType<LifeManager> ();
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.GetComponent<PlayerController> () == null)
			return;
		AudioManager.Main.PlayNewSound ("life");
		lifeManager.GiveLife ();
		Destroy (gameObject);
	}
}
