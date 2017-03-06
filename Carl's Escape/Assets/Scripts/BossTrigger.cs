using UnityEngine;
using System.Collections;

public class BossTrigger : MonoBehaviour {
	private PlayerController player;
	private DoorManager doorMan;
	private KeepDestroyed kd;
	private GameObject boss;
	private GameObject closedDoors;
	public string item;
	private MusicManager mc;
	private SFXManager sfxMan;
	private int previewsTrack;
	public int newtrack;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ();
		doorMan = FindObjectOfType<DoorManager> ();
		kd = GetComponent<KeepDestroyed> ();
		mc = FindObjectOfType<MusicManager> ();
		sfxMan = FindObjectOfType<SFXManager> ();

		previewsTrack = mc.currentTrack;
		boss = GameObject.Find ("bossContainer").transform.Find ("Boss").gameObject;
		closedDoors = GameObject.Find ("closeDoorsContainer").transform.Find ("CloseDoors").gameObject;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag == "Player" && player.items.Contains(item)){
			sfxMan.closeDoor.Play ();
			mc.SwitchTrack (newtrack);

			closedDoors.SetActive (true);
			boss.SetActive (true);
			doorMan.gameObject.SetActive(false);
			gameObject.SetActive (false);
		}
	}

	public void BossDestroyed(){
		sfxMan.openDoor.Play ();
		mc.SwitchTrack (previewsTrack);

		closedDoors.SetActive (false);
		doorMan.gameObject.SetActive(true);

		kd.AddDestroyedObject(gameObject);
		Destroy (gameObject);
	}
}
