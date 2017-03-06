using UnityEngine;
using System.Collections;

public class MusicSwitcher : MonoBehaviour {
	private MusicManager mc;
	public int newtrack;
	public bool switchOnStart;

	// Use this for initialization
	void Start () {
		mc = FindObjectOfType<MusicManager> ();

		if(switchOnStart){
			mc.SwitchTrack (newtrack);
			gameObject.SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.name == "player"){
			mc.SwitchTrack (newtrack);
			gameObject.SetActive (false);
		}
	}
}
