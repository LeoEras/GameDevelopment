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

	private 

	// Use this for initialization
	void Start () {
		theText = GetComponent<Text> ();
		player = FindObjectOfType<PlayerController> ();
		lifeCounter = PlayerPrefs.GetInt("PlayerLives");

	}
	
	// Update is called once per frame
	void Update () {
		if (lifeCounter < 0) {
			gameOverScreen.SetActive (true);
			player.gameObject.SetActive (false);
		}

		theText.text = "x "+ lifeCounter.ToString();

		if (gameOverScreen.activeSelf) {
			gameOverTimeOut -= Time.deltaTime;
		}

		if (gameOverTimeOut < 0) {
			Application.LoadLevel (mainMenu);
		}
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
