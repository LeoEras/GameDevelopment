using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SelectOptions : MonoBehaviour {
	private Text nuevo;
	private Text controles;
	private GameObject controlScreen;
	private bool nuevoSelected;
	private bool controlSelected;
	private DarknessManager dm;
	private SFXManager sfxMan;

	// Use this for initialization
	void Start () {
		nuevoSelected = true;
		controlSelected = false;
		sfxMan = FindObjectOfType<SFXManager> ();

		nuevo = transform.FindChild("Nuevo").GetComponent<Text>();
		controles = transform.FindChild("Controles").GetComponent<Text>();
		controlScreen = transform.parent.FindChild ("ControlScreen").gameObject;

		dm = FindObjectOfType<DarknessManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(!nuevoSelected && !controlSelected && dm.alpha>=1f){
			SceneManager.LoadScene ("PB_0", LoadSceneMode.Single);
		}

		if(nuevoSelected){
			if(Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Return)){
				sfxMan.BossDeadEff.Play ();
				dm.DarkenScreen(0.01f);
				nuevoSelected = false;
			}
			if(Input.GetKeyDown(KeyCode.DownArrow)){
				sfxMan.select.Play ();

				nuevoSelected = false;
				controlSelected = true;

				nuevo.text = "Nuevo Juego";
				nuevo.color = new Color (1f, 1f, 1f);

				controles.text = "- Controles -";
				controles.color = new Color (0f, 1f, 0f);

				return;
			}
		}

		if(controlSelected){
			if(Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Return)){
				if (!controlScreen.activeSelf) {
					sfxMan.playerHurt.Play ();
					controlScreen.SetActive (true);
				} else {
					controlScreen.SetActive (false);
				}
			}
			if(Input.GetKeyDown(KeyCode.UpArrow) && !controlScreen.activeSelf){
				sfxMan.select.Play ();

				nuevoSelected = true;
				controlSelected = false;

				nuevo.text = "- Nuevo Juego -";
				nuevo.color = new Color (0f, 1f, 0f);

				controles.text = "Controles";
				controles.color = new Color (1f, 1f, 1f);

				return;
			}
		}
	}
}
