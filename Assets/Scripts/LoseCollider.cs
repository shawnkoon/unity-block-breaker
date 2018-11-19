using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour {
    private string gameOverSceneName = "GameOver";
    private void OnTriggerEnter2D(Collider2D other) => SceneManager.LoadScene(gameOverSceneName);
}
