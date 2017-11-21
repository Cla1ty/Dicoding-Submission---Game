using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour {
	public GameObject coin;

	float curTime = 0;
	float time = 0;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		curTime += Time.deltaTime;
		if (GameData.isPlaying && curTime >= time) {
			curTime = 0;
			time = Random.Range (1.5f, 2.5f);
			generateNewGround ();
		}
	}

	void generateNewGround(){
		float endPoint = Camera.main.ScreenToWorldPoint (new Vector3(Camera.main.pixelWidth,0)).x;
		float y = Random.Range (-1.5f, 2.5f);
		Transform t = Instantiate (coin, new Vector3 (endPoint, y, 0), Quaternion.identity).transform;
		t.parent = transform;

		if (transform.childCount > 8) {
			Destroy(transform.GetChild(0).gameObject);
		}
	}




}
