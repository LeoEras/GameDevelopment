using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class OptionsController : MonoBehaviour {
	public GameObject play;
	public GameObject play_s;
	public GameObject exit;
	public GameObject exit_s;
	public GameObject help;
	public GameObject help_s;
	public GameObject music;
	public GameObject n_music;
	public GameObject audio_gameobject;
	public GameObject n_audio;
	public GameObject help_text;
	private int option;
	private bool music_on = true;
	private bool audio_on = true;
	private GameObject ayuda;
	private bool cont = false;

	// Use this for initialization
	void Start () {
		option = 0;
		ayuda = GameObject.Find ("Ayuda");
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.DownArrow) || Input.GetKeyDown (KeyCode.RightArrow)) {
			option++;
			option = option % 5;
		}

		if (Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown (KeyCode.LeftArrow)) {
			if (option > 0) {
				option--;
			} else {
				option = 4;
			}
			option = option % 5;
		}


		switch (option) {
		case 0:
			exit_s.transform.position = new Vector3 (-20f, -2.8f, 0f);
			exit.transform.position = new Vector3 (0f, -2.8f, 0f);
			play.transform.position = new Vector3 (-20f, -1.8f, 0f);
			play_s.transform.position = new Vector3 (0f, -1.8f, 0f);
			if (Input.GetKeyDown (KeyCode.Return)) {
				SceneManager.LoadScene ("Level1");
			}
			break;
		case 1:
			play_s.transform.position = new Vector3 (-20f, -1.8f, 0f);
			play.transform.position = new Vector3 (0f, -1.8f, 0f);
			exit_s.transform.position = new Vector3 (0f, -2.8f, 0f);
			exit.transform.position = new Vector3 (-20f, -2.8f, 0f);
			help.transform.position = new Vector3 (0f, -3.8f, 0f);
			help_s.transform.position = new Vector3 (-20f, -3.8f, 0f);
			help_text.transform.position = new Vector3 (0.5f, 20f, 0f);
			if (Input.GetKeyDown (KeyCode.Return)) {
				Application.Quit ();
			}
			break;
		case 2:
			exit_s.transform.position = new Vector3 (-20f, -2.8f, 0f);
			exit.transform.position = new Vector3 (0f, -2.8f, 0f);
			help.transform.position = new Vector3 (-20f, -3.8f, 0f);
			help_s.transform.position = new Vector3 (0f, -3.8f, 0f);
			if (Input.GetKeyDown (KeyCode.Return)) {
				cont = !cont;
				if (cont) {
					help_text.transform.position = new Vector3 (0.5f, 1.7f, 0f);
					ayuda.GetComponent<AudioSource> ().Play ();
				} else {
					help_text.transform.position = new Vector3 (0.5f, 20f, 0f);
				}
			}
			break;
		case 3:
			help.transform.position = new Vector3 (0f, -3.8f, 0f);
			help_s.transform.position = new Vector3 (-20f, -3.8f, 0f);
			help_text.transform.position = new Vector3 (0.5f, 20f, 0f);
			if (Input.GetKeyDown (KeyCode.Return)) {
				if (music_on) {
					music.transform.position = new Vector3 (-1f, -10f, 0f);
					n_music.transform.position = new Vector3 (-1f, -5f, 0f);
					music_on = false;
				} else {
					music.transform.position = new Vector3 (-1f, -5f, 0f);
					n_music.transform.position = new Vector3 (-1f, -10f, 0f);
					music_on = true;
				}
			}
			break;
		case 4:
			play.transform.position = new Vector3 (0f, -1.8f, 0f);
			play_s.transform.position = new Vector3 (-20f, -1.8f, 0f);
			if (Input.GetKeyDown (KeyCode.Return)) {
				if (audio_on) {
					GameObject.Find ("Main Camera").GetComponent<AudioSource>().Pause();
					audio_gameobject.transform.position = new Vector3 (1f, -10f, 0f);
					n_audio.transform.position = new Vector3 (1f, -5f, 0f);
					audio_on = false;
				} else {
					GameObject.Find ("Main Camera").GetComponent<AudioSource>().UnPause();
					audio_gameobject.transform.position = new Vector3 (1f, -5f, 0f);
					n_audio.transform.position = new Vector3 (1f, -10f, 0f);
					audio_on = true;
				}
			}
			break;
		}
	}

	void Reset(){
		play.transform.position = new Vector3 (-20f, -1.8f, 0f);
	}
}
