using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ActionManager : MonoBehaviour {
	public GameObject aBox;
	public Text aText;
	public bool actionActive;
	private GameObject pauseScreen;

	// Use this for initialization
	void Start () {
		pauseScreen = transform.parent.FindChild("Pause").gameObject;
	}

	// Update is called once per frame
	void Update () {
		if(actionActive && Input.GetKeyDown(KeyCode.Z) && !pauseScreen.activeSelf){
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
