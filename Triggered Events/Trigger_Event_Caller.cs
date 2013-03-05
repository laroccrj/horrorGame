using UnityEngine;
using System.Collections;

public class Trigger_Event_Caller : MonoBehaviour {

	public GameObject[] ObjectsToTrigger;
	
	 void OnTriggerEnter(Collider other) {
		gameObject.SendMessage("Event_Trigger", SendMessageOptions.DontRequireReceiver);
		
        foreach(GameObject obj in ObjectsToTrigger)
			obj.SendMessage("Event_Trigger", SendMessageOptions.DontRequireReceiver);
    }
}
