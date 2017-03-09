using UnityEngine;
using System.Collections;

public class CarMovement : MonoBehaviour {

	public float initialX;
	public float finalX;
	public float velocity;
	private Rigidbody2D rb;
	public bool moveRight;
	public bool lookingLeft;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		if (lookingLeft) {
			moveRight = !moveRight;
			velocity = -velocity;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x > finalX || transform.position.x < initialX) {
			moveRight = !moveRight;
		}
		if (moveRight) {
			transform.localScale = new Vector3 (1f, 1f, 1f);
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (velocity, GetComponent<Rigidbody2D> ().velocity.y);
		} else {
			transform.localScale = new Vector3 (-1f, 1f, 1f);
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (-velocity, GetComponent<Rigidbody2D> ().velocity.y);
		}
	}
}
