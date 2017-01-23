using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	public string levelSelect;
	public string mainMenu;
	public bool paused;
	public GameObject pauseMenuCanvas;
	
	// Update is called once per frame
	void Update () {
		if (paused) {
			AudioListener.volume = 0.2f;
			pauseMenuCanvas.SetActive (true);
			Time.timeScale = 0;
		} else {
			AudioListener.volume = 1.0f;
			pauseMenuCanvas.SetActive (false);
			Time.timeScale = 1;
		}

		if (Input.GetKeyDown(KeyCode.Escape)) {
			paused = !paused;
		}
	}

	public void Resume () {
		paused = false;
	}

	public void LevelSelect () {
		Application.LoadLevel (levelSelect);
	}

	public void Quit () {
		Application.LoadLevel (mainMenu);
	}
}
