using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour {

	public delegate void _HealUp (int currentHp);
	public static event _HealUp OnHealUp;

	public Transform crosshair;
	public float movementSpeed;
	public Gun[] gun;
	Vector3 towardsTarget;
	public int currentHealth = 3;
	
	void Update () {
		towardsTarget = crosshair.position - transform.position + Vector3.down;
		towardsTarget.z = 0;
		
		transform.rotation = Quaternion.AngleAxis(-towardsTarget.x * 20, Vector3.forward) * Quaternion.AngleAxis(towardsTarget.y * 20, Vector3.left);
		transform.position += towardsTarget.normalized * movementSpeed * Time.deltaTime * towardsTarget.magnitude; 

		if (Input.GetKey(KeyCode.Space))
			for (int i = 0; i < gun.Length; i++)
				gun[i].Shoot(crosshair);
	}
	
	void LateUpdate () {
		transform.position = new Vector3(
			Mathf.Clamp(transform.position.x ,-5f ,5f),
			Mathf.Clamp(transform.position.y ,-4f ,5f),
			0
			);
	}

    void HealUp() {
        if (currentHealth < 3) {
			currentHealth++;
			if (OnHealUp != null)
				OnHealUp(currentHealth);
		}
    }
	
}
