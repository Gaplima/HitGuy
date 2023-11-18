using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    private GameObject _bulletPrefab;
    [SerializeField]
    private float _bulletSpeed;
    [SerializeField]
    private Transform _gunOffset;
    [SerializeField]
    private float _timeBetweenShots;

    private bool _fireContinuously;
    private bool _fireSingle;
    private float _lastFireTime;
    public Municao _municao;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update(){
        if (_fireContinuously || _fireSingle){
            float timeSinceLastFire = Time.time - _lastFireTime;
            if (timeSinceLastFire >= _timeBetweenShots){
                FireBullet();
                _lastFireTime = Time.time;
                _fireSingle = false;
            }
        }
    }
    private void FireBullet(){
        if (_municao.Score > 0){
            GameObject bullet = Instantiate(_bulletPrefab, _gunOffset.position, transform.rotation);
            Rigidbody2D rigidbody = bullet.GetComponent<Rigidbody2D>();
            rigidbody.velocity = _bulletSpeed * transform.up;
            _municao.Score -= 1;
        }
    }
    /*void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Ammo")){
            Destroy(other.gameObject);
            _municao.Score += 6;
        }
    }*/
    private void OnFire(InputValue inputValue){
        _fireContinuously = inputValue.isPressed;
        if (inputValue.isPressed){
            _fireSingle = true;
        }
    }
}
