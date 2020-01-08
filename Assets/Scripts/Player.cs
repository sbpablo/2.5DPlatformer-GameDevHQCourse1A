using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    private CharacterController _chatacterController;
    [SerializeField]
    private float _speed = 56f;
    [SerializeField]
    private float _gravity = 20f;
    [SerializeField]
    private float _jumpHeight = 8f;
    private Vector3 _moveDirection;
    private float _yDirection;
    private int _maxJumps=2;
    private int _currentJumps=1;
    private int _coinsCollected;
    public static event Action<int> OnCoinCollected;


    void Start()
    {
        _chatacterController = GetComponent<CharacterController>();
        
        if (_chatacterController == null)
        {
            Debug.LogError("Character Controller missing in Player");
        }

        
    }

    // Update is called once per frame
    void Update()
    {

        _moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        _moveDirection *= _speed;

        if (_chatacterController.isGrounded)
        {
            _currentJumps = 1;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _yDirection = _jumpHeight;
            }

        }

        else
        {
            
            if (Input.GetKeyDown (KeyCode.Space) && _currentJumps < _maxJumps )
            {
                _yDirection += _jumpHeight;  // += _jumpHeight hace que no pueda saltar cuando estoy cayendo por gravedad. En cambio, = hace que el salto se produzca incluso cayendo
                _currentJumps++;
            }
            
            _yDirection -= _gravity;
 
        }

        _moveDirection.y = _yDirection;

        _chatacterController.Move(_moveDirection * Time.deltaTime);
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Coin")
        {
            _coinsCollected++;
            other.gameObject.SetActive(false);
            
            if (OnCoinCollected != null)
            {
                OnCoinCollected(_coinsCollected);
            }
            
            
        }
    }

    private void OnCoinsCollected()
    {

    }


   


}
