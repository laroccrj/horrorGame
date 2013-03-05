using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour
{
	
	public float zSpeed;
	public float xSpeed;
	public float maxVelocity = 10.0f;
	public bool sprinting = false;
	public float sprintIncrease;
	public float sprintEnergy;
	public float minEnergy;
	private bool moved = false;
	private float maxSprintEnergy;
	public bool recover = false;
	
	void Awake ()
	{
		maxSprintEnergy = sprintEnergy;	
	}
	
	void FixedUpdate ()
	{	
		
		float zForce = zSpeed;
		float xForce = xSpeed;
		
		sprinting = false;
		if (Input.GetKey (KeyCode.LeftShift) && sprintEnergy > 0 && !recover) {
			sprinting = true;
			xForce *= sprintIncrease;
			zForce *= sprintIncrease;
			sprintEnergy--;
		} else if (sprintEnergy < maxSprintEnergy) {
			sprintEnergy++;			
			recover = sprintEnergy < minEnergy;
		}
		
		if (Input.GetKey ("w")) {
			rigidbody.AddForce (transform.TransformDirection (Vector3.forward) * zForce);
			moved = true;
		}
		
		if (Input.GetKey ("s")) {
			rigidbody.AddForce (transform.TransformDirection (Vector3.back) * zForce);
			moved = true;
		}
		
		if (Input.GetKey ("a")) {
			rigidbody.AddForce (transform.TransformDirection (Vector3.left) * xForce);
			moved = true;
		}
		
		if (Input.GetKey ("d")) {
			rigidbody.AddForce (transform.TransformDirection (Vector3.right) * xForce);
			moved = true;
		}
		
		Vector3 velocity = rigidbody.velocity;
		float magnitude = velocity.magnitude;
		
		if (sprinting) {
			
			if (magnitude > maxVelocity * sprintIncrease) {
				velocity *= (maxVelocity / magnitude);
				rigidbody.velocity = velocity;
			}
			
		} else {
			
			if (magnitude > maxVelocity) {
				velocity *= (maxVelocity / magnitude);
				rigidbody.velocity = velocity;
			}
		}
		
		if (!moved) {
			rigidbody.velocity = new Vector3 (0, 0, 0);	
		}
	}
}
