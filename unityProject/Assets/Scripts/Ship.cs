using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour {

	public Transform crosshair;
	public float movementSpeed;
	public Gun[] gun;
	Vector3 towardsTarget;
	
	public int currentHealth = 3;
	
	void Update () {
		towardsTarget = crosshair.position - transform.position + Vector3.down;
		towardsTarget.z = 0;
		
		transform.rotation = Quaternion.AngleAxis(-towardsTarget.x * 20, Vector3.forward) * Quaternion.AngleAxis(towardsTarget.y * 20, Vector3.left);
		transform.position += towardsTarget * movementSpeed * Time.deltaTime * towardsTarget.magnitude; 
		
		if (Input.GetKey(KeyCode.Space))
			for (int i = 0; i < gun.Length; i++)
				gun[i].Shoot(crosshair);
	}
	
}
