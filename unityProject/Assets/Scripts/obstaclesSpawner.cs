using UnityEngine;
using System.Collections;

public class obstaclesSpawner : MonoBehaviour {
    public float randomPositionMultiplier;
    public float avoidCollisionRadius = 5f;
    public float currentEnemiesSpeed = 5f;
    public float speedIncrementAfterWave = 1.05f;

	// Use this for initialization
	void Start () {      	        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void spawnWave(GameObject[] waveToSpawn){
        foreach(GameObject obstacle in waveToSpawn)
        {
            this.spawnNextObstacle(obstacle);
        }
        increaseCurrentEnemiesSpeed();
    }

    private void spawnNextObstacle(GameObject obstacle){
        Vector3 randomSpawnPosition = (Random.insideUnitSphere * randomPositionMultiplier) + this.transform.position;
        if (Physics.OverlapSphere(randomSpawnPosition, avoidCollisionRadius).Length > 0){
            spawnNextObstacle(obstacle);
        }else{
            GameObject spawnedObtacle = Instantiate(obstacle, randomSpawnPosition, Quaternion.identity) as GameObject;
            spawnedObtacle.GetComponent<obstacleActions>().movementSpeed = currentEnemiesSpeed;
        }
    }

    private void increaseCurrentEnemiesSpeed(){
        currentEnemiesSpeed = currentEnemiesSpeed * speedIncrementAfterWave;
    }
}
