using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour {
	public GameObject ground;
	private Transform curGround;


	int curCount =1;
	int count = 4;

	int generateType = 0;

	// Use this for initialization
	void Start () {
		curGround = Instantiate (ground, new Vector3 (-8, -5, 0), Quaternion.identity).transform;

		float endPoint = Camera.main.ScreenToWorldPoint (new Vector3(Camera.main.pixelWidth,0)).x;
		do {
			generateNewGround (curGround.position.x);
		} while(curGround.position.x < endPoint);
	}
	
	// Update is called once per frame
	void Update () {
		float endPoint = Camera.main.ScreenToWorldPoint (new Vector3(Camera.main.pixelWidth,0)).x;

		if (GameData.isPlaying) {
			if (generateType == 0) {
				if (curGround.position.x + 3 < endPoint) {
					generateNewGround (endPoint);
				}
			} else {
				if (curGround.position.x < endPoint) {
					generateNewGround (curGround.position.x);
				}
			}
		} else {
			if (curGround.position.x < endPoint) {
				generateNewGround (curGround.position.x);
			}
		}
	}

	void generateNewGround(float x){
		float y;
		if (!GameData.isPlaying) {
			y = -5;
			curGround = Instantiate (ground, new Vector3 (x +4, y, 0), Quaternion.identity).transform;
			curGround.parent = transform;
		} else {
			generateType = Random.Range (0, 2);

			float min = curGround.position.y - 1;
			min = Mathf.Clamp (min, -6, min);

			float max = curGround.position.y + 1;
			max = Mathf.Clamp (max, max, -2);

			y = Random.Range (min, max);
			curGround = Instantiate (ground, new Vector3 (x +4, y, 0), Quaternion.identity).transform;
			curGround.parent = transform;
		}

		if (transform.childCount > 8) {
			Destroy(transform.GetChild(0).gameObject);
		}
	}




}
