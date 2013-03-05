using UnityEngine;
using System.Collections;

public class Turn_Off_Point_Light : Triggerd_Event {

	public override void Event_Trigger() {
		gameObject.light.intensity = 0;	
	}
}
