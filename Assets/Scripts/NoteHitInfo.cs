using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteHitInfo 
{
    private const float PERFECT_HIT_WINDOW = 1f;
    private const float GOOD_HIT_WINDOW = 3;//I should have stablished hit windows by note time/bpm, but I got no time to test it :(

    public float timeDiff;
    public int score;
    public NoteHitInfo(float timeDiff)
    {
        this.timeDiff = timeDiff;
        EvaluateScore();
    }
    private void EvaluateScore()
    {
        score = 0;
        Debug.Log(timeDiff);
        if (timeDiff <= PERFECT_HIT_WINDOW)
        {
            score += 100;
        }
        else if (timeDiff <= GOOD_HIT_WINDOW)
        {
            score += (int)(100 - (100 * timeDiff));
        }
    }
}
