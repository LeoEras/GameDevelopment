using UnityEngine;
using System.Collections;

public class ReferenceMove : MonoBehaviour {
	public GameObject player;
	public EXOController movement;
	private Rigidbody2D rigid;
	public float dist;
	// Use this for initialization
	void Start () {
		rigid = this.gameObject.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		}
}
