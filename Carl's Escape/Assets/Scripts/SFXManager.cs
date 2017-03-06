using UnityEngine;
using System.Collections;

public class SFXManager : MonoBehaviour {
	public AudioSource playerHurt;
	public AudioSource playerBateAtk;
	public AudioSource playerSwordAtk;
	public AudioSource playerDead;
	public AudioSource zombieWalk1;
	public AudioSource zombieWalk2;
	public AudioSource zombieDead;
	public AudioSource BossDeadEff;
	public AudioSource BossDeadVoice;
	public AudioSource select;
	public AudioSource pick;
	public AudioSource openDoor;
	public AudioSource closeDoor;
	private static bool sfxManExists;

	// Use this for initialization
	void Start () {
		if (!sfxManExists) {
			sfxManExists = true;
			DontDestroyOnLoad (transform.gameObject);
		} 
		else {
			Destroy (gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
