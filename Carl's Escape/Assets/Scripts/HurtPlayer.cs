using UnityEngine;
using System.Collections;

public class HurtPlayer : MonoBehaviour {
	public int damageToGive;
	public GameObject damageNumber;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.name == "player") {
			other.gameObject.GetComponent<PlayerHealthManager> ().HurtPlayer (damageToGive);

			var clone = (GameObject) Instantiate (damageNumber, other.transform.position, Quaternion.Euler(Vector3.zero));
			clone.GetComponent<FloatingNumbers> ().damageNumber = damageToGive;
		}
	}
}
