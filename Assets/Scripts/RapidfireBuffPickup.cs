using UnityEngine;
using System.Collections;

public class RapidfireBuffPickup : MonoBehaviour {

	private PlayerController player;
	public RapidfireBuff rapidfireBuff;
	private BuffableEntity buffable;

	// Use this for initialization
	void Start () {
		buffable = FindObjectOfType<BuffableEntity> ();
		player = FindObjectOfType<PlayerController> ();
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.GetComponent<PlayerController> () == null)
			return;
		AudioManager.Main.PlayNewSound ("coin");
		StartCoroutine ("DestroyOrRespawn");
		ApplyBuff ();
	}

	IEnumerator DestroyOrRespawn () {
		gameObject.GetComponent<Renderer>().enabled = false;
		gameObject.GetComponentInChildren<FireParticleEffect>().enabled = false;
		gameObject.GetComponent<CircleCollider2D> ().enabled = false;
		gameObject.GetComponentInChildren<PolygonCollider2D>().enabled = false;
		if (gameObject.tag == "RespawnCollectible") {
			yield return new WaitForSeconds (rapidfireBuff.Duration);
			gameObject.GetComponent<Renderer>().enabled = true;
			gameObject.GetComponentInChildren<FireParticleEffect>().enabled = true;
			gameObject.GetComponent<CircleCollider2D> ().enabled = true;
			gameObject.GetComponentInChildren<PolygonCollider2D>().enabled = true;
		}
	}

	public void ApplyBuff () {
		TimedRapidfireBuff buff = (TimedRapidfireBuff) rapidfireBuff.InitializeBuff (player);
		buffable.AddBuff (buff);
	}
}
