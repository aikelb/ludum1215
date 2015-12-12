using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

	public delegate void _Shoot ();
	public static event _Shoot OnShoot;

	public GameObject bulletPrefab;
	public float coolDown = 0.25f;
	float lastStamp = 0;

	public void Shoot (Transform target) {
		if (Time.time - lastStamp < coolDown)
			return;
		
		if (OnShoot != null)
			OnShoot();
		
		lastStamp = Time.time;
		
		GameObject go = Instantiate(
			bulletPrefab, 
			transform.position, 
			Quaternion.identity) as GameObject;
		go.transform.LookAt(target);
		go.GetComponent<Bullet>().SetTarget(target.position);
		
	}
	
}
