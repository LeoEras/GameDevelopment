using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {

	public static int playerHealth;
	public int maxHealth;
	public bool isDead;
	private LifeManager lifeManager;

	//Text text;
	public Slider healthBar;

	private LevelManager levelManager;

	// Use this for initialization
	void Start () {
		//text = GetComponent<Text> ();
		healthBar = GetComponent<Slider>();
		playerHealth = PlayerPrefs.GetInt ("PlayerCurrentHealth");
		levelManager = FindObjectOfType<LevelManager> ();
		lifeManager = FindObjectOfType<LifeManager> ();
		isDead = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (playerHealth <= 0 && !isDead) {
			playerHealth = 0;
			levelManager.RespawnPlayer ();
			lifeManager.TakeLife ();
			isDead = true;
		}

		if (playerHealth > maxHealth) {
			playerHealth = maxHealth;
		}

		healthBar.value = playerHealth;
		//text.text = playerHealth.ToString();
	}

	public static void InflictDamage (int damage) {
		playerHealth -= damage;
		PlayerPrefs.SetInt ("PlayerCurrentHealth", playerHealth);
	}

	public void ResetHealth () {
		playerHealth = PlayerPrefs.GetInt ("PlayerMaxHealth");
		PlayerPrefs.SetInt ("PlayerCurrentHealth", playerHealth);
	}

}
