using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class videoController : MonoBehaviour {
    public FadeOutManager fd;
	// Use this for initialization
	void Start () {
        Invoke("videoFinished", 2);
	}
	
	private void videoFinished() {
        fd.DoFadeOut("Game");
    }
}
