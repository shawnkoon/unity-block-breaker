using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField]
    private int breakableBlocks;

    private SceneLoader sceneLoader;

    private void Start() {
        this.sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void RegisterBlock()
    {
        this.breakableBlocks++;
    }

    public void UnRegisterBlock()
    {
        this.breakableBlocks--;

        if (this.breakableBlocks <= 0)
        {
            this.sceneLoader.LoadNextScene();
        }
    }
}
