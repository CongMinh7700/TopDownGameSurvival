using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverScore : GameMonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI scoreText;
    protected override void OnEnable()
    {
        this.SetScore();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadScoreText();
    }
    protected virtual void LoadScoreText()
    {
        if (this.scoreText != null) return;
        this.scoreText = transform.GetComponentInChildren<TextMeshProUGUI>();
        Debug.LogWarning(transform.name + "||LoadScoreText||", gameObject);
    }
    protected virtual void SetScore()
    {
        int score = GameManager.Instance.ScoreText();
        this.scoreText.SetText("Score : " + score.ToString());
    }
}
