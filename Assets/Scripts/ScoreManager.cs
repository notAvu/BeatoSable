using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ScoreManager : MonoBehaviour
{
    public int PlayerScore { get; set; }
    public int CurrentCombo { get; set; }
    public static Action<int, int> scoreChanged;
    // Start is called before the first frame update
    void Start()
    {
        SingleHitNote.noteHit += OnNoteHit;
    }

    private void OnNoteHit(NoteHitInfo hitInfo)
    {
        PlayerScore += hitInfo.score;
        if(hitInfo.score <= 0)
        {
            CurrentCombo = 0;
        }
        else
        {
            CurrentCombo++;
        }
        scoreChanged?.Invoke(PlayerScore, CurrentCombo);
    }
    
}
