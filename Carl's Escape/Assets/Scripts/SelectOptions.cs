using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SelectOptions : MonoBehaviour {
	private Text nuevo;
	private Text controles;
	private GameObject controlScreen;
	private bool nuevoSelected;
	private bool controlSelected;
	private DarknessManager dm;

	// Use this for initialization
	void Start () {
		nuevoSelected = true;
		controlSelected = false;

		nuevo = transform.FindChild("Nuevo").GetComponent<Text>();
		controles = transform.FindChild("Controles").GetComponent<Text>();
		controlScreen = transform.parent.FindChild ("ControlScreen").gameObject;

		dm = FindObjectOfType<DarknessManager> ();
	}
	
	// Update is called once per frame
	void Update () {

		if(nuevoSelected){
			if(Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Return)){
				dm.DarkenScreen(1f, 0.01f, "PB_0");
				nuevoSelected = false;
			}
			if(Input.GetKeyDown(KeyCode.DownArrow)){
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
					controlScreen.SetActive (true);
				} else {
					controlScreen.SetActive (false);
				}
			}
			if(Input.GetKeyDown(KeyCode.UpArrow) && !controlScreen.activeSelf){
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
