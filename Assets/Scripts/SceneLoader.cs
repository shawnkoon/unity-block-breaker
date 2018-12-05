using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader: MonoBehaviour
{
    private GameSession gameStatus;

    private void Start()
    {
        this.gameStatus = FindObjectOfType<GameSession>();
    }
    public void LoadNextScene()
    {
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
        this.gameStatus.DestoryGameSession();
    }

    public void QuitApplication() => Application.Quit();
}
