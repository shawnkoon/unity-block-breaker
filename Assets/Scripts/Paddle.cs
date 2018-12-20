using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    [SerializeField]
    private float xUnitLength = 16f;
    [SerializeField]
    private float minUnitLength = 1f;
    [SerializeField]
    private float maxUnitLength = 15f;

    private GameSession gameSession;
    private Ball ball;

    void Start()
    {
        this.gameSession = FindObjectOfType<GameSession>();
        this.ball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 paddlePosition = new Vector2(transform.position.x, transform.position.y);
        paddlePosition.x = Mathf.Clamp(this.GetXPosition(), this.minUnitLength, this.maxUnitLength);
        transform.position = paddlePosition;
    }

    public float GetXPosition()
    {

        if (this.gameSession.IsAutoPlayEnabled())
        {
            return this.ball.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * this.xUnitLength;
        }
    }
}
