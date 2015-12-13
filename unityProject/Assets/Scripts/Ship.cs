using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour {

	public delegate void _HealUp (int currentHp, Vector3 position);
	public static event _HealUp OnHealUp;

	public delegate void _Hit (Vector3 position, int currentHp);
	public static event _Hit OnHit;
	public delegate void _Destroyed (Vector3 position);
	public static event _Destroyed OnDestroyed;

	public Transform crosshair;
	public float movementSpeed;
	public Gun[] gun;
	Vector3 towardsTarget;
	public int currentHealth = 3;
	
	void Update () {
		towardsTarget = crosshair.position - transform.position + Vector3.down;
		towardsTarget.z = 0;

        towardsTarget.x = Mathf.Clamp(towardsTarget.x, -0.8f, 0.8f);
        towardsTarget.y = Mathf.Clamp(towardsTarget.y, -1f, 1f);
        transform.rotation = Quaternion.AngleAxis(-towardsTarget.x * 20, Vector3.forward) * Quaternion.AngleAxis(towardsTarget.y * 20, Vector3.left);
		transform.position += towardsTarget.normalized * movementSpeed * Time.deltaTime * towardsTarget.magnitude; 

		if (Input.GetButton("Fire1") || Input.GetKey(KeyCode.Space))
			for (int i = 0; i < gun.Length; i++)
				gun[i].Shoot(crosshair);
	}
	
	void LateUpdate () {
		transform.position = new Vector3(
			Mathf.Clamp(transform.position.x ,-8f ,8f),
			Mathf.Clamp(transform.position.y ,-4f ,5f),
			0
			);
	}

    void HealUp() {
        if (currentHealth < 3) {
			currentHealth++;
			if (OnHealUp != null)
				OnHealUp(currentHealth, transform.position);
		}
    }
	
	void Hit () {
		currentHealth--;
		if (currentHealth < 1) {
			if (OnDestroyed != null)
				OnDestroyed(transform.position);
			GetComponent<Collider>().enabled = false;
			enabled = false;
		} else {
			if (OnHit != null)
				OnHit(transform.position, currentHealth);
		}
	}
	
}
