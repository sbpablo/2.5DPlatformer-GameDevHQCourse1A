using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoSingleton<UIManager>
{
    [SerializeField]
    private Text _coinsText;
    [SerializeField]
    private Text _livesText;

    private void OnEnable()
    {
        Player.OnCoinCollected += ShowPlayerCoins;
        Player.OnLivesUpdate += ShowPlayerLives;
    }

    private void OnDisable()
    {
        Player.OnCoinCollected -= ShowPlayerCoins;
        Player.OnLivesUpdate -= ShowPlayerLives;
    }

    void Start()
    {
       if (_coinsText == null)
        {
            Debug.LogError("No text asiggned in UI for Player Coins");
        }

        if (_livesText == null)
        {
            Debug.LogError("No text asiggned in UI for Player Lives");
        }
    }

   
    void Update()
    {
        
    }

    private void ShowPlayerCoins (int amount)
    {
        _coinsText.text = $"Coins Collected: {amount}"; 
    }

    private void ShowPlayerLives(int amount)
    {
        _livesText.text = $"Lives: {amount}";
    }


}
