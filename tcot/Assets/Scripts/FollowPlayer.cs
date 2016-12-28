using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

	private Vector2 velocity;
	public float smoothTimeY;
	public float smoothTimeX;
	public GameObject player;
	public GameObject reference_point;
	public EXOController control;
	public float dist;
	public bool mustFollow = false;
	public bool canMove = true;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		control = player.GetComponent<EXOController> ();
		reference_point = GameObject.FindGameObjectWithTag ("ref");
	}

	// Update is called once per frame
	void Update () {
			dist = reference_point.transform.position.x - player.transform.position.x;
			if (dist < 0&&mustFollow == false) {
				mustFollow = true;
			}
		following (mustFollow);
	}


	public void following (bool hasToFollow){
		if (hasToFollow==true) {
			float posX = Mathf.SmoothDamp (this.gameObject.transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
			this.gameObject.transform.position = new Vector3 (player.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
		} else {
			this.gameObject.transform.position = new Vector3 (this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
		}
	}
}
