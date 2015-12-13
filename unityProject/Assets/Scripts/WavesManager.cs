using UnityEngine;
using System.Collections;

public class WavesManager : MonoBehaviour
{
    public GameObject[] obstaclesPrefab;
    private int waveCounter;
    private int difficultyLevel;
    public float timeToIncreaseDifficulty = 50f;
    public float timeBetweenWaves = 2f;

    // Use this for initialization
    void Start(){
        StartCoroutine(increaseDifficultyLevel());
        StartCoroutine(startSpawningWaves());
    }

    // Update is called once per frame
    void Update(){

    }

    public IEnumerator increaseDifficultyLevel(){
        while (true){
            difficultyLevel++;
            yield return new WaitForSeconds(timeToIncreaseDifficulty);
        }
    }

    private IEnumerator startSpawningWaves() { 
        while (true){
            GameObject[] obstaclesNextWave = calculateObstaclesNextWave();
            generateAndSpawnNextWave(obstaclesNextWave);
            yield return new WaitForSeconds(timeBetweenWaves);
        }
    }

    private GameObject[] calculateObstaclesNextWave(){
        GameObject[] obstaclesNextWave = new GameObject[3 * difficultyLevel];
        for (int i = 0; i < obstaclesNextWave.Length; i++){
            obstaclesNextWave[i] = getRandomObstaclePrefab();
        }
        return obstaclesNextWave;
    }

    private GameObject getRandomObstaclePrefab(){
        return obstaclesPrefab[Random.Range(0, obstaclesPrefab.Length)];
    }

    private void generateAndSpawnNextWave(GameObject[] obstacles){
        this.GetComponent<obstaclesSpawner>().spawnWave(obstacles);
        waveCounter++;
    }

    public int getDifficultyLevel()
    {
        return difficultyLevel;
    }
}
