using UnityEngine;
using System.Collections;

public class BossHealthManager : MonoBehaviour {
	public int MaxHealth;
	public int CurrentHealth;
	private KeepDestroyed kd;
	private BossTrigger bt;
	private bool destroyed;
	private SFXManager sfxMan;

	// Use this for initialization
	void Start () {
		CurrentHealth = MaxHealth;
		kd = GetComponent<KeepDestroyed> ();
		bt = GameObject.Find("bossTrigger").transform.Find("Zone").GetComponent<BossTrigger> ();
		sfxMan = FindObjectOfType<SFXManager> ();
	}

	// Update is called once per frame
	void Update () {
		if(CurrentHealth <= 0 && !destroyed){
			sfxMan.BossDeadEff.Play ();
			sfxMan.BossDeadVoice.Play ();

			kd.AddDestroyedObject(gameObject);
			bt.BossDestroyed ();
			destroyed = true;
			Destroy (gameObject);
		}
	}

	public void HurtEnemy(int damageToGive){
		CurrentHealth -= damageToGive;
	}

	public void SetMaxHealth(){
		CurrentHealth = MaxHealth;
	}
}
