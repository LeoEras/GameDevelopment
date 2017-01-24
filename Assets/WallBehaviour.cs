using UnityEngine;
using System.Collections;

public class WallBehaviour : MonoBehaviour {
	public GameObject player;
	public GameObject wall_tall;
	public GameObject wall_down;
	public GameObject element;
	public bool enabled;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (enabled) {
			if (player.transform.position.y > (this.transform.position.y - 0.1f) &&
				player.transform.position.y < (this.transform.position.y + 2.0f)) {
				wall_tall.SetActive (false);
				wall_down.SetActive (true);
				if (element != null){
					element.SetActive (false);
				}
			} else {
				wall_tall.SetActive (true);
				wall_down.SetActive (false);
				if (element != null){
					element.SetActive (true);
				}
			}
		}
	}
}
