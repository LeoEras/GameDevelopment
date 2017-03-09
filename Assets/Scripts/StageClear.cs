using UnityEngine;
using System.Collections;

public class StageClear : MonoBehaviour {

	public string mainMenu;
	public string levelSelect;
	public int pointsToAdd;
	private string currentLevel;

	void Start(){
		currentLevel = PlayerPrefs.GetString ("CurrentLevel");
	}
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
		Application.LoadLevel (currentLevel);
	}

	public void Quit () {
		Application.LoadLevel (mainMenu);
	}
}
