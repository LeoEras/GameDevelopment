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
	public static bool allCrystalsPicked;

	private PlayerController player;
	private Camera2D camera;

	public HealthManager healthManager;

	// Use this for initialization
	void Start () {
		allCrystalsPicked = false;
		crystalsPicked = 0;
		crystalsToPick_ = crystalsToPick;
		player = FindObjectOfType<PlayerController> ();
		camera = FindObjectOfType<Camera2D> ();
		healthManager = FindObjectOfType<HealthManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if ((crystalsPicked == crystalsToPick_) || crystalsToPick == 0) {
			allCrystalsPicked = true;
			Debug.Log ("All crystals have been collected!");
		}
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
		TimedSpeedBuff.counter = 0;
		TimedInfinityBuff.counter = 0;
		TimedJumpBuff.counter = 0;
		TimedRapidfireBuff.counter = 0;
		BuffableEntity.RemoveBuffs ();
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
		player.fireParticleEffect.SetActive (false);
		player.speedParticleEffect.SetActive (false);
		player.jumpParticleEffect.SetActive (false);
		player.rapidfireParticleEffect.SetActive (false);
		player.GetComponent<Renderer>().enabled = true;
		player.GetComponent<CircleCollider2D> ().enabled = true;
		player.GetComponent<BoxCollider2D> ().enabled = true;
		camera.isFollowing = true;
	}

	public static void PickCrystal () {
		crystalsPicked++;
	}
}
