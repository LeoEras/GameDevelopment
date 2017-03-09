using UnityEngine;
using System.Collections;

public class EnemyBeamFollow : MonoBehaviour {

	private PlayerController player;
	public string enemyName;
	public float speed;
	private Rigidbody2D rb;
	private EnemyHealthManager enemy;
	public GameObject impactEffect;
	public int damage;
	public float activeTime;
	private float playerY;
	private Rigidbody2D playerRB;
	private Vector2 direction;

	void Awake () {
		player = FindObjectOfType<PlayerController> ();
		playerRB = player.GetComponent<Rigidbody2D> ();
		playerY = playerRB.position.y;
		direction = playerRB.transform.position - transform.position;
		direction.Normalize ();
		if (enemyName == "SuperBoss") {
			AudioManager.Main.PlayNewSound ("boss_beam");
		}
	}
	// Use this for initialization
	void Start () {
		enemy = FindObjectOfType<EnemyHealthManager> ();
		/*
		if (player.transform.position.x < transform.position.x) {
			speed = -speed;
		}*/
	}

	// Update is called once per frame
	void Update () {
		rb = GetComponent<Rigidbody2D> ();
		rb.velocity = direction * speed;
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
