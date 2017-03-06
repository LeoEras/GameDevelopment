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
	private GameObject pauseScreen;
	private SFXManager sfxMan;

	// Use this for initialization
	void Start () {
		dMan = FindObjectOfType<DialogManager> ();
		aMan = FindObjectOfType<ActionManager> ();
		player = FindObjectOfType<PlayerController> ();
		kd = FindObjectOfType<KeepDestroyed> ();
		sfxMan = FindObjectOfType<SFXManager> ();
		pauseScreen = dMan.transform.parent.FindChild("Pause").gameObject;
	}

	// Update is called once per frame
	void Update () {
		if(inDialogZone && Input.GetKeyUp(KeyCode.Z) && !pauseScreen.activeSelf){
			if (!dMan.dialogActive) {
				if (llave == "") {
					sfxMan.openDoor.Play ();

					kd.AddDestroyedObject (transform.parent.gameObject);
					Destroy (transform.parent.gameObject);
				} else {

					if (llave == "otroLado") {
						dialogLines [0] = "Se abre del otro lado";
					} else {
						if ( player.items.Contains(llave) ) {
							sfxMan.openDoor.Play ();

							dialogLines [0] = "Has usado [ " + llave + " ]";
							kd.AddDestroyedObject( transform.parent.gameObject );
							Destroy ( transform.parent.gameObject );
						} else {
							dialogLines [0] = "Cerrado";
						}
					}

					dMan.dialogLines = dialogLines;
					dMan.currentLine = 0;
					dMan.ShowDialog ();

				}

				inDialogZone = false;
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
