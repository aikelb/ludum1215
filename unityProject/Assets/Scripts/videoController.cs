using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class videoController : MonoBehaviour {
    public FadeOutManager fd;
	public GameObject videoElement;
	// Use this for initialization
	void Start () {
		RawImage r = videoElement.GetComponent<RawImage>();
		MovieTexture movie = (MovieTexture)r.texture;

		if (movie.isPlaying) {
			movie.Pause();
		}
		else {
			movie.Play();
		}
        Invoke("videoFinished", 10);
	}
	
	private void videoFinished() {
        fd.DoFadeOut("Game");
    }
}
