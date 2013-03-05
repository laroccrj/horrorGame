using UnityEngine;
using System.Collections;

public class FlashLight : Spot {

	public GameObject itemHolder;
	
	public override bool setItem(Item item) {		
		if((System.Object)CurrentInventory.getLight() != null) return false;
		
		if(item is Item_Battery) { 
			CurrentInventory.setLight(item);
			return true;
		}
		
		return false;
	}
	
	void Update () {
		if((System.Object)CurrentInventory.getLight() == null) return;
		
		GameObject holder = (GameObject)Instantiate( itemHolder, transform.position + Vector3.back, transform.rotation);
		holder.transform.parent = transform;
		holder.GetComponent<ItemHolder>().item = CurrentInventory.getLight();
	}
}
