using UnityEngine;

public class DelegateMain : MonoBehaviour
{
    public delegate void OnScoreChanged(int newScore);

    public static event OnScoreChanged scoreChanged;

    private int thisScore;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            thisScore++;

            // Call the event with the updated score value
            scoreChanged?.Invoke(thisScore);
        }
    }
}