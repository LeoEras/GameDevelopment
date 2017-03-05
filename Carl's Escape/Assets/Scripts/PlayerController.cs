using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	private Animator anim;
	private bool playerMoving;
	public Vector2 lastMove;
	private Rigidbody2D myRB;
	private static bool playerExists;
	public string startPoint;
	private bool doorFound;
	private GameObject door;
	private bool attacking;
	public float attackTime;
	private float attackTimeCount;
	public bool canMove;
	public ArrayList items;
	public ArrayList weapons;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		myRB = GetComponent<Rigidbody2D> ();
		canMove = true;

		//items = new Hashtable ();
		items = new ArrayList();
		items.Add ("Llave de celda C1");

		//weapons = new Hashtable ();
		weapons = new ArrayList();
		weapons.Add ("Bate");

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

		if(!canMove){
			myRB.velocity = Vector2.zero;
			return;
		}

		if(!attacking){
			if (moveHorizontal != 0 || moveVertical != 0) {
				myRB.velocity = new Vector2 (moveHorizontal, moveVertical) * moveSpeed;

				playerMoving = true;
				lastMove = new Vector2 (moveHorizontal, moveVertical);
			} else {
				myRB.velocity = new Vector2 (0, 0);
			}

			if(Input.GetKeyDown(KeyCode.X)){
				attackTimeCount = attackTime;
				attacking = true;
				myRB.velocity = Vector2.zero;
				anim.SetBool ("Attack", true);
			}
		}

		if(attackTimeCount > 0){
			attackTimeCount -= Time.deltaTime;
		}

		if (attackTimeCount <= 0) {
			attacking = false;
			anim.SetBool ("Attack", false);
		}
			
		anim.SetFloat ("MoveX", moveHorizontal);
		anim.SetFloat ("MoveY", moveVertical);
		anim.SetBool ("PlayerMoving", playerMoving);
		anim.SetFloat ("LastMoveX", lastMove.x);
		anim.SetFloat ("LastMoveY", lastMove.y);
	}
		
}
