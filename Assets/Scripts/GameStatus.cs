using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour {

    [SerializeField]
    [Range(0.1f, 10f)]
    private float gameSpeed = 1f;

    [SerializeField]
    private int scoreScale = 47;

    [SerializeField]
    private int currentScore = 0;

    [SerializeField]
    private TextMeshProUGUI scoreText;

    private void Start()
    {
        this.scoreText.text = this.currentScore.ToString();
    }

    private void Update() => Time.timeScale = this.gameSpeed;

    public void IncrementScore()
    {
        this.currentScore += this.scoreScale;
        this.scoreText.text = this.currentScore.ToString();
    }
}
