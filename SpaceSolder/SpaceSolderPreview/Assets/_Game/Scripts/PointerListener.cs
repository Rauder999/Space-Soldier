using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class PointerListener : MonoBehaviour, IPointerUpHandler, IPointerDownHandler, IPointerClickHandler
{
    public Action OnPointerUp;
    public Action OnPointerDown;
    public Action OnPointerClick;

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        OnPointerUp?.Invoke();
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        OnPointerDown?.Invoke();
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        OnPointerClick?.Invoke();
    }
}
