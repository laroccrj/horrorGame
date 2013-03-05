using UnityEngine;
using System.Collections;

public class InventorySlot : Spot {
	
	public override bool setItem(Item item) {
		item.inventorySlot = id;
		if(CurrentInventory.getItems().Contains(item)) return false;
		
		CurrentInventory.addItem(item);
		return true;
	}
}
