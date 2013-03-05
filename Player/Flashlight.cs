using UnityEngine;
using System.Collections;

public class Flashlight : MonoBehaviour {

	public bool on = false;
	
	void Update () {
		
		if(Input.GetKeyDown("f")) {
			if(on) {
				on = false;
				gameObject.light.intensity = 0;
			} else on = true;
		}
		
		if((System.Object)CurrentInventory.getLight() == null) return;
		
		Item_Battery battery = CurrentInventory.getLight() as Item_Battery;
		
		if(on && battery.charge > 0) {
			gameObject.light.intensity = battery.charge;
			battery.deCharge();
		}
	}
}
