using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMain : MonoBehaviour
{
    [SerializeField]
    GameState _gameState;
    [SerializeField]
    GameEvent _gameEvent;

    public BallSystem ballSystem;
    public BlockSystem blockSystem;
    public PlayerSystem playerSystem;

    GameObject ball;

    void Start()
    {
        ballSystem.Init(_gameState, _gameEvent);
        blockSystem.Init(_gameState, _gameEvent);
        playerSystem.Init(_gameState, _gameEvent);
    }

    void Update()
    {
        ballSystem.OnUpdate();
        blockSystem.OnUpdate();
        playerSystem.OnUpdate();
    }
}
