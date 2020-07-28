using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayScreen : Singleton<GamePlayScreen>
{
    public static event Action OnThrow;
    [SerializeField] private Button throwButton;
    protected override void Setup()
    {
        throwButton.onClick.AddListener(ThrowButton);
    }

    public void ThrowButton()
    {
        OnThrow?.Invoke();
    }
}
