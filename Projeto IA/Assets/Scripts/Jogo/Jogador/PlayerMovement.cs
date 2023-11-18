using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour{
    private float _speed = 5;
    private float _rotationSpeed = 720;
    private Rigidbody2D _rigidbody;
    private Vector2 _movementInput;
    private Vector2 _smoothedMovementInput;
    private Vector2 _movementInputSmoothVelocity;
    public Coin _coin;
    public Municao _municao;
    public float itens = 9;

    private void Awake(){
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate(){
        SetPlayerVelocity();
        RotateInDirectionOfInput();
    }

    private void SetPlayerVelocity(){
        _smoothedMovementInput = Vector2.SmoothDamp(_smoothedMovementInput, _movementInput, ref _movementInputSmoothVelocity, 0.1f);

        _rigidbody.velocity = _smoothedMovementInput * _speed;
    }

    private void RotateInDirectionOfInput(){
        if (_movementInput != Vector2.zero){
            Quaternion targetRotation = Quaternion.LookRotation(transform.forward, _smoothedMovementInput);
            Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);

            _rigidbody.MoveRotation(rotation);
        }
    }

    private void OnMove(InputValue inputValue){
        _movementInput = inputValue.Get<Vector2>();
        //_municao.Score = 10;
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Coin")){
            Destroy(other.gameObject);
            _coin.Score += 10;
            itens -=1;
        }
        else if(other.gameObject.CompareTag("Ammo")){
            Destroy(other.gameObject);
            _municao.Score += 6;
            itens -=1;
        }
        else if(other.gameObject.CompareTag("AidKit")){
            itens -=1;
        }
        else if(other.gameObject.CompareTag("EndGame")){
            if(itens == 0){
                Destroy(other.gameObject);
                SceneManager.LoadScene("Jogo");
            }
        }
    }
}
