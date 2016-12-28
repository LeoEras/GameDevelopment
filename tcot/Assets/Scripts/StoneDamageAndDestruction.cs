using UnityEngine;
using System.Collections;

public class StoneDamageAndDestruction : MonoBehaviour {
	public float fallDamage = 20f;
	GameObject player;
	PlayerHealth health;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		health = player.GetComponent<PlayerHealth> ();
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.CompareTag ("Player")) {
			health.decreaseHealth (fallDamage);
			Destroy (this.gameObject);
		} else if (other.gameObject.CompareTag ("wall")) {
			Destroy (this.gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
