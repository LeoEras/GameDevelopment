using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class DialogHolderLoad : MonoBehaviour {
	private DialogManager dMan;
	public string action;
	private ActionManager aMan;
	private bool inDialogZone;
	public string sceneToLoad;
	private bool lastLine;
	public string[] dialogLines;
	private DarknessManager darkMan;

	// Use this for initialization
	void Start () {
		dMan = FindObjectOfType<DialogManager> ();
		aMan = FindObjectOfType<ActionManager> ();
		darkMan = FindObjectOfType<DarknessManager> ();
	}

	// Update is called once per frame
	void Update () {
		if(inDialogZone && Input.GetKeyUp(KeyCode.Z)){
			if (!dMan.dialogActive) {
				inDialogZone = false;
				dMan.dialogLines = dialogLines;
				dMan.currentLine = 0;
				dMan.ShowDialog ();
				lastLine = false;
			} 
		}

		if (Input.GetKeyDown (KeyCode.Z)) {
			if(lastLine){
				darkMan.DarkenScreen(1f, 0.05f, sceneToLoad);
				lastLine = false;
			}
			else if (dMan.currentLine+1 >= dialogLines.Length) {
				lastLine = true;
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
