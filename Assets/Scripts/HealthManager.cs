using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {

	public Image healthBar;
	public static int playerHealth;
	public int maxHealth;
	public bool isDead;
	private LifeManager lifeManager;
	private LevelManager levelManager;

	// Use this for initialization
	void Start () {
		//text = GetComponent<Text> ();
		playerHealth = PlayerPrefs.GetInt ("PlayerCurrentHealth");
		levelManager = FindObjectOfType<LevelManager> ();
		lifeManager = FindObjectOfType<LifeManager> ();
		isDead = false;
		healthBar.fillAmount = 100f;
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
		float playerHealthFloat = playerHealth;
		float maxHealthFloat = maxHealth;
		float health = playerHealthFloat / maxHealthFloat;
		Debug.Log ("Current Health: "+health+" / Max Health: "+maxHealth+" / Player Health: "+playerHealth);
		healthBar.fillAmount = health;
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
