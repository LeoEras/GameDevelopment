using UnityEngine;
using System.Collections;

public class LayerBehaviour : MonoBehaviour {
	public bool child;
	public float offset;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (child) {
			GetComponent<SpriteRenderer> ().sortingOrder = 
				this.transform.parent.gameObject.GetComponent<SpriteRenderer> ().sortingOrder;
		} else {
			GetComponent<SpriteRenderer> ().sortingOrder = 
				Mathf.RoundToInt ((transform.position.y + offset) * -10f);
		}
	}

}
