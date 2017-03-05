using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ZombieController : MonoBehaviour {
	public float moveSpeed;
	private Rigidbody2D rb;
	private Animator anim;
	private bool moving;
	public float timeBetweenMove;
	private float timeBetweenMoveCount;
	public float timeToMove;
	private float timeToMoveCount;
	private Vector2 lastMove;
	private Vector2 moveDir;
	public float waitToReload;
	private bool reloading;
	private GameObject player;
	public bool canMove;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		canMove = true;

		timeBetweenMoveCount = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
		timeToMoveCount = Random.Range(timeToMove * 0.75f, timeBetweenMove * 1.25f);

	}
	
	// Update is called once per frame
	void Update () {
		if(!canMove){
			rb.velocity = Vector2.zero;
			return;
		}

		if (moving) {
			timeToMoveCount -= Time.deltaTime;
			rb.velocity = moveDir;
			lastMove = new Vector2 (moveDir.x, moveDir.y);
			if(timeToMoveCount < 0){
				moving = false;
				timeBetweenMoveCount = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
			}
		} 
		else {
			timeBetweenMoveCount -= Time.deltaTime;
			rb.velocity = Vector2.zero;
			if (timeBetweenMoveCount < 0) {
				moving = true;
				timeToMoveCount = Random.Range(timeToMove * 0.75f, timeBetweenMove * 1.25f);
				float moveHorizontal = Random.Range(-1f,1f);
				float moveVertical = Random.Range(-1f,1f);
				moveDir = new Vector2 (moveHorizontal, moveVertical) * moveSpeed;
			}
		}

		if (reloading) {
			waitToReload -= Time.deltaTime;
			if (waitToReload < 0) {
				//Application.LoadLevel (Application.loadedLevel);
				SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
				player.SetActive (true);
			}
		}

		anim.SetFloat ("MoveX", moveDir.x);
		anim.SetFloat ("MoveY", moveDir.y);
		anim.SetBool ("ZombieMoving", moving);
		anim.SetFloat ("LastMoveX", lastMove.x);
		anim.SetFloat ("LastMoveY", lastMove.y);

	}
		
}
