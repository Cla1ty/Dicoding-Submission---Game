using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMove : MonoBehaviour {
	public bool touchEnable = true;

	private Vector3 screenPoint;
	private Vector3 offset;

	void OnMouseDown(){
		if (!touchEnable)
			return;

		screenPoint = Camera.main.WorldToScreenPoint (gameObject.transform.position);

		Vector3 mouseWorldPoint = Camera.main.ScreenToWorldPoint(
			new Vector3(Input.mousePosition.x,
				Input.mousePosition.y,
				screenPoint.z));
		offset = gameObject.transform.position - mouseWorldPoint;
	}

	void OnMouseDrag(){
		if (!touchEnable)
			return;

		Vector3 curScreenPoint = new Vector3 (Input.mousePosition.x,
			Input.mousePosition.y,
			screenPoint.z);
		Vector3 curPosition = new Vector3(
			transform.position.x,
			(Camera.main.ScreenToWorldPoint (curScreenPoint) + offset).y,
			transform.position.z);

		if (curPosition.y < -6) {
			curPosition = new Vector3 (
				curPosition.x,
				-6,
				curPosition.z);
		} else if(curPosition.y > -2){
			curPosition = new Vector3 (
				curPosition.x,
				-2,
				curPosition.z);
		}
		transform.position = curPosition;
	}

	void OnMouseUp(){
//		transform.position = firstPosition;
	}
}
