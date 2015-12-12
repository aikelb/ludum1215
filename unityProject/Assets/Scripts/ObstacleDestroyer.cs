using UnityEngine;
using System.Collections;

public class ObstacleDestroyer : MonoBehaviour {

	void OnTriggerEnter (Collider other) {
		if (other.CompareTag("Obstacle"))
			Destroy(other.gameObject);
	}
	
}
