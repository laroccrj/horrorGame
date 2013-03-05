using UnityEngine;
using System.Collections;

public class Item_Recording : Item {

	public AudioClip message;
	public bool newMessage;
	
	void playMessage() {
		//audio.PlayOneShot(message, 1);
	}
}
