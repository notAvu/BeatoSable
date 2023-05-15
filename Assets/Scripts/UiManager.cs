using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UiManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI comboText;
    [SerializeField]
    private TextMeshProUGUI scoreText;
    private void Start()
    {
        ScoreManager.scoreChanged += SetScoreText;
    }
    private void SetScoreText(int score, int combo)
    {
        scoreText.text = $"Score: {score}";
        comboText.text = $"Combo: {combo}";
    }
}
