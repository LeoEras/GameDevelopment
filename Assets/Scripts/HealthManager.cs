using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {

	public static int playerHealth;
	public int maxHealth;
	public bool isDead;

	Text text;

	private LevelManager levelManager;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();
		playerHealth = maxHealth;
		levelManager = FindObjectOfType<LevelManager> ();
		isDead = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (playerHealth <= 0 && !isDead) {
			playerHealth = 0;
			levelManager.RespawnPlayer ();
			isDead = true;
		}
		text.text = playerHealth.ToString();
	}

	public static void InflictDamage (int damage) {
		playerHealth -= damage;
	}

	public void ResetHealth () {
		playerHealth = maxHealth;
	}

}
