using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public static int score;

	Text text;

	void Start () {
		text = GetComponent<Text>();
		score = PlayerPrefs.GetInt ("PlayerScore");
	}

	void Update () {
		if (score < 0)
			score = 0;

		text.text = score.ToString();
	}

	public static void AddPoints (int pointsToAdd) {
		score += pointsToAdd;
		PlayerPrefs.SetInt ("PlayerScore", score);
	}

	public static void Reset () {
		score = 0;
		PlayerPrefs.SetInt ("PlayerScore", 0);
	}
}
