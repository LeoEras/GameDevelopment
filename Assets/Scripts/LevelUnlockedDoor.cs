using UnityEngine;
using System.Collections;

public class LevelUnlockedDoor : MonoBehaviour {

	public string levelToLoad;
	public Sprite doorClosed;
	public Sprite doorOpened;

	// Use this for initialization
	void Start () {
		GetComponent<SpriteRenderer> ().sprite = doorClosed;
	}

	// Update is called once per frame
	void Update () {
		if (PlayerPrefs.GetInt(levelToLoad) == 1) {
			GetComponent<SpriteRenderer> ().sprite = doorOpened;
		} else {
			GetComponent<SpriteRenderer> ().sprite = doorClosed;
		}
	}
}
