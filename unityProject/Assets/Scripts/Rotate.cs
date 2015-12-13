using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

	public bool randomize = false;
	public float speed = 1;
	
	Vector3 direction;

	// Use this for initialization
	void Start () {
		if (randomize) {
			direction = Random.insideUnitSphere;
			speed = Random.value > 0.5 ? 1 : -1;
		} else
			direction = Vector3.forward;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(direction, speed * Time.deltaTime);
	}
}
