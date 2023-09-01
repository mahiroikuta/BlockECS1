using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSystem : MonoBehaviour
{
    
    GameState _gameState;
    GameEvent _gameEvent;

    public LayerMask mask = -1;
    public void Init(GameState gameState, GameEvent gameEvent)
    {
        _gameState = gameState;
        _gameEvent = gameEvent;
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
            Vector3 BallDirec = Vector3.Scale((mousePos - _gameState.ballPrefab.transform.position), new Vector3(1,1,0)).normalized;
            _gameState.ballPrefab.gameObject.GetComponent<BallComponent>().direction = BallDirec;
            Rigidbody2D rb = _gameState.ballPrefab.GetComponent<Rigidbody2D>();
            rb.velocity = BallDirec * _gameState.ballPrefab.GetComponent<BallComponent>().speed;
            _gameState.isMoving = true;
        }
    }

    void HitObject()
    {
        Vector3 ballPos = _gameState.ballPrefab.transform.position;
        Vector3 ballDirec = _gameState.ballPrefab.gameObject.GetComponent<BallComponent>().direction;

        Ray ray = new Ray(ballPos, ballDirec);

        RaycastHit hit;

        Debug.DrawLine(ray.origin, ray.origin+ray.direction * 100, Color.red, 0);

        bool isHit = Physics.SphereCast(ballPos, 0.5f, ballDirec, out hit, 0.5f, mask);

        if (isHit)
        {
            GameObject hitObj = hit.collider.gameObject;
            if (hitObj.layer != 6 && hitObj.layer != 7 && hitObj.layer != 3) return;
            if (hitObj.layer == 7)
            {
                _gameEvent.ballHitBlock?.Invoke(hitObj);
            } 

            Vector3 normal = hit.normal;

            Vector3 direction = ray.direction;

            Vector3 ref_direc = 2 * normal * Vector3.Dot(normal, -direction) + direction;

            BallComponent ball = _gameState.ballPrefab.gameObject.GetComponent<BallComponent>();
            ball.direction = ref_direc;
            Rigidbody2D rb = _gameState.ballPrefab.GetComponent<Rigidbody2D>();
            rb.velocity = ref_direc * ball.speed;
        }

    }
}
