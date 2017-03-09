using UnityEngine;
using System.Collections;

public class HealthDamageIndicator : MonoBehaviour {

	private EnemyHealthManager enemyHealthManager;
	private SpriteRenderer spriteRenderer;
	private int enemyMaxHealth;

	// Use this for initialization
	void Start () {
		enemyHealthManager = GetComponent<EnemyHealthManager> ();
		enemyMaxHealth = enemyHealthManager.enemyHealth;
		spriteRenderer = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		int enemyHealth = enemyHealthManager.enemyHealth;
		float tintFactor = ((float)enemyHealth / (float)enemyMaxHealth);
		Color newColor = new Color(1f, tintFactor, tintFactor);
		spriteRenderer.color = newColor;
	}
}
