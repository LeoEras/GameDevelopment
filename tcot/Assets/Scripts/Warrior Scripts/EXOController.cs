using UnityEngine;
using System.Collections;

public class EXOController : MonoBehaviour {
	public float maxSpeed = 3f;
	public bool facingLeft = true;
	private Rigidbody2D rigid;
	public Animator anim;
	public bool grounded = true;
	public float jumpForce = 500f;
	float move;
	public bool moveLeft = true;
	public bool moveRight = true;
	bool isAttacking = false;
	public float attackTime = 0.6f;
	// Use this for initialization
	void Start () {
		rigid = this.gameObject.GetComponent<Rigidbody2D> ();
		anim = this.gameObject.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {


		anim.SetBool ("Ground", grounded);

		anim.SetFloat ("vSpeed", rigid.velocity.y);
	

		//float move = Input.GetAxis ("Horizontal");

		//anim.SetFloat ("speed", Mathf.Abs (move));

		if (Input.GetKey (KeyCode.LeftArrow)&&moveLeft) {
			rigid.velocity = new Vector2 (-maxSpeed, rigid.velocity.y);
			move = -maxSpeed;
			anim.SetFloat ("speed", Mathf.Abs (move));
		} else if (Input.GetKey (KeyCode.RightArrow)&&moveRight) {
			rigid.velocity = new Vector2 (maxSpeed, rigid.velocity.y);
			move = maxSpeed;
			anim.SetFloat ("speed", Mathf.Abs (move));
		} else {
			rigid.velocity = new Vector2 (0, rigid.velocity.y);
			anim.SetFloat ("speed", 0);
		}

		if (Input.GetKey (KeyCode.X)&&grounded&&isAttacking==false) {
			isAttacking = true;
			moveLeft = false;
			moveRight = false;
			anim.SetBool ("attacking", isAttacking);
			Invoke ("stopAttack", attackTime);
		}

		if (move > 0 && facingLeft) {
			Flip ();
		} else if (move < 0 && !facingLeft) {
			Flip ();
		}
	}

	void Update () {
		if (grounded && Input.GetKeyDown (KeyCode.Z)) {

			anim.SetBool ("Ground", false);
			rigid.AddForce(new Vector2 (0, jumpForce));
		}

	}

	void Flip (){
		facingLeft = !facingLeft;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	public void canMoveLeft (bool canI){
		moveLeft = canI;
	}

	public void canMoveRight (bool canI){
		moveRight = canI;
	}

	public void isGrounded (bool isIt){
		grounded = isIt;
	}

	void stopAttack (){
		moveLeft = true;
		moveRight = true;
		isAttacking = false;
		anim.SetBool ("attacking", isAttacking);
	}
}
