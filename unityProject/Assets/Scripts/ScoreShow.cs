using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreShow : MonoBehaviour {
    public GameObject scoreTextObject;

	// Use this for initialization
	void Start () {
        changeScoreText(PlayerPrefs.GetFloat("Score"));
	}
	
	void changeScoreText(float score) {
        scoreTextObject.GetComponent<Text>().text = score.ToString();
    }
}
