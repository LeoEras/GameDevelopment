using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour {
	public GameObject dBox;
	public Text dText;
	public bool dialogActive;
	public string[] dialogLines;
	public int currentLine;
	private PlayerController player;
	private NPlayerController nPlayer;
	private GameObject pauseScreen;
	public bool finishDialog;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ();
		nPlayer = FindObjectOfType<NPlayerController> ();
		pauseScreen = transform.parent.FindChild("Pause").gameObject;

		ShowDialog ();
	}
	
	// Update is called once per frame
	void Update () {
		finishDialog = false;

		if(dialogActive && Input.GetKeyDown(KeyCode.Z) && !pauseScreen.activeSelf){
			currentLine ++;
		}

		if (currentLine >= dialogLines.Length) {
			dBox.SetActive (false);
			dialogActive = false;
			finishDialog = true;

			currentLine = 0;

			if(player){
				player.canMove = true;
			}

			if (nPlayer) {
				nPlayer.canMove = true;
			}
				
		}

		dText.text = dialogLines[currentLine];
	}

	public void ShowDialog(){
		dialogActive = true;
		dBox.SetActive (true);

		player = FindObjectOfType<PlayerController> ();
		if(player){
			player.canMove = false;
		}

		if (nPlayer) {
			nPlayer.canMove = false;
		}
	}
}
