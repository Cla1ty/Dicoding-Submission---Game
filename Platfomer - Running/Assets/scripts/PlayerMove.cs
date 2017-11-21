using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour {
	float speed = 6;

	public Text score;
	private AudioSource audio;

	// Use this for initialization
	void Start () {
		score.text = "Scores : " + GameData.score;
		audio = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
//		if (speed < 6) {
//			speed += Time.fixedDeltaTime / 4;
//			if (speed > 6) {
//				speed = 6;
//			}
//		}

		transform.position += Vector3.right * Time.fixedDeltaTime * speed;
	}

	void OnCollisionEnter2D(Collision2D collision){
		if (collision.transform.tag.Equals ("Obstacle")) {
			SceneManager.LoadScene ("Gameover");
		} 
	}

	void OnTriggerEnter2D(Collider2D collision){
		if (collision.transform.tag.Equals ("Coin")) {
			GameData.score += 10;
			score.text = "Scores : " + GameData.score;
			Destroy (collision.gameObject);
			audio.Play ();
		}
	}
}
