using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour {
	public GameObject piece;
	public List<Sprite> sprites;

	// Use this for initialization
	void Start () {
		Data.count = sprites.Count;

		Vector2 boxSizeHalf = GetComponent<BoxCollider2D> ().size / 2f;

		int count = sprites.Count;
		while (count != 0) {
			// generate Sprite
			GameObject gameObject = Instantiate(piece);
			int index = Random.Range (0, sprites.Count - 1);
			gameObject.GetComponent<SpriteRenderer> ().sprite = sprites [index];

			// generate Position
			gameObject.transform.position = transform.position + new Vector3 (
				Random.Range (-boxSizeHalf.x, boxSizeHalf.x),
				Random.Range (-boxSizeHalf.y, boxSizeHalf.y),
				0
			);
			sprites.RemoveAt (index);
			count--;
		}
	}
}
