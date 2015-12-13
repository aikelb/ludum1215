using UnityEngine;
using System.Collections;

public class FxManager : MonoBehaviour {

	public GameObject obstacleGotShot;
	public GameObject obstacleDestroyed;
	public GameObject shiphit;
	public GameObject shipheal;
	public GameObject shipdestroyed;
	
	void OnEnable () {
		obstacleActions.OnGotShot += HandleOnObstacleShoot;
		obstacleActions.OnDestroyed += HandleOnObstacleDestroyed;
		Ship.OnHit += HandleOnShipHit;
		Ship.OnHealUp += HandleOnShipHeal;
		Ship.OnDestroyed += HandleOnShipDestroyed;
	}
	
	void OnDisable () {
		obstacleActions.OnGotShot -= HandleOnObstacleShoot;
		obstacleActions.OnDestroyed -= HandleOnObstacleDestroyed;
		Ship.OnHit -= HandleOnShipHit;
		Ship.OnHealUp -= HandleOnShipHeal;
		Ship.OnDestroyed -= HandleOnShipDestroyed;
	}
	
	void HandleOnObstacleShoot (Vector3 position) {
		SetParticle(obstacleGotShot, position);
	}
	
	void HandleOnObstacleDestroyed (Vector3 p, int score) {
		SetParticle(obstacleDestroyed, p);
	}
	
	void HandleOnShipHit (int hp, Vector3 p) {
		SetParticle(shiphit, p);
	}
	
	void HandleOnShipHeal (int hp, Vector3 position) {
		SetParticle(shiphit, position);
	}
	
	void HandleOnShipDestroyed (Vector3 position) {
		SetParticle(shipdestroyed, position);
	}
	
	void SetParticle (GameObject prefab, Vector3 p) {
		if (prefab == null)
			return;
		GameObject go = GameObject.Instantiate(prefab, p, Quaternion.identity) as GameObject;
		Destroy(go, 2);
	}
	
}
