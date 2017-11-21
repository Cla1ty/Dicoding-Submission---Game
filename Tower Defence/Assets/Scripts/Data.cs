using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data {
	public static int count = 5;
	public static int curCount = 0;

	public static float coin = 300;
	public static bool isGameOver = false;
	public static bool isComplate = false;

	public static void reset(){
		count = 5;
		curCount = 0;
		coin = 300;
		isGameOver = false;
		isComplate = false;
	}
}
