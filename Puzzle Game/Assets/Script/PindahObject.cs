using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PindahObject : MonoBehaviour {
	private Vector3 screenPoint;
	private Vector3 offset;

	private Vector3 firstPosition;

	void OnMouseDown(){
		firstPosition = transform.position;
		screenPoint = Camera.main.WorldToScreenPoint (gameObject.transform.position);

		Vector3 mouseWorldPoint = Camera.main.ScreenToWorldPoint(
			new Vector3(Input.mousePosition.x,
				Input.mousePosition.y,
				screenPoint.z));
		offset = gameObject.transform.position - mouseWorldPoint;
	}

	void OnMouseDrag(){
		Vector3 curScreenPoint = new Vector3 (Input.mousePosition.x,
			                         Input.mousePosition.y,
			                         screenPoint.z);
		Vector3 curPosition = Camera.main.ScreenToWorldPoint (curScreenPoint) + offset;
		transform.position = curPosition;
	}

	void OnMouseUp(){
		transform.position = firstPosition;
	}
}
