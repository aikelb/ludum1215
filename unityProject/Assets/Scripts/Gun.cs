using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

	public GameObject bulletPrefab;
	public float coolDown = 0.25f;
	float lastStamp = 0;

	public void Shoot (Transform target) {
		if (Time.time - lastStamp < coolDown)
			return;
		
		lastStamp = Time.time;
		
		GameObject go = Instantiate(
			bulletPrefab, 
			transform.position, 
			Quaternion.identity) as GameObject;
		go.transform.LookAt(target);
		go.GetComponent<Bullet>().SetTarget(target.position);
		Debug.Log("Pew pew!");
	}
	
}
