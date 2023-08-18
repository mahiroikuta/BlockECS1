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

    GameObject _ball;

    void Init()
    {
        ballSystem.Init();
        blockSystem.Init();
        playerSystem.Init();
    }

    void OnUpdate()
    {
        ballSystem.OnUpdate();
        blockSystem.OnUpdate();
        playerSystem.OnUpdate();
    }
}
