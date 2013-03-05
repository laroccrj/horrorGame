using UnityEngine;
using System.Collections;

public class Spot : MonoBehaviour {
	
	public int id;
	
	public virtual bool setItem(Item item) {
		return false;
	}
}
