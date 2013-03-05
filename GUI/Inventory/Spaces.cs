using UnityEngine;
using System.Collections;

public class Spaces : MonoBehaviour {
	
	InventorySlot[] slots;
	public GameObject itemHolder;
	
	void Awake () {
		slots = GetComponentsInChildren<InventorySlot>();
		
		//sort the spots by id
		bool sorted = true;
		
		while(sorted) {
			sorted = false;
			for(int i = 0; i < slots.Length - 1; i++) {
				if(slots[i].id > slots[i + 1].id) {
					InventorySlot holder = slots[i];
					slots[i] = slots[i + 1];
					slots[i + 1] = holder;
					sorted = true;
				}
			}
		}
		
	}
	

	void Update () {
	
		//Turn all slots off
		foreach(ItemHolder item in GetComponentsInChildren<ItemHolder>())
			if(!item.dragging)Destroy(item.gameObject);	
		
		BetterList<Item> items = CurrentInventory.getItems();
		
		foreach(Item item in items) {
			if(item.inventorySlot < slots.Length) {
				InventorySlot slot = slots[item.inventorySlot];
				GameObject holder = (GameObject)Instantiate( itemHolder, slot.transform.position + Vector3.back, slot.transform.rotation);
				holder.transform.parent = slot.transform;
				holder.GetComponent<ItemHolder>().item = item;
			}
		}
	}
}
