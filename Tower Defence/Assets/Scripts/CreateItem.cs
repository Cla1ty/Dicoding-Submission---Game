using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CreateItem : MonoBehaviour {
	public GameObject item;
	public int cost = 100;

	private Vector3 screenPoint;
	private Vector3 offset;

	private void OnMouseDown()
	{
		if (Data.coin >= cost)
		{
			Debug.Log("Create Item");
			GameObject _item = (GameObject)Instantiate(item, transform.position, Quaternion.identity);
			foreach (Behaviour childCompnent in _item.transform.GetChild(0).GetComponentsInChildren<Behaviour>())
				childCompnent.enabled = false;
			screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
			offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
				Input.mousePosition.y, screenPoint.z));
			Debug.Log ("OFF" + offset);

			DragDrop dd = _item.GetComponent<DragDrop>();
			dd.enabled = true;
			dd.screenPoint = screenPoint;
			dd.offset = offset;
			dd.cost = cost;
		}
		else
		{
			Debug.Log("Koin Tidak cukup");
		}
	}
}
