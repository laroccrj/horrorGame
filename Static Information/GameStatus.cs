using UnityEngine;
using System.Collections;

static class GameStatus : object {

	public static bool paused = false;
	
	public static void pause() {
		paused = true;
		Time.timeScale = 0;
	}
	
	public static void unPause() {
		paused = false;
		Time.timeScale = 1;
	}
}
