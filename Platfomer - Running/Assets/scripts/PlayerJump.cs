using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour {
	private Rigidbody2D rigidbody2D;
	private bool isJump = false;

	// Use this for initialization
	void Start () {
		rigidbody2D = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void jump(){
		if (isJump || !GameData.isPlaying)
			return;
		isJump = true;
		rigidbody2D.AddForce (Vector2.up * 500);
	}
	void OnCollisionEnter2D(Collision2D collision){
		if (collision.gameObject.tag.Equals ("Ground")) {
			isJump = false;
		}
	}
}
