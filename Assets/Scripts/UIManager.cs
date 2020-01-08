using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoSingleton<UIManager>
{
    [SerializeField]
    private Text _text;

    private void OnEnable()
    {
        Player.OnCoinCollected += ShowPlayerCoins;
    }

    private void OnDisable()
    {
        Player.OnCoinCollected -= ShowPlayerCoins;
    }

    void Start()
    {
       
    }

   
    void Update()
    {
        
    }

    private void ShowPlayerCoins (int amount)
    {
        _text.text = $"Coins Collected: {amount}"; 
    }


}
