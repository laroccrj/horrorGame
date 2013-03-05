using UnityEngine;
using System.Collections;

public class Item_Battery : Item {

	public float charge;
	public float depletionRate;
	
	public void deCharge() {
		if(charge > 0)
			charge -= depletionRate * Time.deltaTime;	
	}
}
