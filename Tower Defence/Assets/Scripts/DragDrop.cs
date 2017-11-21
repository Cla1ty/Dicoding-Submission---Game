using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour {
	[HideInInspector]
	public Vector3 screenPoint;

	[HideInInspector]
	public Vector3 offset;

	[HideInInspector]
	public int cost;

	[HideInInspector]
	public bool follow = true;

	private Transform parent;

	private void Update()
	{
		if (follow)
		{
			Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
			Vector3 curPosition = Camera.main.ScreenToWorldPoint (curScreenPoint);
			transform.position = curPosition;
			if (Input.GetMouseButtonUp(0))
			{
				if (parent != null)
				{
					follow = false;
					Data.coin -= cost;
					foreach (Behaviour childCompnent in GetComponentsInChildren<Behaviour>())
						childCompnent.enabled = true;

					enabled = false;
					transform.parent = parent;
					transform.localPosition = Vector3.zero;
				}
				else
				{
					Destroy(gameObject);
					Debug.Log("Meletakkan area yg tidak diijinkan");
				}
			}
		}
	}

	public void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.transform.tag.Equals ("Spawn") && collision.transform.childCount == 0)
		{
			parent = collision.transform;
			Debug.Log ("Enter");
		}
	}

	public void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.transform.tag.Equals("Spawn")&& collision.transform.childCount == 0)
		{
			parent = collision.transform;
			Debug.Log ("Exit");
		}
	}
}
