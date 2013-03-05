using UnityEngine;
using System.Collections;

public class Toggle_Point_Light : Triggerd_Event {

	public GameObject[] ObjectsToTrigger;
	public bool on;
	public float intensity;
	
	void Update() {
		gameObject.light.intensity = on ? intensity : 0;
	}
	
	public override void Event_Trigger() {
		on = !on;
	}
}
