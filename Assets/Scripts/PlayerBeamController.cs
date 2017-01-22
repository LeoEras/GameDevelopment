using UnityEngine;
using System.Collections;

public class PlayerBeamController : MonoBehaviour {

	public float speed;
	private Rigidbody2D rb;
	private PlayerController player;
	public GameObject impactEffect;
	public int damage;
	public float activeTime;

	void Awake () {
		AudioManager.Main.PlayNewSound ("player_beam");
	}
	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ();

		if (player.transform.localScale.x < 0) {
			speed = -speed;
		}
	}
	
	// Update is called once per frame
	void Update () {
		rb = GetComponent<Rigidbody2D> ();
		rb.velocity = new Vector2 (speed, rb.velocity.y);
		Destroy (gameObject, activeTime);
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.tag == "Enemy") {
			Instantiate (impactEffect, transform.position, transform.rotation);
			other.GetComponent<EnemyHealthManager>().InflictDamage(damage);
		} else if (other.tag == "Ground") {
			AudioManager.Main.PlayNewSound ("wall_hit");
			Instantiate (impactEffect, transform.position, transform.rotation);
		}
		Destroy (gameObject);
	}
}
