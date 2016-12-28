using UnityEngine;
using System.Collections;

public class StoneFall : MonoBehaviour {
	
	public Rigidbody2D rigid;

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.CompareTag ("Player")) {
			rigid.gravityScale = 0.5f;
			Destroy (this.gameObject);
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
