using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour {
    public GameObject scoreTextObject;
    public int currentScore = 0;

    private void shipGotHit(int currentHp, Vector3 position)
    {
        changeScore(-200);
    }

    private void obstacleDestroyed(Vector3 position, int score)
    {
        changeScore(score);
    }

    private void updateScoreText() {
        scoreTextObject.GetComponent<Text>().text = currentScore.ToString();
    }

    private void changeScore(int score)
    {
        currentScore += score;
        if (currentScore < 0) currentScore = 0;
        updateScoreText();
    }

    void OnEnable () {
        obstacleActions.OnDestroyed += obstacleDestroyed;
        Ship.OnHit += shipGotHit;
        Ship.OnDestroyed += HandleOnShipDestroyed;
    }
    
    void OnDisable () {
        Ship.OnDestroyed -= HandleOnShipDestroyed;
        obstacleActions.OnDestroyed -= obstacleDestroyed;
        Ship.OnHit -= shipGotHit;
    }
    
    void HandleOnShipDestroyed (Vector3 position) {
        PlayerPrefs.SetFloat("Score", currentScore);
    }
    
}
