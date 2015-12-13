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
		targetPosition += Random.insideUnitSphere;
		while (elapsedTime < animationTime) {
			elapsedTime += Time.deltaTime;
			transform.position = Vector3.Lerp(initPosition, targetPosition, c.Evaluate(elapsedTime/animationTime));
			yield return 0;
		}
		transform.position = targetPosition;
		elapsedTime = 0;
		transform.rotation = Quaternion.LookRotation(Vector3.forward, Vector3.up);
		initPosition = targetPosition;
        animationTime = 0.70f;
		targetPosition = targetPosition + Vector3.forward * 50;
		while (elapsedTime < animationTime) {
			elapsedTime += Time.deltaTime;
			transform.position = Vector3.Lerp(initPosition, targetPosition, elapsedTime/animationTime);
			yield return 0;
		}
		Destroy(gameObject);
	}
	
	void OnTriggerEnter (Collider other) {
		if (other.CompareTag("Obstacle")) {
			other.SendMessage("GotShot");
		}
	}
	
}
