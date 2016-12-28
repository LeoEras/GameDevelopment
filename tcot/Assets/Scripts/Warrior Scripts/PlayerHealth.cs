using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {
	public Image Bar;
	public float maxHealth = 100f;
	public float currentHealth = 0f;
	public Animator anim;
	public EXOController personaje;

	// Use this for initialization
	void Start () {
		currentHealth = maxHealth;
		anim = this.gameObject.GetComponent<Animator> ();
		anim.SetFloat ("Health", currentHealth);
	}
	
	// Update is called once per frame
	void Update () {
		if (currentHealth == 0) {
			personaje.moveLeft = false;
			personaje.moveRight = false;
			Invoke ("callGameOver", 1);

		}
	}

	public void decreaseHealth (float amount){
		if (currentHealth-amount<0f) {
			currentHealth = 0f;
		} else {
			currentHealth -= amount;
		}
		float calc_health = currentHealth / maxHealth;
		setHealth (calc_health,currentHealth);
	}

	public void increaseHealth (float amount){
		if (currentHealth+amount<maxHealth) {
			currentHealth = maxHealth;
		} else {
			currentHealth += amount;
		}
		float calc_health = currentHealth / maxHealth;
		setHealth (calc_health,currentHealth);
	}

	public void setHealth (float health, float current){
		Bar.fillAmount = health;
		anim.SetFloat ("Health", currentHealth);
	}

	void callGameOver(){
		SceneManager.LoadScene ("gameOver");
	}
}
