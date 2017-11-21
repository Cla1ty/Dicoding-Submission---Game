using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fire : MonoBehaviour {
	public Rigidbody2D peluru;
	[Range(0,100)]
	public float speed = 30;

	public int fireRate = 2;
	private float time = 0;
	private float curTime = 0;

	// Use this for initialization
	void Start () {
		time = 1 / (float)fireRate;
	}

	// Update is called once per frame
	void Update () {
		if (GameObject.FindGameObjectsWithTag ("Enemy").Length == 0) {
			if (Data.curCount == Data.count) {
				Data.isGameOver = false;
				SceneManager.LoadScene ("Gameover");
			}
			return;
		}

		curTime += Time.deltaTime;
		if (curTime >= time)
		{
			curTime = 0;

			if (Time.timeScale == 0)
				return;

			Rigidbody2D peluruBaru = (Rigidbody2D)GameObject.Instantiate(peluru, transform.position, transform.rotation);
			peluruBaru.velocity = transform.TransformDirection(Vector3.up * speed);
			Destroy(peluruBaru.gameObject,3);

		}
	}
}
