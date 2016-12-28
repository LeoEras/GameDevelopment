using UnityEngine;
using System.Collections;

public class FallDamage : MonoBehaviour {
	public float damage = 100f;
	GameObject player;
	PlayerHealth health;


	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		health = player.GetComponent<PlayerHealth> ();

	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.CompareTag("Player")) {
			health.decreaseHealth (damage);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
