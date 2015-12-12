using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	
	public AnimationCurve c;
	float elapsedTime = 0;
	float animationTime = 0.25f;
	
	public void SetTarget (Vector3 position) {
		StartCoroutine(Go(position));
	}
	
	IEnumerator Go (Vector3 targetPosition) {
		Vector3 initPosition = transform.position;
		while (elapsedTime < animationTime) {
			elapsedTime += Time.deltaTime;
			transform.position = Vector3.Lerp(initPosition, targetPosition, elapsedTime/animationTime);
			yield return 0;
		}
		transform.position = targetPosition;
		Destroy(gameObject);
	}
	
	void OnTriggerEnter (Collider other) {
		if (other.CompareTag("Obstacle")) {
			other.SendMessage("GotShot");
		}
	}
	
}
