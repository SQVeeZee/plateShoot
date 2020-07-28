using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public static event Action<bool> OnInput; 
    
    public void OnPointerDown(PointerEventData eventData)
    { 
        OnInput?.Invoke(true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        OnInput?.Invoke(false);
    }
}