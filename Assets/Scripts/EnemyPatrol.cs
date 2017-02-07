using UnityEngine;
using System.Collections;

public class EnemyPatrol : MonoBehaviour {

	public float moveSpeed;
	public bool moveRight;
	public Transform wallCheckTop;
	public Transform wallCheckBottom;
	public float wallCheckRadius;
	public LayerMask whatIsWall;
	public Transform edgeCheck;
	private Animator anim;
	private Rigidbody2D rb;

	private bool hittingWall;
	private bool notAtEdge;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		hittingWall = Physics2D.OverlapArea (wallCheckTop.position, wallCheckBottom.position, whatIsWall);
		//hittingWall = Physics2D.OverlapCircle (wallCheck.position, wallCheckRadius, whatIsWall);
		notAtEdge = Physics2D.OverlapCircle (edgeCheck.position, wallCheckRadius, whatIsWall);

		if (hittingWall || !notAtEdge) {
			moveRight = !moveRight;
		}

		anim.SetFloat ("Speed", Mathf.Abs(rb.velocity.x)); 
		if (moveRight) {
			transform.localScale = new Vector3 (-1f, 1f, 1f);
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
		} else {
			transform.localScale = new Vector3 (1f, 1f, 1f);
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (-moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
		}
	}
}
