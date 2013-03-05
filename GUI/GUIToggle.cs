using UnityEngine;
using System.Collections;

public class GUIToggle : MonoBehaviour {

	public string key;
	public GameObject toToggle;
	
	void Update() {
		//This script is for different GUI elements(Inventory, Pause Menu, etc...)
		//toToggle is the camera for that GUI element
		//key is what key needs to be pressed
		
		//If the key hasn't been pressed, there is no need to do the rest
		if(!Input.GetKeyDown(key)) return;
		
		//Here we check if the object is active
		//If it is, deactivate it and un pause the game
		//If it isn't, activate it and pause the game
		if(toToggle.activeSelf) {
			toToggle.SetActive(false);
			GameStatus.unPause();
		} else if(!GameStatus.paused){
			toToggle.SetActive(true);
			GameStatus.pause();
		}
	}
}
