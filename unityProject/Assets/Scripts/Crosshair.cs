using UnityEngine;
using System.Collections;

public class Crosshair : MonoBehaviour {
	
	public float movementSpeed = 2f;
	Vector3 direction;
	
	void Awake () {
        Cursor.lockState = CursorLockMode.Locked;
    }

	
	void Update () {
		direction = Vector3.zero;
        if (Input.GetKey(KeyCode.A) || (Input.GetAxis("Mouse X") < -0.5f && Input.GetAxis("Mouse X") != 0))
            direction += Vector3.left;
		if (Input.GetKey(KeyCode.D) || Input.GetAxis("Mouse X") > 0.5f)
			direction += Vector3.right;
        if (Input.GetKey(KeyCode.W) || Input.GetAxis("Mouse Y") > 0.5f)
            direction += Vector3.up;
		if (Input.GetKey(KeyCode.S) || (Input.GetAxis("Mouse Y") < -0.5f && Input.GetAxis("Mouse Y") != 0))
			direction += Vector3.down;


        if (Input.GetKey(KeyCode.Escape)) {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        if (Input.GetButton("Fire1") || Input.GetKey(KeyCode.Space)) {
            Cursor.lockState = CursorLockMode.Locked;
        }

        float mouseMovementSpeed = (Mathf.Abs(Input.GetAxis("Mouse X")) + Mathf.Abs(Input.GetAxis("Mouse Y"))) * 0.55f;
        mouseMovementSpeed = Mathf.Clamp(mouseMovementSpeed, 1f, 5.5f);
        direction = direction.normalized * mouseMovementSpeed;
        MoveTowards(direction);

        transform.position = new Vector3(
			Mathf.Clamp(transform.position.x , -5f , 5f),
			Mathf.Clamp(transform.position.y ,-3f ,7f),
			10
			);
	}
	
	void MoveTowards (Vector3 direction) {
		transform.position += direction * Time.deltaTime * movementSpeed;
	}
	
}
