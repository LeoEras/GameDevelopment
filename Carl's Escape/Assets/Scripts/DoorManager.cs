using UnityEngine;
using System.Collections;

public class DoorManager : MonoBehaviour {
	public string llave;
	private PlayerController player;
	private DialogManager dMan;
	public string action;
	private ActionManager aMan;
	private bool inDialogZone;
	public string[] dialogLines;
	private KeepDestroyed kd;

	// Use this for initialization
	void Start () {
		dMan = FindObjectOfType<DialogManager> ();
		aMan = FindObjectOfType<ActionManager> ();
		player = FindObjectOfType<PlayerController> ();
		kd = FindObjectOfType<KeepDestroyed> ();
	}

	// Update is called once per frame
	void Update () {
		if(inDialogZone && Input.GetKeyUp(KeyCode.Z)){
			if (!dMan.dialogActive) {
				if (player.keys.ContainsValue (llave)) {
					dialogLines [0] = "Has usado [" + llave + "]";
					kd.AddDestroyedObject( transform.parent.gameObject );
					Destroy ( transform.parent.gameObject );
				} else {
					dialogLines [0] = "Cerrado";
				}

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
