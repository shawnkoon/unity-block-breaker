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
    [SerializeField]
    private AudioClip[] audios;
    [SerializeField]
    private float randomFactor = 0.2f;

    private Vector2 paddleAndBallOffset;
    private bool ballResting;
    private AudioSource audioSource;
    private Rigidbody2D rigidBodySource;

    // Use this for initialization
    void Start()
    {
        this.paddleAndBallOffset = base.transform.position - this.paddle.transform.position;
        this.ballResting = true;
        this.audioSource = base.GetComponent<AudioSource>();
        this.rigidBodySource = base.GetComponent<Rigidbody2D>();
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
            this.rigidBodySource.velocity = new Vector2(this.xPush, this.yPush);
        }
    }

    private void LockBallToPaddle() =>
        base.transform.position = (Vector2)this.paddle.transform.position + this.paddleAndBallOffset;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!this.ballResting)
        {
            AudioClip randomAudio = this.audios[Random.Range(0, this.audios.Length)];
            this.audioSource.PlayOneShot(randomAudio);
            this.rigidBodySource.velocity += new Vector2(
                Random.Range(0, this.randomFactor),
                Random.Range(0, this.randomFactor));
        }
    }
}
