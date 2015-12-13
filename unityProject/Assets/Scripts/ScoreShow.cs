using UnityEngine;
using System.Collections;

public class ScoreShow : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Debug.Log("Hola");
        Debug.Log(PlayerPrefs.GetFloat("Score"));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
