using UnityEngine;
using System.Collections;

public class CursorImage : MonoBehaviour {
	
	public Material normalMaterial;
	
	void Update () {
		//Here the scripts sees if there is an item in the hand, if there is, we are going to apply that texture to the cursor 

		
		if((System.Object)CurrentInventory.getHand() == null) return;
		
		Item item = CurrentInventory.getHand();
		renderer.material = item.texture;
	}
	
	public void SetCursor() {
		//This is so other scripts can reset the cursor to the normal cursor
		
		renderer.material = normalMaterial;
	}
	
	public void SetCursor(Material material) {
		//This is so other scripts can set the cursor. i.e. when
		//when it changes to a hand when we can interact with something
		
		renderer.material = material;
	}
}
