using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField]
    private AudioClip destroySound;

    [SerializeField]
    private GameObject blockSparkleVFX;

    [SerializeField]
    private int health;

    [SerializeField]
    private Sprite[] blockSprites;

    private Level level;
    private GameSession gameStatus;

    private void Start()
    {
        this.level = FindObjectOfType<Level>();
        this.gameStatus = FindObjectOfType<GameSession>();
        if (this.tag == "Breakable")
        {
            this.level.RegisterBlock();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (this.tag == "Breakable")
        {
            AudioSource.PlayClipAtPoint(destroySound, Camera.main.transform.position);
            this.health--;
            if (this.health == 0)
            {
                Destroy(this.gameObject);
                this.SparkleBlock();
                this.gameStatus.IncrementScore();
                this.level.UnRegisterBlock();
            }
            else
            {
                GetComponent<SpriteRenderer>().sprite = this.blockSprites[this.health - 1];
            }
        }
    }

    public void SparkleBlock()
    {
        var sparkleObject = Instantiate(this.blockSparkleVFX, this.transform.position, this.transform.rotation);
        Destroy(sparkleObject, 1f);
    }
}
