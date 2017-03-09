﻿using UnityEngine;
using System.Collections;

public class ScrollingBackgroundScript : MonoBehaviour {
	public bool scrolling, parallax;
	public float backgroundSize;
	public float parallaxSpeed;
	public float yIndex;
	public float zIndex;

	private Transform cameraTransform;
	private Transform[] layers;
	private float viewZone = 10;
	private int leftIndex;
	private int rightIndex;
	private float lastCameraX;

	// Use this for initialization
	void Start () {
		cameraTransform = Camera.main.transform;
		lastCameraX = cameraTransform.position.x;
		layers = new Transform[transform.childCount];
		for (int i = 0; i < transform.childCount; i++) {
			layers [i] = transform.GetChild (i);
		}
		leftIndex = 0;
		rightIndex = layers.Length - 1;
	}

	private void ScrollLeft () {
		int lastRight = rightIndex;
		layers [rightIndex].position = Vector3.right * (layers [leftIndex].position.x - backgroundSize);
		layers [rightIndex].position = new Vector3 (layers [rightIndex].position.x, yIndex, zIndex);
		leftIndex = rightIndex;
		rightIndex--;
		if (rightIndex < 0) {
			rightIndex = layers.Length - 1;
		}
	}

	private void ScrollRight () {
		int lastLeft = leftIndex;
		layers [leftIndex].position = Vector3.right * (layers [rightIndex].position.x + backgroundSize);
		layers [leftIndex].position = new Vector3 (layers [leftIndex].position.x, yIndex, zIndex);
		rightIndex = leftIndex;
		leftIndex++;
		if (leftIndex == layers.Length) {
			leftIndex = 0;
		}
	}

	// Update is called once per frame
	void Update () {
		if (parallax) {
			float deltaX = cameraTransform.position.x - lastCameraX;
			transform.position += Vector3.right * (deltaX * parallaxSpeed);
			transform.position = new Vector3(transform.position.x, yIndex, zIndex);
		}

		lastCameraX = cameraTransform.position.x;

		if (scrolling) {
			if (cameraTransform.position.x < (layers[leftIndex].transform.position.x + viewZone))
				ScrollLeft ();
			if (cameraTransform.position.x > (layers[rightIndex].transform.position.x - viewZone))
				ScrollRight ();
		}
	}
}
