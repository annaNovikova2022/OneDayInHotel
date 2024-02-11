using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIButton : MonoBehaviour, IPointerClickHandler
{
    public Action OnClickButton;
        
    [SerializeField] private Button button;
        
    public void OnPointerClick(PointerEventData eventData)
    {
        OnClickButton?.Invoke();    
    }
}
