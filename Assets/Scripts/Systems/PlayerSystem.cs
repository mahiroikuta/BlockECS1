using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSystem : MonoBehaviour
{
    GameState _gameState;
    public void Init(GameState gameState)
    {
        _gameState = gameState;
    }

    public void OnUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {

    }
}
