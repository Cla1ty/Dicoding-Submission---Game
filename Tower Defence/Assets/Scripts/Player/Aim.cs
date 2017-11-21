using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		GameObject[] enemy = GameObject.FindGameObjectsWithTag ("Enemy");
		if (enemy.Length > 0) {
			lookAt (enemy [0].transform.position);
		}
	}



	void lookAt(Vector3 position){
		Vector3 diff = position - transform.position;
		diff.Normalize();

		float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
		transform.localEulerAngles = new Vector3 (0, 0, rot_z - 90);
	}
}
