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
		
	}
	
	void HandleOnObstacleDestroyed (Vector3 p, int score) {
		
	}
	
	void HandleOnShipHit (Vector3 p, int hp) {
		
	}
	
	void HandleOnShipHeal (int hp) {
		
	}
	
	void HandleOnShipDestroyed (Vector3 position) {
		
	}
	
}
