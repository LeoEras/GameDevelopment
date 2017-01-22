using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public GameObject currentCheckpoint;
	public GameObject deathParticles;
	public GameObject defaultBeam;
	public int defaultMoveSpeed;
	public int defaultJumpHeight;
	public float defaultShotDelay;
	public float respawnDelay;
	public int pointPenaltyOnDeath;
	public int crystalsToPick;
	public static int crystalsPicked;
	public static int crystalsToPick_;

	private PlayerController player;
	private Camera2D camera;

	public HealthManager healthManager;

	// Use this for initialization
	void Start () {
		crystalsPicked = 0;
		crystalsToPick_ = crystalsToPick;
		player = FindObjectOfType<PlayerController> ();
		camera = FindObjectOfType<Camera2D> ();
		healthManager = FindObjectOfType<HealthManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void RespawnPlayer () {
		HealthManager.playerHealth = 0;
		StartCoroutine ("RespawnPlayerCo");
	}

	public IEnumerator RespawnPlayerCo () {
		player.enabled = false;
		player.GetComponent<Renderer>().enabled = false;
		player.GetComponent<CircleCollider2D> ().enabled = false;
		player.GetComponent<BoxCollider2D> ().enabled = false;
		camera.isFollowing = false;
		AudioManager.Main.PlayNewSound ("player_dead");
		Instantiate (deathParticles, player.transform.position, player.transform.rotation);
		ScoreManager.AddPoints (-pointPenaltyOnDeath);
		yield return new WaitForSeconds (respawnDelay);
		player.transform.position = currentCheckpoint.transform.position;
		player.enabled = true;
		healthManager.ResetHealth ();
		healthManager.isDead = false;
		player.shotDelay = defaultShotDelay;
		player.moveSpeed = defaultMoveSpeed;
		player.shootingObjet = defaultBeam;
		player.jumpHeight = defaultJumpHeight;
		player.GetComponent<Renderer>().enabled = true;
		player.GetComponent<CircleCollider2D> ().enabled = true;
		player.GetComponent<BoxCollider2D> ().enabled = true;
		camera.isFollowing = true;
	}

	public static void CrystalPicked () {
		crystalsPicked++;
		Debug.Log ("Picked: "+crystalsPicked);
		if (crystalsPicked == crystalsToPick_) {
			Debug.Log ("Picked all");
		}

	}

}
