using UnityEngine;
using System.Collections;

public class Crosshair : MonoBehaviour {
	
	public float movementSpeed = 2f;
	Vector3 direction;
	
	void Update () {
		direction = Vector3.zero;
		
		if (Input.GetKey(KeyCode.A))
			direction += Vector3.left;
		if (Input.GetKey(KeyCode.D))
			direction += Vector3.right;
		if (Input.GetKey(KeyCode.W))
			direction += Vector3.up;
		if (Input.GetKey(KeyCode.S))
			direction += Vector3.down;
			
		direction = direction.normalized;
		MoveTowards(direction);
	}
	
	void MoveTowards (Vector3 direction) {
		transform.position += direction * Time.deltaTime * movementSpeed;
	}
	
}
