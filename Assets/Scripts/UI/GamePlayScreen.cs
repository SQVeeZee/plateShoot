using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayScreen : Singleton<GamePlayScreen>
{
    [SerializeField] private Button throwButton;
    protected override void Setup()
    {
        throwButton.onClick.AddListener(ThrowButton);
    }

    public void ThrowButton()
    {
        
    }
}
