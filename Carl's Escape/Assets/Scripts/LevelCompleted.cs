using UnityEngine;
using System.Collections;

public class LevelCompleted : MonoBehaviour {
	private UIManager canvas;
	private PlayerController player;

	// Use this for initialization
	void Start () {
		canvas = FindObjectOfType<UIManager> ();
		player = FindObjectOfType<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag == "Player"){
			player.canMove = false;
			canvas.transform.FindChild ("LvlCompl").gameObject.SetActive(true);
		}
	}
}
