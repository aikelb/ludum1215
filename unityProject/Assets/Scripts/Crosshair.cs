using UnityEngine;
using System.Collections;

public class Crosshair : MonoBehaviour {
	
	public float movementSpeed = 2f;
	Vector3 direction;

    public Camera c;
	
	void Update () {
        Debug.Log(Input.mousePosition);
		direction = Vector3.zero;
		
		if (Input.GetKey(KeyCode.A) || Input.GetAxis("Mouse X") < 0)
			direction += Vector3.left;
		if (Input.GetKey(KeyCode.D) || Input.GetAxis("Mouse X") > 0)
			direction += Vector3.right;
		if (Input.GetKey(KeyCode.W) || Input.GetAxis("Mouse Y") > 0)
			direction += Vector3.up;
		if (Input.GetKey(KeyCode.S) || Input.GetAxis("Mouse Y") < 0)
			direction += Vector3.down;

        transform.position = c.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 20));

		//direction = direction.normalized;
		//MoveTowards(direction);
	}
	
	void MoveTowards (Vector3 direction) {
		transform.position += direction * Time.deltaTime * movementSpeed;
	}
	
}
