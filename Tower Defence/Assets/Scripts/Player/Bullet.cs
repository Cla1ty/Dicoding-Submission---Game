using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.transform.tag.Equals("Enemy"))
		{
			Destroy (gameObject);
			collision.gameObject.GetComponent<Health> ().attack();
		}
	}
}
