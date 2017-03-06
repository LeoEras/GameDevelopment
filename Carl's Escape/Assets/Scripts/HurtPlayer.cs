using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class HurtPlayer : MonoBehaviour {
	public int damageToGive;
	public GameObject damageNumber;
	public float waitToReload;
	private bool reloading;
	private PlayerHealthManager playerHealth;
	private MusicManager mc;
	private int previewsTrack;

	// Use this for initialization
	void Start () {
		playerHealth = FindObjectOfType<PlayerHealthManager> ();
		mc = FindObjectOfType<MusicManager> ();

		previewsTrack = mc.currentTrack;
	}

	// Update is called once per frame
	void Update () {
		if(playerHealth.playerCurrentHealth <= 0 && !reloading){
			reloading = true;
		}

		if (reloading) {
			waitToReload -= Time.deltaTime;
			if (waitToReload < 0) {
				reloading = false;
				mc.SwitchTrack (previewsTrack);
				playerHealth.playerCurrentHealth = playerHealth.playerMaxHealth;
				playerHealth.gameObject.SetActive (true);
				SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
			}
		}
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.name == "player") {
			other.gameObject.GetComponent<PlayerHealthManager> ().HurtPlayer (damageToGive);

			var clone = (GameObject) Instantiate (damageNumber, other.transform.position, Quaternion.Euler(Vector3.zero));
			clone.GetComponent<FloatingNumbers> ().damageNumber = damageToGive;
		}
	}
}
