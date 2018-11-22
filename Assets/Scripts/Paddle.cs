using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    [SerializeField]
    private float xUnitLength = 16f;
    [SerializeField]
    private float minUnitLength = 1f;
    [SerializeField]
    private float maxUnitLength = 15f;

    // Update is called once per frame
    void Update () {
        var mouseX = Input.mousePosition.x / Screen.width * this.xUnitLength;
        Vector2 paddlePosition = new Vector2(transform.position.x, transform.position.y);
        paddlePosition.x = Mathf.Clamp(mouseX, this.minUnitLength, this.maxUnitLength);

        transform.position = paddlePosition;
    }
}
