using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField]
    private AudioClip destroySound;

    [SerializeField]
    private GameObject blockSparkleVFX;

    private Level level;
    private GameSession gameStatus;

    private void Start()
    {
        this.level = FindObjectOfType<Level>();
        this.gameStatus = FindObjectOfType<GameSession>();
        this.level.RegisterBlock();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        AudioSource.PlayClipAtPoint(destroySound, Camera.main.transform.position);
        Destroy(this.gameObject);
        this.SparkleBlock();
        this.gameStatus.IncrementScore();
        this.level.UnRegisterBlock();
    }

    public void SparkleBlock()
    {
        var sparkleObject = Instantiate(this.blockSparkleVFX, this.transform.position, this.transform.rotation);
        Destroy(sparkleObject, 1f);
    }
}
