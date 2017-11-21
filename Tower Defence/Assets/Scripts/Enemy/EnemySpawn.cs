using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {
	public GameObject enemy;

	Vector3[] point;

	private float curTime = 0;
	private float TIME = 2;

	void Start () {
		point = new Vector3[transform.childCount];
		for (int i = 0; i < transform.childCount; i++) {
			point[i] = transform.GetChild (i).position;
		}
	}

	void FixedUpdate(){
		if (Data.curCount < Data.count) {
			curTime += Time.fixedDeltaTime;
			if (curTime >= TIME) {
				curTime = 0;
				spawn ();
			}
		}
	}
	
	// Update is called once per frame
	void spawn () {
		Data.curCount++;
		GameObject _item = (GameObject)Instantiate(enemy, point[0], Quaternion.identity);
		_item.GetComponent<EnemyMove> ().point = point;
	}
}
