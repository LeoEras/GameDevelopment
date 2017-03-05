using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadNewArea : MonoBehaviour {
	public string sceneToLoad;
	public string exitPoint;
	private PlayerController player;
	private DarknessManager darkMan;
	private bool isLight;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController>();
		darkMan = FindObjectOfType<DarknessManager> ();
		isLight = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(darkMan.alpha >= 1f && !isLight){
			if(sceneToLoad != ""){
				SceneManager.LoadScene(sceneToLoad, LoadSceneMode.Single);
			}

			darkMan.LightenScreen(0.1f);
			isLight = true;
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.name == "player"){
			darkMan.DarkenScreen(0.1f);
			isLight = false;
			player.startPoint = exitPoint;
		}
	}
}
