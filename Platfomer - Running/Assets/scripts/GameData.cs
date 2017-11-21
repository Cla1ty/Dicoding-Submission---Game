using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData {
	public static bool isPlaying = false;
	public static int score = 0;

	public static void reset(){
		isPlaying = false;
		score = 0;
	}
}
