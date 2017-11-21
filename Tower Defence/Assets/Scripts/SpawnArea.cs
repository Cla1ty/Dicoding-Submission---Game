using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArea : MonoBehaviour {

	private BoxCollider2D box;
	// Use this for initialization
	void Start () {
		box = GetComponent<BoxCollider2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 worldPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		if (box.OverlapPoint (worldPos)) {
		}
	}
}
