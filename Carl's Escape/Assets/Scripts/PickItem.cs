using UnityEngine;
using System.Collections;

public class PickItem : MonoBehaviour {
	private DialogManager dMan;
	private ActionManager aMan;
	public bool inPickZone;
	private KeepDestroyed kd;
	private PlayerController player;
	public string[] items;
	public string[] weapons;
	private GameObject pauseScreen;
	private SFXManager sfxMan;

	// Use this for initialization
	void Start () {
		dMan = FindObjectOfType<DialogManager> ();
		kd = GetComponent<KeepDestroyed> ();
		sfxMan = FindObjectOfType<SFXManager> ();
		pauseScreen = dMan.transform.parent.FindChild("Pause").gameObject;
	}

	// Update is called once per frame
	void Update () {
		if(inPickZone && Input.GetKeyDown(KeyCode.Z) && dMan.finishDialog){
			player = FindObjectOfType<PlayerController> ();

			if(player){
				foreach(string item in items){
					player.items.Add(item);
				}

				foreach(string weapon in weapons){
					player.weapons.Add(weapon);
				}
			}

			sfxMan.pick.Play ();

			kd.AddDestroyedObject(gameObject);
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag == "Player"){
			inPickZone = true;
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if(other.gameObject.tag == "Player"){
			inPickZone = false;
		}
	}
}
