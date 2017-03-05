using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ActionManager : MonoBehaviour {
	public GameObject aBox;
	public Text aText;
	public bool actionActive;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if(actionActive && Input.GetKeyDown(KeyCode.Z)){
			aBox.SetActive (false);
			actionActive = false;
		}
	}

	public void ShowBox(string action){
		actionActive = true;
		aText.text = "[Z]: "+action;
		aBox.SetActive (true);
	}

	public void HideBox(){
		actionActive = false;
		aBox.SetActive (false);
	}
}
