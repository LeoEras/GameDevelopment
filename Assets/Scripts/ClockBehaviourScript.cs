using UnityEngine;
using System.Collections;

public class ClockBehaviourScript : MonoBehaviour {
	private Transform start;
	private Transform end;
	private RaycastHit2D hit;
	public Sprite Off;
	public LayerMask player;
	private Vector2 initial_position;
	private bool enabled = true;

	// Use this for initialization
	void Start () {
		initial_position = this.transform.position;
		start = this.gameObject.transform.GetChild (0);
		end = this.gameObject.transform.GetChild (1);
	}
		
	// Update is called once per frame
	void Update () {
		Debug.DrawLine (start.transform.position, end.transform.position);
		hit = Physics2D.Linecast(start.transform.position, end.transform.position, player);
		if (hit.collider != null) {
			if (hit.collider.name == "Player") {
				if (enabled) {
					this.GetComponent<AudioSource> ().Play ();
					PlayerController.score = PlayerController.score + 1;
					enabled = false;
				}
				GetComponent<SpriteRenderer> ().sprite = Off;
				this.transform.position = new Vector3 (
					initial_position.x - 0.073f,
					initial_position.y,
					0);
			}
		}
	}
}
