using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed;
	public int facing_direction;
	private Animator animator;
	public GameObject camera;

	// Use this for initialization
	void Start()
	{
		animator = this.GetComponent<Animator>();
		animator.SetInteger("direction", facing_direction);
	}

	// Update is called once per frame
	void Update () {
		var vertical = Input.GetAxis("Vertical");
		var horizontal = Input.GetAxis("Horizontal");

		if (vertical > 0)
		{
			animator.SetInteger("direction", 0);
		}
		else if (vertical < 0)
		{
			animator.SetInteger("direction", 2);
		}
		else if (horizontal > 0)
		{
			animator.SetInteger("direction", 1);
		}
		else if (horizontal < 0)
		{
			animator.SetInteger("direction", 3);
		}

		if (vertical != 0 || horizontal != 0) {
			animator.SetBool ("is_moving", true);
		} else {
			animator.SetBool ("is_moving", false);
		}

		transform.rotation = Quaternion.Euler(0, 0, 0);
		transform.Translate (Input.GetAxisRaw ("Horizontal") * speed,
			Input.GetAxisRaw ("Vertical") * speed, 0);

		camera.transform.position = new Vector3(this.transform.position.x,
			this.transform.position.y, -10);
	}
}
