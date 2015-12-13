using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeOutManager : MonoBehaviour {

	public AnimationCurve fadeCurve;
	public bool fadeIn;
	
	string targetScene;
	CanvasGroup cv;
	
	void Awake () {
		cv = GetComponent<CanvasGroup>();
		if (fadeIn)
			StartCoroutine(Fade(1,0));
	}
	
	void DoFadeOut (string scene) {
		targetScene = scene;
		StartCoroutine(Fade(0, 1));
	}
	
	IEnumerator Fade (float startAlpha, float endAlpha) {
		float elapsedTime = 0;
		float animationTime = 1f;
		while (elapsedTime < animationTime) {
			cv.alpha = Mathf.Lerp(startAlpha, endAlpha, fadeCurve.Evaluate(elapsedTime/animationTime));
			elapsedTime += Time.deltaTime;
			yield return 0;
		}
		cv.alpha = endAlpha;
		if (endAlpha == 1 && targetScene != "")
			SceneManager.LoadScene(targetScene);
	}
	
	void OnEnable () {
		Ship.OnDestroyed += HandleOnDestroyed;
	}
	
	void OnDisable () {
		Ship.OnDestroyed -= HandleOnDestroyed;
	}
	
	void HandleOnDestroyed (Vector3 position) {
		Invoke("GoGameOver", 1);
	}
	
	void GoMenu () {
		DoFadeOut("menu");
	}
	
	void GoGameOver () {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        DoFadeOut("death");
	}
	
}
