using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public string startLevel;
	public string levelSelect;
	public int playerLives;
	public int playerHealth;

	public void NewGame () {
		PlayerPrefs.SetInt ("PlayerLives", playerLives);
		PlayerPrefs.SetInt ("PlayerScore", 0);
		PlayerPrefs.SetInt ("PlayerMaxHealth", playerHealth);
		PlayerPrefs.SetInt ("PlayerCurrentHealth", playerHealth);
		Application.LoadLevel (startLevel);
	}

	public void LevelSelect () {
		PlayerPrefs.SetInt ("PlayerLives", playerLives);
		PlayerPrefs.SetInt ("PlayerScore", 0);
		PlayerPrefs.SetInt ("PlayerMaxHealth", playerHealth);
		PlayerPrefs.SetInt ("PlayerCurrentHealth", playerHealth);
		Application.LoadLevel (levelSelect);
	}

	public void QuitGame () {
		Application.Quit ();
	}
}
