using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour {
    public GameObject scoreTextObject;
    public int currentScore = 0;

    void OnEnable() {
        obstacleActions.OnDestroyed += obstacleDestroyed;
        Ship.OnHit += shipGotHit;
    }

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

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
