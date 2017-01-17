using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	private Animator anim;
	private bool playerMoving;
	public Vector2 lastMove;
	private Rigidbody2D myRB;
	private static bool playerExists;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		myRB = GetComponent<Rigidbody2D> ();

		if (!playerExists) {
			playerExists = true;
			DontDestroyOnLoad (transform.gameObject);
		} 
		else {
			Destroy (gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		float moveHorizontal = Input.GetAxisRaw("Horizontal");
		float moveVertical = Input.GetAxisRaw("Vertical");
		playerMoving = false;

		if (moveHorizontal != 0 || moveVertical != 0) {
			//Vector3 movement = new Vector3 (moveHorizontal, moveVertical, 0);
			myRB.velocity = new Vector2 (moveHorizontal, moveVertical) * moveSpeed;
			//transform.Translate (movement * moveSpeed * Time.deltaTime);

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
