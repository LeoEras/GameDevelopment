using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class EndDialogAndLoad : MonoBehaviour {
	public string sceneToLoad;
	private DialogManager dMan;
	private LoadNewArea loadArea;
	private DarknessManager dm;
	private PlayerController player;
	private NPlayerController nPlayer;
	private PickItem pickZone;
	private UIManager ui;
	private bool inPickZone, isDark, isLight, done;

	// Use this for initialization
	void Start () {
		dMan = FindObjectOfType<DialogManager> ();
		dm = FindObjectOfType<DarknessManager> ();
		pickZone = transform.FindChild("PickZone").GetComponent<PickItem>();

		player = FindObjectOfType<PlayerController> ();
		if(player){
			player.gameObject.SetActive (false);
		}

		ui = FindObjectOfType<UIManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(pickZone.inPickZone && dMan.finishDialog && !done){			
			if(!isDark){
				dm.DarkenScreen(0.05f);
				isDark = true;
			}
		}

		if(dm.alpha >= 1f && !isLight){
			if(sceneToLoad != ""){
				if(player && !player.gameObject.activeSelf){
					player.gameObject.SetActive (true);
					ui.healthBar.gameObject.SetActive(true);
				}
				SceneManager.LoadScene(sceneToLoad, LoadSceneMode.Single);
			}

			dm.LightenScreen(0.05f);
			isLight = true;
			done = true;
		}

	}

}
