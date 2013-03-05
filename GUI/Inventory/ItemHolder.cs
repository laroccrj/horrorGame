using UnityEngine;
using System.Collections;

public class ItemHolder : MonoBehaviour {
	
	private Vector3 offset;
	private Vector3 screenSpace;
	private Spot[] slots;
	private bool closeEnough = false;
	private Spot closest;
	
	public bool dragging = false;
	public Item item;
	
	void Start() {
		renderer.material = item.texture;	
	}
	
	void OnMouseDown() {
		dragging = true;
		if(transform.parent.GetComponent<InventorySlot>()){
			CurrentInventory.removeItem(item);
		} else if (transform.parent.GetComponent<Hand>()) {
			CurrentInventory.clearHand();	
		} else if (transform.parent.GetComponent<FlashLight>()) {
			CurrentInventory.clearLight();	
		}
		transform.parent = transform.parent.parent;
		slots = transform.parent.GetComponentsInChildren<Spot>();
		screenSpace = Cameras.inventory.WorldToScreenPoint(transform.position);
		offset = transform.position - Cameras.inventory.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y, screenSpace.z));
	}
	
	void OnMouseDrag() {
		Vector3 curScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z); 
		transform.position = Cameras.inventory.ScreenToWorldPoint(curScreenSpace) + offset;
		
		closeEnough = false;
		foreach(Spot slot in slots) {
			Vector3 distance = 	transform.position - slot.transform.position;
			if(Mathf.Abs(distance.x) < .75 && Mathf.Abs(distance.y) < .75){
				if(closeEnough) {
					Vector3 cloststDistance = transform.position - closest.transform.position;
					
					if((Mathf.Abs(distance.x) + Mathf.Abs (distance.y)) < Mathf.Abs(cloststDistance.x) + Mathf.Abs (cloststDistance.y)){
						closest = slot;	
					}
				} else {
					closest = slot;	
				}
				closeEnough = true;
			}
		}
	}
	
	void OnMouseUp() {
		dragging = false;
		
		if(closeEnough) {
			int oldSlot = item.inventorySlot;
			if(!closest.setItem(item)){
				item.inventorySlot = oldSlot;
				CurrentInventory.addItem(item);	
			}
		} else CurrentInventory.addItem(item);		
	}
	
	void OnMouseEnter() {
		CurrentInventory.hovering = item;	
	}
	
	void OnMouseExit() {
		CurrentInventory.hovering = null;
		Debug.Log("test");
	}
	
}
