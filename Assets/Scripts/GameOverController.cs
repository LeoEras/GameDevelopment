using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour {
	private GameObject pauseScreen;
	private int selectedOptionPause;
	private Transform player;
	private bool flag;

	// Use this for initialization
	void Start () {
		flag = false;
		selectedOptionPause = 0;
		player = GameObject.Find ("Player").transform;
	}

	void EndGame(){
		PlayerController.pause = true;
		GameObject.Find ("Main Camera").GetComponent<AudioSource>().Pause();
		this.transform.position = player.position;
		if(Input.GetKeyDown(KeyCode.UpArrow)){
			if (selectedOptionPause > 0) {
				selectedOptionPause--;
			}
		} else if(Input.GetKeyDown(KeyCode.DownArrow)){
			if (selectedOptionPause < 1) {
				selectedOptionPause++;
			}
		}
		switch (selectedOptionPause) {
		case 0:
			if (Input.GetKeyDown (KeyCode.Return)) {
				SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
				PlayerController.lives = 3;
				PlayerController.pause = false;
				PlayerController.score = 0;
			}
			break;
		case 1:
			if (Input.GetKeyDown (KeyCode.Return)) {
				SceneManager.LoadScene ("Main Menu");
			}
			break;
		default:
			break;
		}
	}

	// Update is called once per frame
	void Update () {
		if (PlayerController.lives == 0) {
			if (!flag) {
				GetComponent<AudioSource> ().Play ();
				flag = true;
			}
			EndGame ();
		}
	}
}

