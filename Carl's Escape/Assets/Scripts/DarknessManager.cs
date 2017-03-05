using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class DarknessManager : MonoBehaviour {
	private bool darken, lighten;
	private Image darkScreen;
	public float alpha;
	private float velocity;
	private PlayerController player;
	private NPlayerController nPlayer;

	// Use this for initialization
	void Start () {
		darken = false;
		lighten = false;
		alpha = 0f;
		darkScreen = GetComponent<Image> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (darken) {
			if (alpha < 1f) {
				alpha += velocity;
				darkScreen.color = new Color (darkScreen.color.r, darkScreen.color.g, darkScreen.color.b, alpha);
			} else {
				darken = false;
			}
		}

		if (lighten) {
			if (alpha > 0f) {
				alpha -= velocity;
				darkScreen.color = new Color (darkScreen.color.r, darkScreen.color.g, darkScreen.color.b, alpha);
			} else { 
				lighten = false;

				player = FindObjectOfType<PlayerController> ();
				if(player){
					player.canMove = true;
				}

				nPlayer = FindObjectOfType<NPlayerController> ();
				if (nPlayer) {
					nPlayer.canMove = true;
				}
			}
		}

	}

	public void DarkenScreen(float vel){
		darken = true;
		lighten = false;
		velocity = vel;

		player = FindObjectOfType<PlayerController> ();
		if(player){
			player.canMove = false;
		}

		nPlayer = FindObjectOfType<NPlayerController> ();
		if (nPlayer) {
			nPlayer.canMove = false;
		}
	}

	public void LightenScreen(float vel){
		darken = false;
		lighten = true;
		velocity = vel;
	}
		
}
