using UnityEngine;
using System.Collections;

public class Play_Sound_Once : Triggerd_Event {
	
	private bool played = false;
	
	public override void Event_Trigger() {
		if(played) return;
		gameObject.audio.Play();
		played = true;
	}
}
