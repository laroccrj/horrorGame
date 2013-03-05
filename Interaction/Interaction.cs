using UnityEngine;
using System.Collections;

public class Interaction : MonoBehaviour {
	
	public GameObject cursor;
	public Material interactionCursor;
	
	private CursorImage realCursor;
	
	void Start() {
		realCursor = cursor.GetComponent<CursorImage>();	
	}
	
	void Update() {
		cursor.SetActive(true);
		
		if(GameStatus.paused){
			cursor.SetActive(false);
			return;
		}
		
		RaycastHit hit;
		if(!Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 20) || !hit.collider.gameObject.GetComponent<Interaction_Target>()){
			realCursor.SetCursor();
			return;
		}
		
		Interaction_Target target = (Interaction_Target)hit.collider.gameObject.GetComponent(typeof(Interaction_Target));
		if(!target.interact){
			realCursor.SetCursor();
			return;
		}
		
		realCursor.SetCursor(interactionCursor);
		if(Input.GetMouseButtonDown(0)) {
			target.Action();
		}
	}
}
