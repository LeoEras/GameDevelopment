using UnityEngine;
using System.Collections;

public class BossMusicTrigger : MonoBehaviour {

	private AudioSource audioSource;
	public AudioClip bossClip;
	private bool triggered;

	// Use this for initialization
	void Start () {
		triggered = false;
		audioSource = FindObjectOfType<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.name == "Player" && !triggered) {
			audioSource.Stop ();
			audioSource.clip = bossClip;
			audioSource.Play ();
			triggered = !triggered;
		}
	}
}
