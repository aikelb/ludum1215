using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour {

	public AudioClip obstacleHit;
	public AudioClip obstacleDestroyed;
	public AudioClip weaponShoot;
	public AudioClip shipHit;
	public AudioClip shipDestroyed;
	public AudioClip shipHealed;
	
	Dictionary<AudioClip, int> priority;

	AudioSource aSource;
	
	float[] stamps;
	
	void Awake () {
		aSource = GetComponent<AudioSource>();
		stamps = new float[] {0,0,0,0,0};
		priority = new Dictionary<AudioClip, int>();
		priority.Add(obstacleHit, 0);
		priority.Add(obstacleDestroyed, 1);
		priority.Add(weaponShoot, 2);
		priority.Add(shipHit, 3);
		priority.Add(shipDestroyed, 4);
	}
	
	void OnEnable () {
		Gun.OnShoot += HandleOnShoot;
		obstacleActions.OnGotShot += HandleOnObstacleShoot;
		obstacleActions.OnDestroyed += HandleOnObstacleDestroyed;
		Ship.OnHit += HandleOnShipHit;
		Ship.OnHealUp += HandleOnShipHeal;
		Ship.OnDestroyed += HandleOnShipDestroyed;
	}
	
	void OnDisable () {
		Gun.OnShoot -= HandleOnShoot;
		obstacleActions.OnGotShot -= HandleOnObstacleShoot;
		obstacleActions.OnDestroyed -= HandleOnObstacleDestroyed;
		Ship.OnHit -= HandleOnShipHit;
		Ship.OnHealUp -= HandleOnShipHeal;
		Ship.OnDestroyed -= HandleOnShipDestroyed;
	}
	
	void HandleOnShoot () {
		Play(weaponShoot);
	}
	
	void HandleOnObstacleShoot (Vector3 p) {
		Play(obstacleHit);
	}
	
	void HandleOnObstacleDestroyed (Vector3 p, int score) {
		Play(obstacleDestroyed);
	}
	
	void HandleOnShipHit (Vector3 p, int hp) {
		Play(shipHit);
	}
	
	void HandleOnShipHeal (int hp, Vector3 p) {
		Play(shipHealed);
	}
	
	void HandleOnShipDestroyed (Vector3 position) {
		Play(shipDestroyed);
	}
	
	void Play (AudioClip a) {
		if (a == null)
			return;
		if (Time.time - stamps[priority[a]] > 0.05f) {
			stamps[priority[a]] = Time.time;
			aSource.PlayOneShot(a);
		}
	}
	
}
