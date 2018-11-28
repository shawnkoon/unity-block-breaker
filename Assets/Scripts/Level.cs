using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField]
    private int breakableBlocks;

    public void RegisterBlock()
    {
        this.breakableBlocks++;
    }
}
