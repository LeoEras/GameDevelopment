using UnityEngine;
using System.Collections;

public class GroundCheck : MonoBehaviour {

	public EXOController EXO;

	void OnCollisionStay2D(Collision2D coll){
		if (coll.gameObject.tag =="wall") {
			EXO.isGrounded (true);
		}
	}

	void OnCollisionExit2D(Collision2D coll){
		if(coll.gameObject.tag =="wall")
			EXO.isGrounded (false);
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
}
