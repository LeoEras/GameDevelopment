using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

	public string mainMenu;
	public string levelSelect;

	public void Continue () {
		PlayerPrefs.SetInt ("PlayerLives", 3);
		PlayerPrefs.SetInt ("PlayerScore", 0);
		PlayerPrefs.SetInt ("PlayerMaxHealth", PlayerPrefs.GetInt("PlayerMaxHealth"));
		PlayerPrefs.SetInt ("PlayerCurrentHealth", PlayerPrefs.GetInt("PlayerMaxHealth"));
		Application.LoadLevel (levelSelect);
	}

	public void Quit () {
		Application.LoadLevel (mainMenu);
	}

	public void ReloadLevel () {
		PlayerPrefs.SetInt ("PlayerLives", 3);
		PlayerPrefs.SetInt ("PlayerScore", 0);
		PlayerPrefs.SetInt ("PlayerMaxHealth", PlayerPrefs.GetInt("PlayerMaxHealth"));
		PlayerPrefs.SetInt ("PlayerCurrentHealth", PlayerPrefs.GetInt("PlayerMaxHealth"));
		Application.LoadLevel (PlayerPrefs.GetString("CurrentLevel"));
	}
}
