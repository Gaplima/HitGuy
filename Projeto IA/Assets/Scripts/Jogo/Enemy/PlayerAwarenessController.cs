using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAwarenessController : MonoBehaviour{
    public bool AwareOfPlayer { get; private set; }
    public Vector2 DirectionToPlayer { get; private set; }
    private float _playerAwarenessDistance = 7;
    private Transform _player;
   
    private void Awake(){
        _player = FindObjectOfType<PlayerMovement>().transform;
    }

    void Update(){
        Vector2 enemyToPlayerVector = _player.position - transform.position;
        DirectionToPlayer = enemyToPlayerVector.normalized;

        if (enemyToPlayerVector.magnitude <= _playerAwarenessDistance){
            AwareOfPlayer = true;
        }
        else{
            AwareOfPlayer = false;
        }
    }
}
