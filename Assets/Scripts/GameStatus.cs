using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour {

    [SerializeField]
    [Range(0.1f, 10f)]
    private float gameSpeed = 1f;

    [SerializeField]
    private int scoreScale = 47;

    [SerializeField]
    private int currentScore = 0;

    // Update is called once per frame
    private void Update () => Time.timeScale = this.gameSpeed;

    public void IncrementScore()
    {
        this.currentScore += this.scoreScale;
    }
}
