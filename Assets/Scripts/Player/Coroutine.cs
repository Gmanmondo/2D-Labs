using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coroutine : MonoBehaviour
{
    private PlayerScore playerScore;

    void Start()
    {
        playerScore = GetComponent<PlayerScore>();
        StartCoroutine(IncrementScore());
    }

    private IEnumerator IncrementScore()
    {
        print(playerScore.Score);
        playerScore.Score++;
        yield return new WaitForSeconds(1f);
        StartCoroutine(IncrementScore());
    }
}
