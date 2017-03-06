using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour {
	public Sprite black_heart;
	public GameObject heart1;
	public GameObject heart2;
	public GameObject heart3;
	public GameObject TimeLeft;
	public GameObject Score;
	public int clockNumber;
	private bool hidden = false;
	public int MaxTime;
	private float timeleft;
	public static bool win = false;

	// Use this for initialization
	void Start () {
		timeleft = MaxTime;
	}

	void LivesHandler(int lives){
		if (Input.GetKeyDown (KeyCode.Space)) {
			PlayerController.lives--;
		}
		switch (lives) {
		case 2:
			heart1.GetComponent<Image> ().sprite = black_heart;
			break;
		case 1:
			heart2.GetComponent<Image> ().sprite = black_heart;
			break;
		case 0:
			heart3.GetComponent<Image> ().sprite = black_heart;
			hidden = true;
			break;
		default:
			break;
		}
	}

	void TimerHandler(){
		timeleft = timeleft - Time.deltaTime;
		int minutes = (int)timeleft / 60;
		int seconds = (int)(timeleft - 60 * ((int)timeleft / 60));
		if (seconds < 10) {
			TimeLeft.GetComponent<Text> ().text = minutes.ToString() + ":0" + seconds.ToString();
		} else {
			TimeLeft.GetComponent<Text> ().text = minutes.ToString() + ":" + seconds.ToString();	
		}

		if (minutes == 0 && seconds == 30) {
			GameObject.Find ("Time").GetComponent<AudioSource> ().Play ();
		}

		if(timeleft < 0){
			PlayerController.lives = 0;
			hidden = true;
		}
	}

	void ScoreHandler(){
		Score.GetComponent<Text> ().text = PlayerController.score.ToString() + "/" + clockNumber.ToString();
		if(PlayerController.score == clockNumber){
			win = true;
			hidden = true;
		}
	}

	// Update is called once per frame
	void Update () {
		LivesHandler (PlayerController.lives);
		TimerHandler ();
		ScoreHandler ();
		if (hidden){
			GameObject.Find ("Canvas").SetActive (false);
		}
	}
}
