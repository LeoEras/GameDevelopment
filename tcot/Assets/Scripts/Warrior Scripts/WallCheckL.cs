using UnityEngine;
using System.Collections;

public class WallCheckL : MonoBehaviour {

	public EXOController EXO;
	void OnTriggerEnter2D(Collider2D coll){
		if ((coll.gameObject.CompareTag ("wall")||coll.gameObject.CompareTag ("bound wall")) && EXO.facingLeft) {
			EXO.canMoveLeft (false);
		} else if ((coll.gameObject.CompareTag ("wall")||coll.gameObject.CompareTag ("bound wall")) && !EXO.facingLeft){
			EXO.canMoveRight (false);
		}
	}

	void OnTriggerExit2D(Collider2D coll){
		if (coll.gameObject.CompareTag ("wall") || coll.gameObject.CompareTag ("bound wall")) {
			EXO.canMoveLeft (true);
			EXO.canMoveRight (true);
		}
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
}
