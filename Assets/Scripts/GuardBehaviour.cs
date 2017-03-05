using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GuardBehaviour : MonoBehaviour {
	public float LOS_value;
	private GameObject PlayerDetector;
	private GameObject LOS;
	private RaycastHit2D hit;
	public Transform[] WayPointList;
	private int currentWayPoint = 0;
	Transform TargetWayPoint;
	public float speed;
	private Rigidbody2D rb;
	private Animator animator;
	private int facing_direction = 0;
	private bool follow = true;
	public LayerMask focus;
	private float enabledX = 0f, enabledY = 0f;

	// Use this for initialization
	void Start () {
		if (TargetWayPoint == null) {
			TargetWayPoint = WayPointList [currentWayPoint];
		}
		animator = this.GetComponent<Animator>();
		animator.SetInteger("direction", facing_direction);
		rb = GetComponent<Rigidbody2D> ();
		PlayerDetector = transform.GetChild (0).gameObject;
		LOS = transform.GetChild (1).gameObject;
	}
		
	void FollowPath(bool enabled){
		if (enabled) {
			rb.velocity = Vector3.zero;
			rb.angularVelocity = 0.0f; 
			if (currentWayPoint < this.WayPointList.Length) {
				if (TargetWayPoint == null) {
					TargetWayPoint = WayPointList [currentWayPoint];
				}
				Vector3 dir = TargetWayPoint.position - this.transform.position;
				dir.Normalize();
				rb.AddForce (dir * speed);

				LOS.transform.position = ((TargetWayPoint.position 
					- this.transform.position).normalized
					* LOS_value) + this.transform.position;

				LOS.transform.position = new Vector3(
					LOS.transform.position.x + (10f * Mathf.Sin(Time.time * 15f) * enabledX), 
					LOS.transform.position.y + (10f * Mathf.Sin(Time.time * 15f) * enabledY), 
					LOS.transform.position.z);
				FacingController (LOS.transform);
										
				if (Vector3.Distance (transform.position, TargetWayPoint.position) < 0.03f) {
					currentWayPoint++;
					if(currentWayPoint == this.WayPointList.Length){
						currentWayPoint = 0;
					}
					TargetWayPoint = WayPointList [currentWayPoint];
				}
			}
		}
	}

	void FacingController(Transform facing){
		if (Mathf.Abs (facing.localPosition.x)
			> Mathf.Abs (facing.localPosition.y)) {
			if (facing.localPosition.x > 0) {
				enabledX = 0f;
				enabledY = 1f;
				animator.SetInteger ("direction", 1);
			} else if (facing.localPosition.x < 0) {
				enabledX = 0f;
				enabledY = 1f;
				animator.SetInteger ("direction", 3);
			}
		} else {
			if(facing.localPosition.y > 0){
				enabledX = 1f;
				enabledY = 0f;
				animator.SetInteger("direction", 0);
			} else if(facing.localPosition.y < 0){
				enabledX = 1f;
				enabledY = 0f;
				animator.SetInteger("direction", 2);
			}
		}

		animator.SetBool ("is_moving", true);
	}

	void Catch(){
		PlayerDetector.transform.RotateAround (this.transform.position, Vector3.forward, 10);
		Debug.DrawLine (this.transform.position, PlayerDetector.transform.position, Color.green);
		hit = Physics2D.Linecast(this.transform.position, PlayerDetector.transform.position);
		if (hit.collider != null) {
			if (hit.collider.name == "Player") {
				PlayerController.lives -= 1;
				hit.collider.gameObject.transform.position = PlayerController.original_position;
				this.transform.position = TargetWayPoint.position;
			}
		}
	}

	void Chase(){
		rb.velocity = Vector3.zero;
		rb.angularVelocity = 0.0f; 
		Debug.DrawLine (this.transform.position, LOS.transform.position);
		hit = Physics2D.Linecast(this.transform.position, LOS.transform.position, focus);
		if (hit.collider != null) {
			if (hit.collider.name == "Player") {
				follow = false;
				LOS.transform.position = hit.collider.gameObject.transform.position;
				Vector3 dir = hit.collider.gameObject.transform.position - this.transform.position;
				dir.Normalize();
				rb.AddForce (dir * speed);
				FacingController (LOS.transform);
			} else {
				follow = true;
			} 
		} else {
			follow = true;
		} 
	}

	// Update is called once per frame
	void Update () {
		if(!PlayerController.pause){
			FollowPath (follow);
			Chase ();
			Catch ();	
		}
	}
}
