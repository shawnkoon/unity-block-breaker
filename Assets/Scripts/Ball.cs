using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    [SerializeField]
    private Paddle paddle;
    [SerializeField]
    private float xPush = 2f;
    [SerializeField]
    private float yPush = 15f;
    private Vector2 paddleAndBallOffset;
    private bool ballResting;

    // Use this for initialization
    void Start()
    {
        this.paddleAndBallOffset = transform.position - this.paddle.transform.position;
        this.ballResting = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.ballResting) {
            this.LockBallToPaddle();
            this.LaunchBall();
        }
    }

    private void LaunchBall()
    {
        if (Input.GetMouseButtonDown(0))
        {
            this.ballResting = false;
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(this.xPush, this.yPush);
        }
    }

    private void LockBallToPaddle() =>
        this.transform.position = (Vector2)this.paddle.transform.position + this.paddleAndBallOffset;
}
