using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Matcher : MonoBehaviour {
	string name;
	private Vector3 position = Vector3.back;

	public AudioClip audioBenar;
	public AudioClip audioSalah;

	private AudioSource mediaPlayerBenar;
	private AudioSource mediaPlayerSalah;

	void Start(){
		name = GetComponent<SpriteRenderer> ().sprite.name;
		Debug.Log ("Name: " + name);

		mediaPlayerBenar = gameObject.AddComponent<AudioSource> ();
		mediaPlayerBenar.clip = audioBenar;

		mediaPlayerSalah = gameObject.AddComponent<AudioSource> ();
		mediaPlayerSalah.clip = audioSalah;
	}

	void OnTriggerEnter2D(Collider2D collision){
		if (collision.tag.Equals ("Board")) {
			if (collision.GetComponent<SpriteRenderer> ().sprite.name.Equals (name)) {
				position = collision.transform.position;
				Debug.Log("Collision ENTER " + position);
			}
		}
	}

	void OnTriggerExit2D(Collider2D collision){
		if (collision.tag.Equals ("Board")) {
			if (collision.GetComponent<SpriteRenderer> ().sprite.name.Equals (name)) {
				Debug.Log("Collision UP " + transform.position);
				position = Vector3.back;
			}
		}
	}

	void OnMouseUp(){
		if (position != Vector3.back) {

			Debug.Log ("MOUSE UP " + position);
			transform.position = position;
			Destroy (gameObject.GetComponent<BoxCollider2D> ());
			Debug.Log ("MOUSE UP " + transform.position);

			Data.currentCount++;
			if (Data.count == Data.currentCount) {
				SceneManager.LoadScene ("Gameover", LoadSceneMode.Single);
			}

			mediaPlayerBenar.Play ();
		} else {
			mediaPlayerSalah.Play ();
		}

	}
}
