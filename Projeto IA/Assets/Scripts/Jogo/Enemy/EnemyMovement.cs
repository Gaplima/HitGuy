using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour{
    private float _speed = 2;
    private float _rotationSpeed = 180;
    private Rigidbody2D _rigidbody;
    private PlayerAwarenessController _playerAwarenessController;
    private Vector2 _targetDirection;
    private float _changeDirectionCooldown;
    public float _enemyLife = 2;

    private void Awake(){
        _rigidbody = GetComponent<Rigidbody2D>();
        _playerAwarenessController = GetComponent<PlayerAwarenessController>();
        _targetDirection = transform.up;
    }

    private void FixedUpdate(){
        UpdateTargetDirection();
        RotateTowardsTarget();
        SetVelocity();
    }

    private void UpdateTargetDirection(){
        HandleRandomDirectionChange();
        HandlePlayerTargeting();
    }

    private void HandleRandomDirectionChange(){
        _changeDirectionCooldown -= Time.deltaTime;
        if (_changeDirectionCooldown <= 0){
            float angleChange = Random.Range(-90f, 90f);
            Quaternion rotation = Quaternion.AngleAxis(angleChange, transform.forward);
            _targetDirection = rotation * _targetDirection;
            _changeDirectionCooldown = Random.Range(1f, 5f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.GetComponent<Bullet>()){
            if(_enemyLife == 2){
                _enemyLife = 1;
            }
            else if(_enemyLife == 1){
                _enemyLife = 0;
                Destroy(gameObject);
            }
        }
    }

    private void HandlePlayerTargeting(){
        if (_playerAwarenessController.AwareOfPlayer){
            if (_enemyLife == 2){
                _targetDirection = _playerAwarenessController.DirectionToPlayer;
            }
            else{
                _targetDirection = _playerAwarenessController.DirectionToPlayer * -1;
            }
        }
    }
    private void RotateTowardsTarget(){

        Quaternion targetRotation = Quaternion.LookRotation(transform.forward, _targetDirection);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
        _rigidbody.SetRotation(rotation);
    }

    private void SetVelocity(){
        _rigidbody.velocity = transform.up * _speed;
    }
}
