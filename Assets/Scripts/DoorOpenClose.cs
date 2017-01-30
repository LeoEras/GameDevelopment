using UnityEngine;
using System.Collections;

public class DoorOpenClose : MonoBehaviour {

	public Sprite doorClosed;
	public Sprite doorOpened;

	// Use this for initialization
	void Start () {
		GetComponent<SpriteRenderer> ().sprite = doorClosed;
	}
	
	// Update is called once per frame
	void Update () {
		if (LevelManager.allCrystalsPicked) {
			GetComponent<SpriteRenderer> ().sprite = doorOpened;
		} else {
			GetComponent<SpriteRenderer> ().sprite = doorClosed;
		}
	}
}
