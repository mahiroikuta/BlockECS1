using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameState
{
    public GameObject ball;
    public GameObject blockPrefab;
    [System.NonSerialized]
    public bool isMoving = false;
}
