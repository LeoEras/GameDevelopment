﻿using UnityEngine;
using System.Collections;

public class EnemySounds : MonoBehaviour {

	public static AudioSource enemyHurt;
	public static AudioSource enemyDead;
	public AudioClip clipHurt;
	public AudioClip clipDead;

	public AudioSource AddAudio (AudioClip clip, bool loop, bool playAwake, float vol) {

		AudioSource newAudio = gameObject.AddComponent<AudioSource>();

		newAudio.clip = clip;
		newAudio.loop = loop;
		newAudio.playOnAwake = playAwake;
		newAudio.volume = vol;

		return newAudio;

	}
	 
	void Awake () {
		enemyHurt = AddAudio (clipHurt, false, false, 1f);
		enemyDead = AddAudio (clipDead, false, false, 1f);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	public static void PlayHurtSound(){
		enemyHurt.GetComponent<AudioSource> ().Play ();
	}

	public static void PlayDeadSound(){
		enemyDead.GetComponent<AudioSource> ().Play ();
	}

}
