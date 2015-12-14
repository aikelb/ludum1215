using UnityEngine;
using System.Collections;

public class CreditsManager : MonoBehaviour {
    public CanvasGroup mainCanvas;
    public CanvasGroup creditsCanvas;

    public void showCredits() {
        mainCanvas.alpha = 0;
        creditsCanvas.alpha = 1;
    }

    public void hideCredits() {
        mainCanvas.alpha = 1;
        creditsCanvas.alpha = 0;
    }
}
