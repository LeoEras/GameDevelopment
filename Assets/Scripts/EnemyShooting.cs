using UnityEngine;
using System.Collections;

public class EnemyShooting : MonoBehaviour {

	private EnemyPatrol patrol;
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
		patrol = GetComponent<EnemyPatrol> ();
		rb = GetComponent<Rigidbody2D> ();
		tempSpeed = patrol.moveSpeed;
		player = FindObjectOfType<PlayerController> ();
		shotCounter = shotDelay;
	}
	
	// Update is called once per frame
	void Update () {
		shotCounter -= Time.deltaTime;
		anim.SetFloat ("Speed", Mathf.Abs(rb.velocity.x));

		if ((transform.localScale.x < 0 && player.transform.position.x > rangePoint.position.x && player.transform.position.x < rangePoint.position.x + playerRange) || (transform.localScale.x > 0 && player.transform.position.x < rangePoint.position.x && player.transform.position.x > rangePoint.position.x - playerRange)) {
			anim.SetBool ("Shooting", true);
			patrol.moveSpeed = 0;
		} else {
			anim.SetBool ("Shooting", false);
			patrol.moveSpeed = tempSpeed;
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
