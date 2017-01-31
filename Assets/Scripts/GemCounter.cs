using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GemCounter : MonoBehaviour {

	private Text theText;

	private 

	// Use this for initialization
	void Start () {
		theText = GetComponent<Text> ();
	}

	// Update is called once per frame
	void Update () {
		theText.text = LevelManager.crystalsPicked +" / "+ LevelManager.crystalsToPick_;

		if (LevelManager.crystalsPicked == LevelManager.crystalsToPick_) {
			theText.color = Color.red;
		}
	}
}
