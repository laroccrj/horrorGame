using UnityEngine;
using System.Collections;

public class Hand : Spot {
	
	public GameObject itemHolder;
	
	public override bool setItem(Item item) {		
		if(	(System.Object)CurrentInventory.getHand() != null) return false;
		
		CurrentInventory.setHand(item);
		return true;	
		
	}
	
	void Update () {
		if((System.Object)CurrentInventory.getHand() == null) return;
		
		GameObject holder = (GameObject)Instantiate( itemHolder, transform.position + Vector3.back, transform.rotation);
		holder.transform.parent = transform;
		holder.GetComponent<ItemHolder>().item = CurrentInventory.getHand();
	}
}
