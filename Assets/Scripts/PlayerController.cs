using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	private int vertical = 0;
	private int horizontal = 0;
	private Rigidbody2D rb;	
	private Animator animator;
	public int facing_direction;
	public float speed;
	public static int lives = 3;
	public static bool pause = false;
	public static Vector3 original_position;
	public static int score = 0;


	// Use this for initialization
	void Start(){
		original_position = this.transform.position;
		rb = GetComponent<Rigidbody2D> ();
		animator = this.GetComponent<Animator>();
		animator.SetInteger("direction", facing_direction);
	}

	void Move(bool pause){
		if (pause) {
			Time.timeScale = 0;
		} else {
			Time.timeScale = 1;
			if (Input.GetKey (KeyCode.RightArrow)) {
				horizontal = 1;
			} else if (Input.GetKey (KeyCode.LeftArrow)) {
				horizontal = -1;
			} else {
				horizontal = 0;
				rb.velocity = Vector3.zero;
				rb.angularVelocity = 0.0f; 
			}

			if (Input.GetKey (KeyCode.UpArrow)) {
				vertical = 1;
			} else if (Input.GetKey (KeyCode.DownArrow)) {
				vertical = -1;
			} else {
				vertical = 0;
				rb.velocity = Vector3.zero;
				rb.angularVelocity = 0.0f; 
			}

			if (horizontal != 0 && vertical != 0){
				rb.velocity = Vector3.zero;
				rb.angularVelocity = 0.0f;
			}

			rb.AddForce (new Vector2(speed * horizontal, speed * vertical));

			if (vertical > 0) {
				animator.SetInteger("direction", 0);
			}
			else if (vertical < 0) {
				animator.SetInteger("direction", 2);
			}
			else if (horizontal > 0) {
				animator.SetInteger("direction", 1);
			}
			else if (horizontal < 0) {
				animator.SetInteger("direction", 3);
			}

			if (vertical != 0 || horizontal != 0) {
				animator.SetBool ("is_moving", true);
			} else {
				animator.SetBool ("is_moving", false);
			}
		}
	}

	void Pause(){
		if (Input.GetKeyDown(KeyCode.Escape)){
			pause = !pause;
		}
	}

	// Update is called once per frame
	void Update () {
		Pause ();
		Move (pause);
	}
}
