using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSystem : MonoBehaviour
{
    GameState _gameState;
    GameEvent _gameEvent;
    public void Init(GameState gameState, GameEvent gameEvent)
    {
        _gameState = gameState;
        _gameEvent = gameEvent;
    }

    public GameState OnUpdate()
    {
        MovePlayer();
        return _gameState;
    }

    void MovePlayer()
    {
        float hor = Input.GetAxis("Horizontal")/30;
        Vector3 pos = _gameState.player.transform.position;
        Vector3 newPos = new Vector3(pos.x+hor, pos.y, pos.z);
        if (newPos.x > 3.7) newPos.x = 3.7f;
        else if (newPos.x < -3.7) newPos.x = -3.7f;
        else _gameState.player.transform.position = new Vector3(pos.x+hor, pos.y, pos.z);
    }
}
