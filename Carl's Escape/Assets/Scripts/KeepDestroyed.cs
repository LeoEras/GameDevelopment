using UnityEngine;
//using UnityEngine.SceneManagement;
using System.Collections;

public class KeepDestroyed : MonoBehaviour {
	private static Hashtable destroyedObjects = new Hashtable();

	// Use this for initialization
	void Start () {
		var scene = gameObject.scene.name;
		var objName = gameObject.name;
		if ( destroyedObjects.Contains(scene+"_"+objName) ) {
			Destroy (gameObject);
		} 
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void AddDestroyedObject(GameObject obj){
		var scene = obj.scene.name;
		var objName = obj.name;
		destroyedObjects.Add(scene+"_"+objName, obj);
	}
}
