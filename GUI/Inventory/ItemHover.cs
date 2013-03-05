using UnityEngine;
using System.Collections;

public class ItemHover : MonoBehaviour {

	void Update () {
		if(CurrentInventory.hovering != null) 
			GetComponent<TextMesh>().text = CurrentInventory.hovering.itemName;
		else 
			GetComponent<TextMesh>().text = "";
	}
}
