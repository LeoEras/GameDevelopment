using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public string startLevel;
	public string levelSelect;
	public int playerLives;
	public int playerHealth;

	void Start () {
		AudioListener.volume = 1.0f;
	}

	public void NewGame () {
		PlayerPrefs.SetInt ("Stage1", 1);
		PlayerPrefs.SetInt ("Stage2", 0);
		PlayerPrefs.SetInt ("Stage3", 0);
		PlayerPrefs.SetInt ("PlayerLives", playerLives);
		PlayerPrefs.SetInt ("PlayerScore", 0);
		PlayerPrefs.SetInt ("PlayerMaxHealth", playerHealth);
		PlayerPrefs.SetInt ("PlayerCurrentHealth", playerHealth);
		Application.LoadLevel (startLevel);
	}

	public void LevelSelect () {
		PlayerPrefs.SetInt ("Stage1", 1);
		if (PlayerPrefs.GetInt ("PlayerLives") < 0) {
			PlayerPrefs.SetInt ("PlayerLives", playerLives);
			PlayerPrefs.SetInt ("PlayerScore", 0);
			PlayerPrefs.SetInt ("PlayerMaxHealth", playerHealth);
			PlayerPrefs.SetInt ("PlayerCurrentHealth", playerHealth);
		}
		Application.LoadLevel (levelSelect);
	}

	public void QuitGame () {
		Application.Quit ();
	}
}
