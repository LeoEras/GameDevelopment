using UnityEngine;
using System.Collections;

public class ZombieController : MonoBehaviour {
	public float moveSpeed;
	private Rigidbody2D rb;
	private bool moving;
	public float timeBetweenMove;
	private float timeBetweenMoveCount;
	public float timeToMove;
	private float timeToMoveCount;
	private Vector3 moveDir;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();

		timeBetweenMoveCount = timeBetweenMove;
		timeToMoveCount = timeToMove;
	}
	
	// Update is called once per frame
	void Update () {
		if (moving) {
			timeToMoveCount -= Time.deltaTime;
			rb.velocity = moveDir;
			if(timeToMoveCount < 0){
				moving = false;
				timeBetweenMoveCount = timeBetweenMove;
			}
		} 
		else {
			timeBetweenMoveCount -= Time.deltaTime;
			rb.velocity = Vector2.zero;
			if (timeBetweenMoveCount < 0) {
				moving = true;
				timeToMoveCount = timeToMove;
				moveDir = new Vector3 (Random.Range(-1f,1f)*moveSpeed, Random.Range(-1f,1f)*moveSpeed, 0);
			}
		}
	}
}
