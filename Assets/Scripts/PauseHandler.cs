using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseHandler : MonoBehaviour {
	private bool pause = false;
	private GameObject pauseScreen;
	private int selectedOptionPause;
	private Transform player;
	public Sprite Main_Menu;
	public Sprite Main_Menu_Selected;
	public Sprite Continue;
	public Sprite Continue_Selected;
	public Sprite Reload;
	public Sprite Reload_Selected;

	// Use this for initialization
	void Start () {
		selectedOptionPause = 1;
		player = GameObject.Find ("Player").transform;
	}

	void PauseGame(){
		if (Input.GetKeyDown(KeyCode.Escape)){
			if (pause) {
				this.GetComponent<AudioSource> ().Stop ();
				GameObject.Find ("Main Camera").GetComponent<AudioSource>().Play();
			} else {
				this.GetComponent<AudioSource> ().Play ();
				GameObject.Find ("Main Camera").GetComponent<AudioSource>().Pause();
			}
			pause = !pause;
		}
		if (pause) {
			this.transform.position = player.position;
			if(Input.GetKeyDown(KeyCode.UpArrow)){
				if (selectedOptionPause > 0) {
					selectedOptionPause--;
				}
			} else if(Input.GetKeyDown(KeyCode.DownArrow)){
				if (selectedOptionPause < 2) {
					selectedOptionPause++;
				}
			}
			switch (selectedOptionPause) {
			case 0:
				this.transform.GetChild(1).GetComponent<SpriteRenderer> ().sprite = Main_Menu;
				this.transform.GetChild(2).GetComponent<SpriteRenderer> ().sprite = Continue;
				this.transform.GetChild(3).GetComponent<SpriteRenderer> ().sprite = Reload_Selected;
				if (Input.GetKeyDown (KeyCode.Return)) {
					pause = !pause;
					PlayerController.pause = false;
					SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
				}
				break;
			case 1:
				this.transform.GetChild(1).GetComponent<SpriteRenderer> ().sprite = Main_Menu;
				this.transform.GetChild(2).GetComponent<SpriteRenderer> ().sprite = Continue_Selected;
				this.transform.GetChild(3).GetComponent<SpriteRenderer> ().sprite = Reload;
				if (Input.GetKeyDown (KeyCode.Return)) {
					this.GetComponent<AudioSource> ().Stop ();
					pause = !pause;
					PlayerController.pause = false;
				}
				break;
			case 2:
				this.transform.GetChild(1).GetComponent<SpriteRenderer> ().sprite = Main_Menu_Selected;
				this.transform.GetChild(2).GetComponent<SpriteRenderer> ().sprite = Continue;
				this.transform.GetChild(3).GetComponent<SpriteRenderer> ().sprite = Reload;
				if (Input.GetKeyDown (KeyCode.Return)) {
					pause = !pause;
					PlayerController.pause = false;
					SceneManager.LoadScene ("Main Menu");
				}
				break;
			default:
				break;
			}
		} else {
			this.transform.position = new Vector3(-100, 0, 0);
			selectedOptionPause = 1;
		}
	}

	// Update is called once per frame
	void Update () {
		if (PlayerController.lives > 0) {
			PauseGame ();
		}
	}
}
