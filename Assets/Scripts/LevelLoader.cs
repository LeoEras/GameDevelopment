using UnityEngine;
using System.Collections;

public class LevelLoader : MonoBehaviour {

	private bool playerInZone;
	public string levelToLoad;
	public string levelToUnlock;
	private LevelManager levelManager;

	// Use this for initialization
	void Start () {
		levelManager = FindObjectOfType<LevelManager> ();
		playerInZone = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.W) && playerInZone && LevelManager.allCrystalsPicked) {
			PlayerPrefs.SetString ("CurrentLevel", levelManager.levelName);
			PlayerPrefs.SetInt (levelToUnlock, 1);
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
