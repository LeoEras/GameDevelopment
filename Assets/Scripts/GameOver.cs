using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

	public string mainMenu;
	public string levelSelect;

	public void Continue () {
		PlayerPrefs.SetInt ("PlayerLives", 3);
		PlayerPrefs.SetInt ("PlayerScore", 0);
		Application.LoadLevel (levelSelect);
	}

	public void Quit () {
		Application.LoadLevel (mainMenu);
	}
}
