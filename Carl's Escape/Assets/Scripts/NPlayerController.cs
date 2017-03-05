using UnityEngine;
using System.Collections;

public class NPlayerController : MonoBehaviour {
	public float moveSpeed;
	private Animator anim;
	private bool playerMoving;
	public Vector2 lastMove;
	private Rigidbody2D myRB;
	public bool canMove;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		myRB = GetComponent<Rigidbody2D> ();

		canMove = true;
	}

	// Update is called once per frame
	void Update () {
		float moveHorizontal = Input.GetAxisRaw("Horizontal");
		float moveVertical = Input.GetAxisRaw("Vertical");
		playerMoving = false;

		if(!canMove){
			myRB.velocity = Vector2.zero;
			return;
		}

		if (moveHorizontal != 0 || moveVertical != 0) {
			myRB.velocity = new Vector2 (moveHorizontal, moveVertical) * moveSpeed;
			playerMoving = true;
			lastMove = new Vector2 (moveHorizontal, moveVertical);
		} else {
			myRB.velocity = new Vector2 (0, 0);
		}

		anim.SetFloat ("MoveX", moveHorizontal);
		anim.SetFloat ("MoveY", moveVertical);
		anim.SetBool ("PlayerMoving", playerMoving);
		anim.SetFloat ("LastMoveX", lastMove.x);
		anim.SetFloat ("LastMoveY", lastMove.y);
	}
}
