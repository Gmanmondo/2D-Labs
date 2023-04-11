using UnityEngine;

public class DelegateSub : MonoBehaviour
{
    private void Start() {
        DelegateMain.scoreChanged += HandleScoreChanged; // Subscribing to the event when you create the object
    }

    private void OnDestroy() {
        DelegateMain.scoreChanged -= HandleScoreChanged; // Unsubscribing when the object gets destroyed
    }

    private void HandleScoreChanged(int newScore) {
        print($"The score has changed by: {newScore}");
    }
}