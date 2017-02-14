using UnityEngine;
using System.Collections;

public class JumpBuffPickup : MonoBehaviour {

	private PlayerController player;
	public JumpBuff jumpBuff;
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
		gameObject.GetComponent<CircleCollider2D> ().enabled = false;
		if (gameObject.tag == "RespawnCollectible") {
			yield return new WaitForSeconds (jumpBuff.Duration);
			gameObject.GetComponent<Renderer>().enabled = true;
			gameObject.GetComponent<CircleCollider2D> ().enabled = true;
		}
	}

	public void ApplyBuff () {
		TimedJumpBuff buff = (TimedJumpBuff) jumpBuff.InitializeBuff (player);
		buffable.AddBuff (buff);
	}
}
