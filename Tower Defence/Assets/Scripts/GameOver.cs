using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {
	float timer = 0;
	public Text text;

	// Use this for initialization
	void Start ()
	{
		Debug.Log ("GameOver " + Data.isGameOver);
		text.text = Data.isGameOver ? "You Lose" : "You Win";
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer > 3) {
			Data.reset ();
			SceneManager.LoadScene ("Gameplay", LoadSceneMode.Single);
		}
	}
}
