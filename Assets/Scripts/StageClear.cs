using UnityEngine;
using System.Collections;

public class StageClear : MonoBehaviour {

	public string mainMenu;
	public string levelSelect;
	public int pointsToAdd;

	public void Continue () {
		PlayerPrefs.SetInt ("CurrentLevel", 1);
		ScoreManager.AddPoints (pointsToAdd);
		PlayerPrefs.SetInt ("PlayerMaxHealth", PlayerPrefs.GetInt("PlayerMaxHealth"));
		PlayerPrefs.SetInt ("PlayerCurrentHealth", PlayerPrefs.GetInt("PlayerMaxHealth"));
		Application.LoadLevel (levelSelect);
	}

	public void ReloadLevel () {
		PlayerPrefs.SetInt ("CurrentLevel", 1);
		ScoreManager.AddPoints (pointsToAdd);
		PlayerPrefs.SetInt ("PlayerMaxHealth", PlayerPrefs.GetInt("PlayerMaxHealth"));
		PlayerPrefs.SetInt ("PlayerCurrentHealth", PlayerPrefs.GetInt("PlayerMaxHealth"));
		Application.LoadLevel (PlayerPrefs.GetString("CurrentLevel"));
	}

	public void Quit () {
		Application.LoadLevel (mainMenu);
	}
}
