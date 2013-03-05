using UnityEngine;
using System.Collections;

public class Item : Interaction_Target {
	
	public string itemName;
	public string description;
	public Material texture;
	public int inventorySlot;
	
	public override void Action(){
		CurrentInventory.addItem(this);
		Renderer[] children = GetComponentsInChildren<Renderer>();
		
		for(int i = 0; i < children.Length; i++)children[i].enabled = false;	
	}
	
	public override bool Equals(System.Object obj){
        if (obj == null) return false;
		
        Item item = obj as Item;
        if ((System.Object)item == null)return false;

        return (inventorySlot == item.inventorySlot);
    }
	
	public override int GetHashCode() {
        return inventorySlot;
    }
}
