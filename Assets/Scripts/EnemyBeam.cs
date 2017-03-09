using UnityEngine;
using System.Collections;

public class EnemyBeam : MonoBehaviour {

	private PlayerController player;
	public string enemyName;
	public float speed;
	private Rigidbody2D rb;
	private EnemyHealthManager enemy;
	public GameObject impactEffect;
	public int damage;
	public float activeTime;

	void Awake () {
		if (enemyName == "Boss 1" || enemyName == "SuperBoss") {
			AudioManager.Main.PlayNewSound ("boss_beam");
		}
	}
	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ();
		enemy = FindObjectOfType<EnemyHealthManager> ();

		if (player.transform.position.x < transform.position.x) {
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
		if (other.tag == "Player") {
			Instantiate (impactEffect, transform.position, transform.rotation);
		} else if (other.tag == "Ground") {
			AudioManager.Main.PlayNewSound ("wall_hit");
			Instantiate (impactEffect, transform.position, transform.rotation);
			Destroy (gameObject);
		}
	}
}
