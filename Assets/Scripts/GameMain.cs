using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMain : MonoBehaviour
{
    [SerializeField]
    GameState _gameState;

    public BallSystem ballSystem;
    public BlockSystem blockSystem;
    public PlayerSystem playerSystem;

    GameObject ball;

    void Start()
    {
        Debug.Log("#####");
        ballSystem.Init(_gameState);
        blockSystem.Init(_gameState);
        playerSystem.Init(_gameState);
    }

    void Update()
    {
        ballSystem.OnUpdate();
        blockSystem.OnUpdate();
        playerSystem.OnUpdate();
    }
}
