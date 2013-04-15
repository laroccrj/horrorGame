using UnityEngine;
using System.Collections;

static class CurrentInventory : object {

	private static ArrayList<Item> items = new ArrayList<Item>();
	private static Item hand;
	private static Item flashlight;
	
	public static Item hovering = null;
	
	public static int nextItemSlot() {
		bool found = false;
		int slot = 0;
		
		while(!found) {
			found = true;
			
			foreach(Item item in items) {
				if(item.inventorySlot == slot) {
					found = false;
					slot++;
					break;
				}
			}
		}
		
		return slot;
	}
	
	public static void addItem(Item item) {
		if((System.Object)item.inventorySlot == null || items.Contains(item))
			item.inventorySlot = nextItemSlot();
		
		items.Add(item);
	}
	
	public static void removeItem(Item item) {
		items.Remove(item);	
	}
	
	public static ArrayList<Item> getItems() {
		return items;	
	}
	
	public static Item getHand(){
		return hand;	
	}
	
	public static void setHand(Item newHand){
		hand = newHand;
	}
	
	public static void clearHand() {
		hand = null;
	}
	
	public static Item getLight(){
		return flashlight;	
	}
	
	public static void setLight(Item newLight){
		flashlight = newLight;
	}
	
	public static void clearLight() {
		flashlight = null;
	}
	
	
}
