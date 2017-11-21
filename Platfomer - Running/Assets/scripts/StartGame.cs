using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour {

	public Text text;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!GameData.isPlaying &&Input.GetMouseButtonDown (0)) {
			GameData.isPlaying = true;
			text.enabled = false;
		}
	}
}
