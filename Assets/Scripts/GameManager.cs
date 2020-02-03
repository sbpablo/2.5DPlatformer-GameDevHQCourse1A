using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoSingleton<GameManager>
{
    private bool _isGameOver;
    [SerializeField]
    private Text _gameOverText;
    private GameObject _player;




    private void OnEnable()
    {
        Player.OnLivesUpdate += SetGameOver;
    }

    private void OnDisable()
    {
        Player.OnLivesUpdate -= SetGameOver;
    }


    void Start()
    {
        if (_gameOverText == null)
        {
            Debug.Log("No GameOver Text assigned in GameManager");
        }
        
        _gameOverText.gameObject.SetActive(false);

        _player = GameObject.FindGameObjectWithTag("Player");

        if (_player== null)
        {
            Debug.LogError("Ther is no object with a Player tag in the Game");
        } 
    }

    // Update is called once per frame
    void Update()
    {
        if (_isGameOver )
        {
            if (!_gameOverText.gameObject.activeSelf)
            {
                _gameOverText.gameObject.SetActive(true);
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(0);
            }

           
            if (_player.activeSelf == true)
            {
                _player.SetActive(false);
            }
         
        }
    }


    private void SetGameOver(int lives)
    {
        if (lives <= 0)
        {
            _isGameOver = true;
        }
    }
}
