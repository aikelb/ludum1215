using UnityEngine;
using System.Collections;

public class PowerUpManager : MonoBehaviour {
    public GameObject healingPowerUp;
    public int spawnProbability;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnEnable() {
        obstacleActions.OnDestroyed += chanceToSpawnPowerUp;
    }

    void chanceToSpawnPowerUp(Vector3 objectTransform, int score) {
        if (Random.value * 100 < spawnProbability) {
            spawnPowerUpAt(objectTransform);
        }
    }

    void spawnPowerUpAt(Vector3 position) {
        Instantiate(healingPowerUp, position, Quaternion.identity);
    }


}
