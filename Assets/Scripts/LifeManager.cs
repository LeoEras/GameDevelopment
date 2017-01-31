using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour {

	private int lifeCounter;
	private Text theText;
	public GameObject gameOverScreen;
	public PlayerController player;
	public string mainMenu;
	public float gameOverTimeOut;
	private AudioSource[] allMusic;
	private bool playedGOMusic;

	private 

	// Use this for initialization
	void Start () {
		allMusic = FindObjectsOfType<AudioSource> ();
		playedGOMusic = false;
		theText = GetComponent<Text> ();
		player = FindObjectOfType<PlayerController> ();
		lifeCounter = PlayerPrefs.GetInt("PlayerLives");
	}
	
	// Update is called once per frame
	void Update () {
		if (lifeCounter < 0) {
			if (allMusic.Length > 0) {
				for (int i = 0; i < allMusic.Length; i++) {
					allMusic [i].Stop ();
				}
			}
			gameOverScreen.SetActive (true);
			player.gameObject.SetActive (false);
			if (!playedGOMusic) {
				AudioManager.Main.PlayNewSound ("Game Over 1");
				playedGOMusic = true;
			}

		}

		theText.text = "x "+ lifeCounter.ToString();
	}

	public void GiveLife () {
		lifeCounter++;
		PlayerPrefs.SetInt ("PlayerLives", lifeCounter);
	}

	public void TakeLife () {
		lifeCounter--;
		PlayerPrefs.SetInt ("PlayerLives", lifeCounter);
	}
}
