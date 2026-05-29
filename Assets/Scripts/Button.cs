using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Button : MonoBehaviour, IPointerDownHandler,IPointerUpHandler,IPointerExitHandler
{
    private bool isPressing;

    [SerializeField] private UnityEvent onPressing;
    [SerializeField] private UnityEvent notPressing;
    
    public void OnPointerDown(PointerEventData eventData)
    {
        isPressing = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressing = false;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isPressing = false;
    }

    private void Update()
    {
        if (isPressing)
        {
            onPressing.Invoke();
        }
        else
        {
            notPressing.Invoke();
        }
    }
}
