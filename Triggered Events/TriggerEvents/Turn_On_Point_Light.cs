using UnityEngine;
using System.Collections;

public class Turn_On_Point_Light : Triggerd_Event {
	
	public override void Event_Trigger() {
		gameObject.light.intensity = 1;	
	}
}
