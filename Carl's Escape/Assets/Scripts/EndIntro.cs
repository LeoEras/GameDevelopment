using UnityEngine;
using System.Collections;

public class EndIntro : MonoBehaviour {
	private DialogManager dMan;
	private DarknessManager darkMan;
	private bool done;

	// Use this for initialization
	void Start () {
		dMan = FindObjectOfType<DialogManager> ();
		darkMan = GetComponent<DarknessManager> ();

		darkMan.DarkenScreen(0.1f);
	}
	
	// Update is called once per frame
	void Update () {
		if(!done && dMan.finishDialog){
			darkMan.LightenScreen(0.01f);
			done = true;
		}
	}
}
