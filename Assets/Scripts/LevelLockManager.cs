using UnityEngine;
using System.Collections;

public class LevelLockManager : MonoBehaviour {

	private bool playerInZone;
	public string levelToLoad;

	// Use this for initialization
	void Start () {
		playerInZone = false;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.W) && playerInZone && PlayerPrefs.GetInt(levelToLoad) == 1) {
			Application.LoadLevel (levelToLoad);
		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Player") {
			playerInZone = true;
		}
	}

	void OnTriggerExit2D (Collider2D other) {
		if (other.tag == "Player") {
			playerInZone = false;
		}
	}
}
