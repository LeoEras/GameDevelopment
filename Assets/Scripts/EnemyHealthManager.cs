using UnityEngine;
using System.Collections;

public class EnemyHealthManager : MonoBehaviour {

	public int enemyHealth;
	public int pointsOnDeath;
	public GameObject deathEffect;
	public GameObject[] items;
	public int[] itemDropRates;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (enemyHealth <= 0) {
			AudioManager.Main.PlayNewSound ("enemy_dead");
			Instantiate (deathEffect, transform.position, transform.rotation);
			ScoreManager.AddPoints (pointsOnDeath);
			Destroy (gameObject);

			var randomItem = DropRandomItem ();

			if (randomItem < items.Length && randomItem > -1) {
				Instantiate (items[randomItem], transform.position, Quaternion.identity);
			}
		}

	}

	public void InflictDamage (int damage) {
		AudioManager.Main.PlayNewSound ("hurt");
		enemyHealth -= damage;
	}

	public int DropRandomItem () {
		var range = 0;
		for (var i = 0; i < itemDropRates.Length; i++)
			range += itemDropRates[i];
		
		var rand = Random.Range(0, range);
		var top = 0;

		for (var i = 0; i < itemDropRates.Length; i++) {
			top += itemDropRates[i];
			if (rand < top)
				return i;
		}
		return -1;
	}
}
