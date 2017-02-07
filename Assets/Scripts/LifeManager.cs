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
			player.gameObject.SetActive (false);
			StartCoroutine ("GameOver");
		}

		if (lifeCounter >= 0) {
			theText.text = "x "+ lifeCounter.ToString();
		}
	}

	IEnumerator GameOver () {
		yield return new WaitForSeconds (2);
		Application.LoadLevel ("GameOver");
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
