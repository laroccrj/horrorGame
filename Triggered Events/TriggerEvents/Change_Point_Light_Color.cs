using UnityEngine;
using System.Collections;

public class Change_Point_Light_Color : Triggerd_Event {
	
	public Color newColor;
	
	public override void Event_Trigger() {
		gameObject.light.color = newColor;
	}
}
