using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {
	public Text txScore;
	public Text txHighScore;
	int highscore;
	// Use this for initialization
	void Start()
	{
		highscore = PlayerPrefs.GetInt("HS", 0);
		if (GameData.score > highscore)
		{
			highscore = GameData.score;
			PlayerPrefs.SetInt("HS", highscore);
		}
		txHighScore.text = "Highscores: " + highscore;
		txScore.text = "Scores: " + GameData.score;
	}
	public void Replay()
	{
		GameData.reset();
		SceneManager.LoadScene("Gameplay");
	}
}
