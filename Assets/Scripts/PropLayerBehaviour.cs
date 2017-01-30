using UnityEngine;
using System.Collections;

public class PropLayerBehaviour : MonoBehaviour {
	private SortingLayer layer;
	public GameObject player;
	private SpriteRenderer sprite;
	public float offset;

	// Use this for initialization
	void Start () {
		sprite = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (player.transform.position.y > (this.transform.position.y + offset)) {
			sprite.sortingLayerName = "Props_Front";
		} else {
			sprite.sortingLayerName = "Props_Back";
		}
		transform.rotation = Quaternion.Euler(0, 0, 0);
	}

}
