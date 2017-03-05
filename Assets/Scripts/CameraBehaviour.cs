using UnityEngine;
using System.Collections;

public class CameraBehaviour : MonoBehaviour {
	public float Upper_Limit;
	public float Lower_Limit;
	public float Right_Limit;
	public float Left_Limit;
	public bool Enable_Limits;
	private GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (Enable_Limits) {
			this.transform.position = new Vector3 (
				Mathf.Clamp (player.transform.position.x, Left_Limit, Right_Limit),
				Mathf.Clamp (player.transform.position.y, Lower_Limit, Upper_Limit),
				-10);
		} else {
			this.transform.position = new Vector3 (
				player.transform.position.x,
				player.transform.position.y,
				-10);
		}
	}
}
