using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayScreen : Singleton<GamePlayScreen>
{
    public static event Action OnThrow;
    [SerializeField] private Image progressBar;
    [SerializeField] private Button throwButton;
    
    
    
    private float crosshairDiameter;
    private float crosshairPositionHorizontal;
    private float crosshairPositionVertical;
    private Vector2 screenCenter;
    private float proximity;
    
    protected override void Setup()
    {
        throwButton.onClick.AddListener(ThrowButton);
        ResetProgressBar();
        
        
        
        crosshairDiameter = (Screen.height * 1f);
        crosshairPositionHorizontal = (Screen.width - crosshairDiameter) / 2;
        crosshairPositionVertical = (Screen.height - crosshairDiameter) / 2;
        screenCenter.x = (Screen.width / 2);
        screenCenter.y = (Screen.height / 2);
        
        //SetBarSize();
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

    public void SetBarSize()
    {
        progressBar.sprite.rect.Set(crosshairPositionHorizontal, crosshairPositionVertical, crosshairDiameter, crosshairDiameter);
        progressBar.transform.parent.GetComponent<Image>().sprite.textureRect.Set(crosshairPositionHorizontal, crosshairPositionVertical, crosshairDiameter, crosshairDiameter);
    }
}
