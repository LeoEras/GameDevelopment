using UnityEngine;
using System.Collections;

public class LoadNewArea : MonoBehaviour {
	public string levelToLoad;
	public string exitPoint;
	private PlayerController player;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.name == "player"){
			Application.LoadLevel (levelToLoad);
			player.startPoint = exitPoint;
		}
	}
}
