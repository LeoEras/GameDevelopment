using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadNewArea : MonoBehaviour {
	public string levelToLoad;
	public string exitPoint;
	private PlayerController player;
	private DarknessManager darkMan;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController>();
		darkMan = FindObjectOfType<DarknessManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.name == "player"){
			darkMan.DarkenScreen(1f, 0.1f, levelToLoad);
			player.startPoint = exitPoint;
		}
	}
}
