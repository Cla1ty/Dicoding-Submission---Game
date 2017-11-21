using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMove : MonoBehaviour {
	public float speed = 2;

	[HideInInspector]
	public Vector3[] point;

	int position = 0;

	void FixedUpdate () {
		float distance = Vector3.Distance (transform.position, point [position]);
		if (distance <= 0.05f) {
			position++;

			if (position == point.Length) {
				Data.isGameOver = true;
				SceneManager.LoadScene ("Gameover");
			} else {
				lookAt (position);
			}
		} else {
			Vector3 move = new Vector3 (point [position].x - transform.position.x,
				point [position].y - transform.position.y,
				0);
			transform.position += move.normalized * Time.fixedDeltaTime * speed;
		}
	}

	void lookAt(int position){
		Vector3 diff = point[position] - transform.position;
		diff.Normalize();

		float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
		transform.localEulerAngles = new Vector3 (0, 0, rot_z + 90);
	}


}
