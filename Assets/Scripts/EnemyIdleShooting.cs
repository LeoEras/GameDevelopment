using UnityEngine;
using System.Collections;

public class EnemyIdleShooting : MonoBehaviour {

	private Rigidbody2D rb;
	public float playerRange;
	public GameObject enemyBeam;
	public PlayerController player;
	public Transform rangePoint;
	public Transform firePoint;
	public float shotDelay;
	private float shotCounter;
	private float tempSpeed;
	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D> ();
		player = FindObjectOfType<PlayerController> ();
		shotCounter = shotDelay;
	}
	
	// Update is called once per frame
	void Update () {
		shotCounter -= Time.deltaTime;
		anim.SetFloat ("Speed", Mathf.Abs(rb.velocity.x));

		if ((transform.localScale.x < 0 && player.transform.position.x > rangePoint.position.x && player.transform.position.x < rangePoint.position.x + playerRange) || (transform.localScale.x > 0 && player.transform.position.x < rangePoint.position.x && player.transform.position.x > rangePoint.position.x - playerRange)) {
			anim.SetBool ("Shooting", true);
		} else {
			anim.SetBool ("Shooting", false);
		}

		if (transform.localScale.x < 0 && player.transform.position.x > rangePoint.position.x && player.transform.position.x < rangePoint.position.x + playerRange && shotCounter < 0) {
			Instantiate (enemyBeam, firePoint.position, enemyBeam.transform.rotation);
			shotCounter = shotDelay;
		}
		if (transform.localScale.x > 0 && player.transform.position.x < rangePoint.position.x && player.transform.position.x > rangePoint.position.x - playerRange && shotCounter < 0) {
			Instantiate (enemyBeam, firePoint.position, enemyBeam.transform.rotation);
			shotCounter = shotDelay;
		}
	}
}
