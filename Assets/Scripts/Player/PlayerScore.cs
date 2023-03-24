using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    private int score;

    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            if (value > 0 && value < 11)
            {
                score = value;
            }
            else
            {
                score = 0;
            }
        }
    }
}
