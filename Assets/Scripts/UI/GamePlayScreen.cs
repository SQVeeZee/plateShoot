using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayScreen : Singleton<GamePlayScreen>
{
    public static event Action OnThrow;
    [SerializeField] private Image progressBar;
    [SerializeField] private Button throwButton;
    
    protected override void Setup()
    {
        throwButton.onClick.AddListener(ThrowButton);
        ResetProgressBar();
    }

    private void OnEnable()
    {
        AimChecker.OnDestroyPlate += EnableThrowButton;
    }

    private void OnDisable()
    {
        AimChecker.OnDestroyPlate -= EnableThrowButton;
    }

    public void EnableThrowButton()
    {
        throwButton.interactable = true;
    }

    public void ThrowButton()
    {
        OnThrow?.Invoke();
        throwButton.interactable = false;
    }

    public void ResetProgressBar()
    {
        progressBar.fillAmount = 0;
    }

    public void SetProgressBar(float progress)
    {
        progressBar.fillAmount = progress;
    }

    public void SetBarState(bool state)
    {
        progressBar.gameObject.SetActive(state);
    }
}
