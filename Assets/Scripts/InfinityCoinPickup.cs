using UnityEngine;
using System.Collections;

public class InfinityCoinPickup : MonoBehaviour {

	private PlayerController player;
	public InfinityBuff infinityBuff;
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
		// Disable item
		gameObject.GetComponent<Renderer>().enabled = false;
		gameObject.GetComponentInChildren<FireParticleEffect>().enabled = false;
		gameObject.GetComponent<CircleCollider2D> ().enabled = false;
		gameObject.GetComponentInChildren<PolygonCollider2D>().enabled = false;
		ApplyBuff ();
	}

	public void ApplyBuff () {
		TimedInfinityBuff buff = (TimedInfinityBuff) infinityBuff.InitializeBuff (player);
		buffable.AddBuff (buff);
	}
}
