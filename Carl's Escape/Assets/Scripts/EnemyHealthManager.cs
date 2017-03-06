using UnityEngine;
using System.Collections;

public class EnemyHealthManager : MonoBehaviour {

	public int MaxHealth;
	public int CurrentHealth;
	private SFXManager sfxMan;

	// Use this for initialization
	void Start () {
		CurrentHealth = MaxHealth;
		sfxMan = FindObjectOfType<SFXManager> ();
	}

	// Update is called once per frame
	void Update () {
		if(CurrentHealth <= 0){
			sfxMan.zombieDead.Play ();
			Destroy (transform.gameObject);
		}
	}

	public void HurtEnemy(int damageToGive){
		CurrentHealth -= damageToGive;
	}

	public void SetMaxHealth(){
		CurrentHealth = MaxHealth;
	}
}
