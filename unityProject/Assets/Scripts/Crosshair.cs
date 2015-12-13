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
		
		transform.position = new Vector3(
			Mathf.Clamp(transform.position.x , -5f , 5f),
			Mathf.Clamp(transform.position.y ,-3f ,7f),
			10
			);
	}
	
	void LateUpdate () {
		
	}
	
	void MoveTowards (Vector3 direction) {
		transform.position += direction * Time.deltaTime * movementSpeed;
	}
	
}
