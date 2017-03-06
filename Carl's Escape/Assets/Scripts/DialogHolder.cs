using UnityEngine;
using System.Collections;

public class DialogHolder : MonoBehaviour {
	private DialogManager dMan;
	public string action;
	private ActionManager aMan;
	private bool inDialogZone;
	public string[] dialogLines;
	private GameObject pauseScreen;

	// Use this for initialization
	void Start () {
		dMan = FindObjectOfType<DialogManager> ();
		aMan = FindObjectOfType<ActionManager> ();
		pauseScreen = dMan.transform.parent.FindChild("Pause").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if(inDialogZone && Input.GetKeyUp(KeyCode.Z) && !pauseScreen.activeSelf){
			if (!dMan.dialogActive) {
				inDialogZone = false;
				dMan.dialogLines = dialogLines;
				dMan.currentLine = 0;
				dMan.ShowDialog ();
			} 
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag == "Player"){
			inDialogZone = true;
			aMan.ShowBox (action);
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if(other.gameObject.tag == "Player"){
			inDialogZone = false;
			aMan.HideBox();
		}
	}
}
