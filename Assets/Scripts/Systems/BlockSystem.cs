using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSystem : MonoBehaviour
{
    GameState _gameState;
    GameEvent _gameEvent;
    float time = 0;
    const float interval = 5f;
    const float height = 1.5f;
    const float width = 2.5f;
    public void Init(GameState gameState, GameEvent gameEvent)
    {
        _gameState = gameState;
        _gameEvent = gameEvent;
        _gameEvent.ballHitBlock += DamageBlock;

        InitGeneBlocks();
    }

    public GameState OnUpdate()
    {
        CountTimer();
        if (time > interval) 
        {
            MoveBlocks();
            GeneBlocks();
            time = 0;
        }
        return _gameState;
    }

    void CountTimer()
    {
        time += Time.deltaTime;
    }

    void MoveBlocks()
    {
        foreach(GameObject block in _gameState.blocks)
        {
            Vector3 pos = block.transform.position;
            Vector3 newPos = new Vector3(pos.x, pos.y - height, pos.z);
            block.transform.position = newPos;
        }
    }

    void InitGeneBlocks()
    {
        for(int i=0 ; i<3 ; i++)
        {
            for(int j=0 ; j<3 ; j++)
            {
                GameObject block = Instantiate(_gameState.blockPrefab, new Vector3(i*width-2.5f, 8-j*height, -1), Quaternion.identity);
                _gameState.blocks.Add(block);
            }
        }
    }

    void GeneBlocks()
    {
        for(int i=0 ; i<3 ; i++)
        {
            GameObject block = Instantiate(_gameState.blockPrefab, new Vector3(i*width-2.5f, 8, -1), Quaternion.identity);
            _gameState.blocks.Add(block);
        }
    }

    void DamageBlock(GameObject block)
    {
        int hp = block.GetComponent<BlockComponent>().hp;
        hp--;
        if(hp == 0)
        {
            _gameState.blocks.Remove(block);
            Destroy(block);
        }
    }
}
