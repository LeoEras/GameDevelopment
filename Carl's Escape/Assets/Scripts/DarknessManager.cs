using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class DarknessManager : MonoBehaviour {
	private bool darken, lighten;
	private Image darkScreen;
	private float alpha;
	private float velocity;
	private float maxAlpha;
	private string sceneToLoad;
	private PlayerController player;
	private NPlayerController nPlayer;
	private UIManager ui;

	// Use this for initialization
	void Start () {
		darken = false;
		lighten = false;
		alpha = 0f;
		darkScreen = GetComponent<Image> ();

		player = FindObjectOfType<PlayerController> ();
		if(player){
			player.gameObject.SetActive (false);
		}
			
		nPlayer = FindObjectOfType<NPlayerController> ();
		ui = FindObjectOfType<UIManager> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (lighten) {
			if (alpha > 0f) {
				alpha -= velocity;
				darkScreen.color = new Color (darkScreen.color.r, darkScreen.color.g, darkScreen.color.b, alpha);
			} else { 
				lighten = false;

				if(player){
					player.canMove = true;
				}

				if (nPlayer) {
					nPlayer.canMove = true;
				}
			}
		}

		if (darken) {
			if (alpha < maxAlpha) {
				alpha += velocity;
				darkScreen.color = new Color (darkScreen.color.r, darkScreen.color.g, darkScreen.color.b, alpha);
			} else {
				lighten = true;
				darken = false;

				if(sceneToLoad != ""){
					if(player && !player.gameObject.activeSelf){
						player.gameObject.SetActive (true);
						ui.healthBar.gameObject.SetActive(true);
					}
					SceneManager.LoadScene(sceneToLoad, LoadSceneMode.Single);
				}


			}
		}

	}

	public void DarkenScreen(float max, float vel, string scene){
		darken = true;
		maxAlpha = max;
		velocity = vel;
		sceneToLoad = scene;

		if(player){
			player.canMove = false;
		}

		if (nPlayer) {
			nPlayer.canMove = false;
		}
	}
		
}
