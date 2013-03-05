using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour {

	void Awake () {
		Cameras.inventory = camera;
	}
}
