using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopBg : MonoBehaviour {
	private Transform curBg;
	private float width;

	// Use this for initialization
	void Start () {
		curBg = transform.GetChild (0);
		Sprite s = curBg.GetComponent<SpriteRenderer> ().sprite;
		width = s.rect.width / s.pixelsPerUnit;
	}
	
	// Update is called once per frame
	void Update () {
		float endPoint = Camera.main.ScreenToWorldPoint (new Vector3(Camera.main.pixelWidth,0)).x;
		if (curBg.position.x + width / 2 < endPoint) {
			curBg = Instantiate (curBg.gameObject, new Vector3 (curBg.position.x + width, curBg.position.y, curBg.position.x), Quaternion.identity).transform;
			curBg.parent = transform;
			if (transform.childCount > 2) {
				Destroy(transform.GetChild(0).gameObject);
			}
		}
	}
}
