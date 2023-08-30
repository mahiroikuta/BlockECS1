using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSystem : MonoBehaviour
{
    
    GameState _gameState;
    public void Init(GameState gameState)
    {
        _gameState = gameState;
    }

    public GameState OnUpdate()
    {
        AddDirec();
        HitObject();
        return _gameState;
    }

    void AddDirec()
    {
        if (_gameState.isMoving) return;
        if (Input.GetMouseButtonUp(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 BallDirec = Vector3.Scale((mousePos - _gameState.ball.transform.position), new Vector3(1,1,0)).normalized;
            Rigidbody2D rb = _gameState.ball.GetComponent<Rigidbody2D>();
            rb.velocity = BallDirec * _gameState.ball.GetComponent<BallComponent>().speed;
            _gameState.isMoving = true;
            Debug.Log("#####");
        }
    }

    void HitObject()
    {
        // directionに向かいオブジェクトに当たったらブロックのHPを減らす

    }
}
